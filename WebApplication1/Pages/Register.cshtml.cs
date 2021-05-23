using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using dotMovies.Models;

namespace dotMovies.Pages
{
    [BindProperties]
    public class RegisterModel : PageModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Login")]
        public string InputLogin { get; set; }
        
        [Required]
        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", 
            ErrorMessage = "Password must have 1 lowercase letter, 1 uppercase letter and 1 number.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string InputPassword { get; set; }
        

        public IActionResult OnPost() {

            if (!ModelState.IsValid) {

                return RedirectToPage("./Index");
            }


            return Page();
        }

        public void OnGet()
        {
            
        }
    }
}
