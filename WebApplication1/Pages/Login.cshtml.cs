using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using dotMovies.Models;
using dotMovies.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotMovies.Pages
{
    [BindProperties]
    public class LoginModel : PageModel
    {
        public UsersService UsersService;
        public string ReturnUrl { get; set; }

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


        public async Task<IActionResult> OnPostAsync() {

            if (ModelState.IsValid) {

                User credentials = new User();
                credentials.Login = InputLogin;
                credentials.Password = InputPassword;

                bool ifCredentialsCorrect = UsersService.CheckCredentials(credentials);

                if (!ifCredentialsCorrect) {
                    TempData["AuthenticationState"] = "AuthenticationFailure";
                    return Page();
                }


                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, credentials.Login)
                    
                };
            
                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);
            


                var authProperties = new AuthenticationProperties {
                    //AllowRefresh = <bool>,
                    // Refreshing the authentication session should be allowed.

                    //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                    // The time at which the authentication ticket expires. A 
                    // value set here overrides the ExpireTimeSpan option of 
                    // CookieAuthenticationOptions set with AddCookie.

                    //IsPersistent = true,
                    // Whether the authentication session is persisted across 
                    // multiple requests. When used with cookies, controls
                    // whether the cookie's lifetime is absolute (matching the
                    // lifetime of the authentication ticket) or session-based.

                    //IssuedUtc = <DateTimeOffset>,
                    // The time at which the authentication ticket was issued.

                    //RedirectUri = <string>
                    // The full path or absolute URI to be used as an http 
                    // redirect response value.
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return RedirectToPage("/index");
            }

            // Something failed. Redisplay the form.
            
            return Page();
        
        }

        

        public void OnGet()
        {
        }
    }
}
