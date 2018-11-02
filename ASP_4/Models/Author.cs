using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace ASP_4.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfDeath { get; set; }

        public Author(string name, string dateOfBirth, string dateOfDeath)
        {
            Name = name;
            DateOfBirth = dateOfBirth.AsDateTime();
            DateOfDeath = dateOfDeath.AsDateTime();
        }

        public void AuthorEdit(string name, string dateOfBirth, string dateOfDeath)
        {
            Name = name;
            DateOfBirth = dateOfBirth.AsDateTime();
            DateOfDeath = dateOfDeath.AsDateTime();
        }
    }
}