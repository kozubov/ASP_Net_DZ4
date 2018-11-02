using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_4.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Publisher(string name)
        {
            Name = name;
        }
        public void EditPublisher(string name)
        {
            Name = name;
        }
    }
}