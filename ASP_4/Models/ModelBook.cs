using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ASP_4.Models
{
    public class ModelBook
    {
        [Required(ErrorMessage = "Fill NAME Field")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Fill DATE Field")]
        [RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$", ErrorMessage = "WRONG Date")]
        public string PublishingDate { get; set; }
        [Required(ErrorMessage = "Fill PAGE COUNT Field")]
        [RegularExpression(@"\-?\d+(\d{0,})?", ErrorMessage = "WRONG format")]
        public string PageCount { get; set; }
        [Required(ErrorMessage = "Fill ISBN Field")]
        public string ISBN { get; set; }
        public string RadioCheck { get; set; }
        public IList<string> SelectedCheck { get; set; } = new List<string>();

    }
}