using System.ComponentModel.DataAnnotations;

namespace gevs_identity.Pages.Account.Register;
public class RegisterViewModel
{
    // Required Fields
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string FullName { get; set; }
    [Required]
    public string DateOfBirth { get; set; }
    [Required]
    public string UniqueVoterCode { get; set; }

    // Not required fields
    public string ReturnUrl { get; set; }
    public string Button { get; set; }
}
    
