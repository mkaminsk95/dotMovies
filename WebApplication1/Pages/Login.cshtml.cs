using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using dotMovies.Models;
using dotMovies.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotMovies.Pages
{
    [BindProperties]
    public class LoginModel : PageModel
    {
        public UsersService UsersService;

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Login")]
        public string InputLogin { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string InputPassword { get; set; }


        public LoginModel(UsersService usersService) {

            UsersService = usersService;
        }

        public IActionResult OnPost() {

            if (ModelState.IsValid) {

                User credentials = new User();
                credentials.Login = InputLogin;
                credentials.Password = InputPassword;

                bool ifCredentialsCorrect = UsersService.CheckCredentials(credentials);

                if (ifCredentialsCorrect)
                    return RedirectToPage("/index");
                else
                    TempData["AuthenticationState"] = "AuthenticationFailure";
            }

            return Page();
        }

        public void OnGet()
        {
        }
    }
}
