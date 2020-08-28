using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Metrict.Data;
using System.ComponentModel.DataAnnotations;

namespace Metrict.Models
{
    public class LoginClass
    {
        [Required(ErrorMessage = "Please enter your username.")]
        [Display(Name = "Enter Username: ")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter your password.")]
        [Display(Name = "Enter Password: ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
