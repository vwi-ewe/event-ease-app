using System.ComponentModel.DataAnnotations;

namespace EventEaseApp.Models;

/// <summary>
/// Validated input model for the event registration form.
/// </summary>
public class RegistrationModel
{
	[Required(ErrorMessage = "Please enter your full name.")]
	[StringLength(80, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 80 characters.")]
	public string Name { get; set; } = string.Empty;

	[Required(ErrorMessage = "Please enter your email address.")]
	[EmailAddress(ErrorMessage = "Please enter a valid email address.")]
	public string Email { get; set; } = string.Empty;

	[Phone(ErrorMessage = "Please enter a valid phone number.")]
	public string? PhoneNumber { get; set; }
}
