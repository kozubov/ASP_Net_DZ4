using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ASP_4.Models
{
    public class ModelAuthor
    {
        [Required(ErrorMessage = "Fill NAME Field")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Fill DATE OF BIRTH Field")]
        [RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$", ErrorMessage = "WRONG Date")]
        public string DateOfBirth { get; set; }
        [RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$", ErrorMessage = "WRONG Date")]
        public string DateOfDeath { get; set; }
    }
}