using System.ComponentModel.DataAnnotations;

namespace EventEaseApp.Models;

public class Event
{
	[Range(1, int.MaxValue, ErrorMessage = "Id must be a positive number.")]
	public int Id { get; set; }

	[Required(ErrorMessage = "Event name is required.")]
	[StringLength(100, MinimumLength = 3, ErrorMessage = "Event name must be between 3 and 100 characters.")]
	public string Name { get; set; } = string.Empty;

	[Required(ErrorMessage = "Event date is required.")]
	[DataType(DataType.Date)]
	public DateTime Date { get; set; }

	[Required(ErrorMessage = "Location is required.")]
	[StringLength(150, MinimumLength = 2, ErrorMessage = "Location must be between 2 and 150 characters.")]
	public string Location { get; set; } = string.Empty;

	/// <summary>
	/// Returns true when the event contains valid, displayable data.
	/// </summary>
	public bool IsValid() =>
		Id > 0 &&
		!string.IsNullOrWhiteSpace(Name) &&
		!string.IsNullOrWhiteSpace(Location) &&
		Date != default;
}
