using Library_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management_System.Service
{
    public interface IService
    {
        public Book Details(int id);
    }
}
