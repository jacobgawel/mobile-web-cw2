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

            if (ModelState.IsValid)
            {
                var uniqueCodeVerify = false;

                foreach (var uvc in _uvc)
                {
                    if (uvc == Input.UniqueVoterCode)
                    {
                        uniqueCodeVerify = true;
                        break;
                    }
                }

                if (!uniqueCodeVerify)
                {
                    RegisterWarning = true;
                    return Page();
                }

                var user = new ApplicationUser
                {
                    UserName = Input.Email,
                };

                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddClaimsAsync(user, new Claim[] {
                        new Claim(JwtClaimTypes.Name, Input.FullName),
                        new Claim(JwtClaimTypes.BirthDate, Input.DateOfBirth),
                        new Claim(JwtClaimTypes.Role, "voter")
                    });

                    RegisterSuccess = true;
                } else
                {
                    RegisterWarning = true;
                    RegisterError = result.Errors;

                }
            }

            return Page();
        }
    }
}
