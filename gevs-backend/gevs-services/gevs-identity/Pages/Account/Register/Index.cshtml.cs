using System.Net.Mail;
using gevs_identity.Models;
using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace gevs_identity.Pages.Account.Register
{
    [SecurityHeaders]
    [AllowAnonymous]
    public class Index : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly List<string> _uvc =
        [
            "HH64FWPE", "BBMNS9ZJ", "KYMK9PUH", "WL3K3YPT", "JA9WCMAS",
            "Z93G7PN9", "WPC5GEHA", "RXLNLTA6", "7XUFD78Y", "DBP4GQBQ",
            "ZSRBTK9S", "B7DMPWCQ", "YADA47RL", "9GTZQNKB", "KSM9NB5L",
            "BQCRWTSG", "ML5NSKKG", "D5BG6FDH", "2LJFM6PM", "38NWLPY3",
            "2TEHRTHJ", "G994LD9T", "Q452KVQE", "75NKUXAH", "DHKVCU8T",
            "TH9A6HUB", "2E5BHT5R", "556JTA32", "LUFKZAHW", "DBAD57ZR",
            "K96JNSXY", "PFXB8QXM", "8TEXF2HD", "N6HBFD2X", "K3EVS3NM",
            "5492AC6V", "U5LGC65X", "BKMKJN5S", "JF2QD3UF", "NW9ETHS7",
            "VFBH8W6W", "7983XU4M", "2GYDT5D3", "LVTFN8G5", "UNP4A5T7",
            "UMT3RLVS", "TZZZCJV8", "UVE5M7FR", "W44QP7XJ", "9FCV9RMT"
        ];

        private readonly List<string> _constituency = [
            "Shangri-la-Town", "Northern-Kunlun-Mountain", "Western-Shangri-la",
            "Naboo-Vallery", "New-Felucia"
        ];

        public Index(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public RegisterViewModel Input { get; set; }

        [BindProperty]
        public bool RegisterSuccess { get; set; }

        [BindProperty]
        public IEnumerable<IdentityError> RegisterError { get; set; }

        [BindProperty]
        public bool RegisterWarning { get; set; }
        
        [BindProperty]
        public string WarningMessage { get; set; }
        
        public IActionResult OnGet(string returnUrl)
        {
            Input = new RegisterViewModel
            {
                ReturnUrl = returnUrl
            };

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (Input.Button != "register") return Redirect("~/");

            if (!ModelState.IsValid) return Page();
            
            var uniqueCodeVerify = false;

            Parallel.ForEach(_uvc, (uvc, state) =>
            {
                if (uvc == Input.UniqueVoterCode)
                {
                    uniqueCodeVerify = true;
                    state.Break();
                }
            });

            if (!uniqueCodeVerify)
            {
                WarningMessage = "The UVC code you entered is invalid";
                RegisterWarning = true;
                return Page();
            }

            if (!_constituency.Contains(Input.Constituency))
            {
                RegisterWarning = true;
                WarningMessage = "Please select valid Constituency";
                return Page();
            }

            if (!IsValidEmail(Input.Email))
            {
                return Page();
            }

            var user = new ApplicationUser
            {
                UserName = Input.Email,
            };

            var result = await _userManager.CreateAsync(user, Input.Password);

            if (result.Succeeded)
            {
                RegisterWarning = false;
                await _userManager.AddClaimsAsync(user, new[] {
                    new Claim(JwtClaimTypes.Name, Input.FullName),
                    new Claim(JwtClaimTypes.BirthDate, Input.DateOfBirth),
                    new Claim(JwtClaimTypes.Role, "voter"),
                    new Claim("UVC", Input.UniqueVoterCode),
                    new Claim("Constituency", Input.Constituency)
                });

                RegisterSuccess = true;
            } else
            {
                RegisterWarning = true;
                RegisterError = result.Errors;
            }

            return Page();
        }

        public bool IsValidEmail(string email)
        {
            try
            {
                var m = new MailAddress(email);
                return true;
            }
            catch (FormatException e)
            {
                RegisterWarning = true;
                WarningMessage = e.Message;
                return false;
            }
        }
    }
}
