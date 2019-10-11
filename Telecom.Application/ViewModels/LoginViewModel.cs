using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Telecom.Application.ViewModels
{
   public class LoginViewModel
    {
        [Required]
        [Display(Name = "User")]
        public string UserName { get; set; }

        [Required]
        [Display(Name ="Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name ="Database")]
        public string SelectedDatabaseName { get; set; }
        public IEnumerable<SelectListItem> DatabaseName { get; set; }

        [Display(Name ="Remember me")]
        public bool RememberMe { get; set; }
    }
}
