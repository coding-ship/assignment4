using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Library_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library_Management_System.Service;

namespace Library_Management_System.Controllers
{
    public class DashboardController : Controller
    {
        private MyLibraryContext db = new MyLibraryContext();
        public IService service;
        public DashboardController(IService ser)
        {
            service = ser;
        }
        /*public MyLibraryContext db;

        public DashboardController(MyLibraryContext _context)
        {
            db = _context;
        }*/

        // GET: DashboardController
        public IActionResult Index()
        {
            return View(db.Books.ToList());
        }

        // GET: DashboardController/Details/5
        public ActionResult Details(int id)
        {
            /*var books = db.Books.ToList();
            var book = books.FirstOrDefault(m => m.Book_Id == id);*/
            var book = service.Details(id);
            return View(book);
        }

        // GET: DashboardController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DashboardController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            try
            {
                db.Books.Add(book);
                db.SaveChanges();
                ViewBag.Message = "Book Record Inserted Successfully!";
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: DashboardController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.id = id;
            var books = db.Books.ToList();
            var book = books.FirstOrDefault(m => m.Book_Id == id);
            return View(book);
        }

        // POST: DashboardController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Book bookdata)
        {
            try
            {
                ViewBag.id = id;
                var books = db.Books.ToList();
                var book = books.FirstOrDefault(m => m.Book_Id == id);
                book.Author = bookdata.Author;
                book.Book_Name = bookdata.Book_Name;
                book.Language = bookdata.Language;
                book.No_of_Books = bookdata.No_of_Books;
                book.No_of_pages = bookdata.No_of_pages;
                book.Price = bookdata.Price;
                db.SaveChanges();
                ViewBag.Message = "Book Record Updated Successfully!";
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: DashboardController/Delete/5
        public ActionResult Delete(int id)
        {
            var books = db.Books.ToList();
            var book = books.FirstOrDefault(m => m.Book_Id == id);
            return View(book);
        }

        // POST: DashboardController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Book bookdata)
        {
            try
            {
                Book book = db.Books.SingleOrDefault(x => x.Book_Id == id);
                db.Books.Remove(book);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult AddNewUser()
        {
            return View();
        }

        // POST: DashboardController/AddNewUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNewUser(UserDetails user)
        {
            try
            {
                db.UserDetails.Add(user);
                db.SaveChanges();
                ViewBag.Message = "New User Added Successfully!";
                return View();

            }
            catch(Exception ex)
            {
                return View();
            }
        }
        

            public ActionResult IssueBook(int id)
        {
            var books = db.Books.ToList();
            var book = books.FirstOrDefault(m => m.Book_Id == id);
            TempData["Book_Id"] = book.Book_Id;
            TempData["Book_Name"] = book.Book_Name;
            TempData["Author"] = book.Author;
            return View();
        }

        // POST: DashboardController/IssueBook
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IssueBook(IssueDetails issue)
        {
            try
            {
                IssueDetails data = new IssueDetails();
                data.Book_Id = issue.Book_Id;
                data.Book_Author = issue.Book_Author;
                data.Book_Name = issue.Book_Name;
                TempData["Book_Id"] = data.Book_Id;
                TempData["Book_Name"] = data.Book_Name;
                TempData["Author"] = data.Book_Author;
                var users = db.UserDetails.ToList();
                var find = users.Find(x => x.User_Id == issue.User_Id);
                if (find != null)
                {
                    var book = db.Books.ToList().FirstOrDefault(m => m.Book_Id == data.Book_Id);
                    if (book.No_of_Books >= 1)
                    {
                        book.No_of_Books--;
                        data.User_Name = find.User_Name;
                        data.Phone_Number = find.Phone_no;
                        data.User_Id = find.User_Id;
                        data.Issue_Date = issue.Issue_Date;
                        db.IssueDetail.Add(data);
                        db.SaveChanges();
                        ViewBag.Message = "Book Issued Successfully!";
                    }
                    else
                    ViewBag.Error = "Book Not Present as all books are issued!";
                    
                }
                else
                {
                    ViewBag.Error = "User does not exists in record!";
                }
                return View();
            }
            catch(Exception ex)
            {
                return View();
            }
        }

            public IActionResult IssuedBook()
            {
                return View(db.IssueDetail.ToList());
            }

        public IActionResult Users()
        {
            return View(db.UserDetails.ToList());
        }

        
        public IActionResult ReturnBook(int id)
        {
            var list = db.IssueDetail.ToList();
            var issue = list.Find(x => x.Id == id);
            return View(issue);
        }

        // POST: DashboardController/ReturnBook
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReturnBook(IssueDetails issueDetails)
        {
            try
            {  
                var list = db.IssueDetail.ToList();
                var issue = list.Find(x => x.Id == issueDetails.Id);
                var book = db.Books.ToList().Find(x => x.Book_Id == issue.Book_Id);
                book.No_of_Books++;
                db.IssueDetail.Remove(issue);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Search()
        {
            return View();
        }

        // POST: DashboardController/Search
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(IssueDetails issue)
        {
            return RedirectToAction("IssueByUser", new { id = issue.User_Id });
            
        }

        public IActionResult IssueByUser(int id)
        {
            var list = db.IssueDetail.ToList();
            var issue = list.Where(x => x.User_Id == id).ToList();
            if (issue.Count == 0)
            ViewBag.Error = "No Book is issued to this user.";
            return View(issue);
        }
    }
}
