using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ASP_4.Models
{
    public class ModelPublisher
    {
        [Required(ErrorMessage = "Fill NAME Field")]
        public string Name { get; set; }
    }
}