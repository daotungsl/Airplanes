using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Airplanes.Models.Custom;
using Airplanes.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Airplanes.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<AirplanesUser> _signInManager;
        private readonly UserManager<AirplanesUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;
        MailVerify mv = new MailVerify();
        public RegisterModel(
            UserManager<AirplanesUser> userManager,
            SignInManager<AirplanesUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Text)]
            [Display(Name = "Full Name")]
            public string FullName { get; set; }

            [Required]
            [Display(Name = "Gender")]
            public UserGender Gender { get; set; }

            [Required]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            [Display(Name = "Birthday")]
            public DateTime Birthday { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "ID Number")]
            public string IdNumber { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Address")]
            public string Address { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Phone Number")]
            public string PhoneNumber { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var reward = 0;
                var uId = DateTime.Now.Ticks;
                var createdAt = DateTime.Now.Date;
                var updatedAt = DateTime.Now.Date;
                var user = new AirplanesUser { UserName = Input.Email, Email = Input.Email, FullName = Input.FullName, Birthday = Input.Birthday, PhoneNumber = Input.PhoneNumber, Gender = Input.Gender, IdNumber = Input.IdNumber, Address = Input.Address, UId = uId, RewardPoints = reward, CreatedAt = createdAt, UpdatedAt = updatedAt };
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
                    string htmlBody =
                    "<html>\r\n   <head>\r\n      <style>\r\n         .banner-color {\r\n         background-color: #eb681f;\r\n         }\r\n         .title-color {\r\n         color: #0066cc;\r\n         }\r\n         .button-color {\r\n         background-color: #0066cc;\r\n         }\r\n         @media screen and (min-width: 500px) {\r\n         .banner-color {\r\n         background-color: #0066cc;\r\n         }\r\n         .title-color {\r\n         color: #eb681f;\r\n         }\r\n         .button-color {\r\n         background-color: #eb681f;\r\n         }\r\n         }\r\n      </style>\r\n   </head>\r\n   <body>\r\n      <div style=\"background-color:#ececec;padding:0;margin:0 auto;font-weight:200;width:100%!important\">\r\n         <table align=\"center\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"table-layout:fixed;font-weight:200;font-family:Helvetica,Arial,sans-serif\" width=\"100%\">\r\n            <tbody>\r\n               <tr>\r\n                  <td align=\"center\">\r\n                     <center style=\"width:100%\">\r\n                        <table bgcolor=\"#FFFFFF\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"margin:0 auto;max-width:512px;font-weight:200;width:inherit;font-family:Helvetica,Arial,sans-serif\" width=\"512\">\r\n                           <tbody>\r\n                              <tr>\r\n                                 <td bgcolor=\"#F3F3F3\" width=\"100%\" style=\"background-color:#f3f3f3;padding:12px;border-bottom:1px solid #ececec\">\r\n                                    <table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"font-weight:200;width:100%!important;font-family:Helvetica,Arial,sans-serif;min-width:100%!important\" width=\"100%\">\r\n                                       <tbody>\r\n                                          <tr>\r\n                                             <td align=\"left\" valign=\"middle\" width=\"50%\"><span style=\"margin:0;color:#4c4c4c;white-space:normal;display:inline-block;text-decoration:none;font-size:12px;line-height:20px\">EAGLE AIRLINE</span></td>\r\n                                             <td valign=\"middle\" width=\"50%\" align=\"right\" style=\"padding:0 0 0 10px\"><span style=\"margin:0;color:#4c4c4c;white-space:normal;display:inline-block;text-decoration:none;font-size:12px;line-height:20px\">" +
                    DateTime.Now +
                    "</span></td>\r\n                                             <td width=\"1\">&nbsp;</td>\r\n                                          </tr>\r\n                                       </tbody>\r\n                                    </table>\r\n                                 </td>\r\n                              </tr>\r\n                              <tr>\r\n                                 <td align=\"left\">\r\n                                    <table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"font-weight:200;font-family:Helvetica,Arial,sans-serif\" width=\"100%\">\r\n                                       <tbody>\r\n                                          <tr>\r\n                                             <td width=\"100%\">\r\n                                                <table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"font-weight:200;font-family:Helvetica,Arial,sans-serif\" width=\"100%\">\r\n                                                   <tbody>\r\n                                                      <tr>\r\n                                                         <td align=\"center\" bgcolor=\"#8BC34A\" style=\"padding:20px 48px;color:#ffffff\" class=\"banner-color\">\r\n                                                            <table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"font-weight:200;font-family:Helvetica,Arial,sans-serif\" width=\"100%\">\r\n                                                               <tbody>\r\n                                                                  <tr>\r\n                                                                     <td align=\"center\" width=\"100%\">\r\n                                                                        <h1 style=\"padding:0;margin:0;color:#ffffff;font-weight:500;font-size:20px;line-height:24px\">EAGLE AIRLINE VERIFY EMAIL</h1>\r\n                                                                     </td>\r\n                                                                  </tr>\r\n                                                               </tbody>\r\n                                                            </table>\r\n                                                         </td>\r\n                                                      </tr>\r\n                                                      <tr>\r\n                                                         <td align=\"center\" style=\"padding:20px 0 10px 0\">\r\n                                                            <table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"font-weight:200;font-family:Helvetica,Arial,sans-serif\" width=\"100%\">\r\n                                                               <tbody>\r\n                                                                  <tr>\r\n                                                                     <td align=\"center\" width=\"100%\" style=\"padding: 0 15px;text-align: justify;color: rgb(76, 76, 76);font-size: 12px;line-height: 18px;\">\r\n                                                                        <h3 style=\"font-weight: 600; padding: 0px; margin: 0px; font-size: 16px; line-height: 24px; text-align: center;\" class=\"title-color\">Hi " + Input.FullName +
                    "</h3>\r\n                                                                        <p style=\"margin: 20px 0 30px 0;font-size: 15px;text-align: center;\">Chúng tôi gửi email này để xác nhận tài khoản email của bạn !</p>\r\n                                                                        <div style=\"font-weight: 200; text-align: center; margin: 25px;\"><a style=\"padding:0.6em 1em;border-radius:600px;color:#ffffff;font-size:14px;text-decoration:none;font-weight:bold\" class=\"button-color\" href=\"" + callbackUrl + "\">Xác nhận Email</a></div>\r\n                                                                     </td>\r\n                                                                  </tr>\r\n                                                               </tbody>\r\n                                                            </table>\r\n                                                         </td>\r\n                                                      </tr>\r\n                                                      <tr>\r\n                                                      </tr>\r\n                                                      <tr>\r\n                                                      </tr>\r\n                                                   </tbody>\r\n                                                </table>\r\n                                             </td>\r\n                                          </tr>\r\n                                       </tbody>\r\n                                    </table>\r\n                                 </td>\r\n                              </tr>\r\n                              <tr>\r\n                                 <td align=\"left\">\r\n                                    <table bgcolor=\"#FFFFFF\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"padding:0 24px;color:#999999;font-weight:200;font-family:Helvetica,Arial,sans-serif\" width=\"100%\">\r\n                                       <tbody>\r\n                                          <tr>\r\n                                             <td align=\"center\" width=\"100%\">\r\n                                                <table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"font-weight:200;font-family:Helvetica,Arial,sans-serif\" width=\"100%\">\r\n                                                   <tbody>\r\n                                                      <tr>\r\n                                                         <td align=\"center\" valign=\"middle\" width=\"100%\" style=\"border-top:1px solid #d9d9d9;padding:12px 0px 20px 0px;text-align:center;color:#4c4c4c;font-weight:200;font-size:12px;line-height:18px\">EAGLE AIRLINE,\r\n                                                            <br><b>The Focus Team</b>\r\n                                                         </td>\r\n                                                      </tr>\r\n                                                   </tbody>\r\n                                                </table>\r\n                                             </td>\r\n                                          </tr>\r\n                                          <tr>\r\n                                             <td align=\"center\" width=\"100%\">\r\n                                                <table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"font-weight:200;font-family:Helvetica,Arial,sans-serif\" width=\"100%\">\r\n                                                   <tbody>\r\n                                                      <tr>\r\n                                                         <td align=\"center\" style=\"padding:0 0 8px 0\" width=\"100%\"></td>\r\n                                                      </tr>\r\n                                                   </tbody>\r\n                                                </table>\r\n                                             </td>\r\n                                          </tr>\r\n                                       </tbody>\r\n                                    </table>\r\n                                 </td>\r\n                              </tr>\r\n                           </tbody>\r\n                        </table>\r\n                     </center>\r\n                  </td>\r\n               </tr>\r\n            </tbody>\r\n         </table>\r\n      </div>\r\n   </body>\r\n</html>";


                    string subject = "Eagle Airline Verify Email";
                    mv.SendMail(Input.Email, user.Id, htmlBody, subject);
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        
    }
}
