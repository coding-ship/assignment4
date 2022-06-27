using Library_Management_System.Controllers;
using Library_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Collections.Generic;
using Moq;
using System;
using Library_Management_System.Service;

namespace NUnitTestProject1
{
    public class Tests
    {
        private Mock<IService> mock;
        public IService service;

        List<Book> Book_List;
        Book book = new Book() { Book_Id = 1, Book_Name = "Mathematics", Author = "RS Agarwal", Language = "English", No_of_pages = 360, Price = 500, No_of_Books = 16 };

        [SetUp]
        public void Setup()
        {
            Book_List = new List<Book> {
            new Book(){ Book_Id = 1, Book_Name = "Mathematics", Author = "RS Agarwal", Language = "English", No_of_pages = 360, Price = 500, No_of_Books = 16 },
            new Book(){ Book_Id = 2, Book_Name = "Applied Chemistry", Author = "RS Agarwal", Language = "English", No_of_pages = 400, Price = 600, No_of_Books = 24 },
            new Book(){ Book_Id = 3, Book_Name = "Applied Physics", Author = "RS Agarwal", Language = "English", No_of_pages = 250, Price = 300, No_of_Books = 10 },
            new Book(){ Book_Id = 4, Book_Name = "Advance OOPS", Author = "D.S Guru", Language = "English", No_of_pages = 600, Price = 800, No_of_Books = 30 }
        };

            mock = new Mock<IService>();
            mock.Setup(x => x.Details(1)).Returns(book);

        }

        [Test]
        public void GetBookDetails_ValidInput_ReturnsOkRequest()
        {
            service = mock.Object;
            int id = 1;
            Book answer = service.Details(id);
            Assert.AreEqual(book, answer);
        }

        [Test]
        public void GetBookDetails_InvalidInput_ReturnsNotFoundResult()
        {
            service = mock.Object;
            int id = 2;
            Book answer = service.Details(id);
            Assert.AreNotEqual(book, answer);
        }

        [Test]
        public void GetBookDetails_ValidInput_ReturnsInValidOutput()
        {
            service = mock.Object;
            int id = 1;
            Book answer = service.Details(id);
            Assert.AreNotEqual(Book_List[1], answer);
        }

        [Test]
        public void GetBookDetails_ValidInput_ReturnsNull_InValidOutput()
        {
            service = mock.Object;
            int id = 1;
            Book answer = service.Details(id);
            Assert.AreNotEqual(null, answer);
        }
    }
}