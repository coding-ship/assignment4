using Library_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management_System.Service
{
    
    public class LibraryService:IService
    {
        

        private MyLibraryContext db = new MyLibraryContext();

        public Book Details(int id)
        {
            var books = db.Books.ToList();
            var book = books.FirstOrDefault(m => m.Book_Id == id);
            return book;
        }
    }
}
