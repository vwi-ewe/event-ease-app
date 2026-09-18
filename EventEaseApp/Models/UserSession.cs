namespace EventEaseApp.Models;

/// <summary>
/// Represents the currently signed-in user and the events they have registered for.
/// </summary>
public class UserSession
{
	public string Name { get; set; } = string.Empty;

	public string Email { get; set; } = string.Empty;

	public DateTime SignedInAt { get; set; } = DateTime.Now;

	public List<Attendee> Registrations { get; } = new();

	public bool IsActive => !string.IsNullOrWhiteSpace(Email);
}

/// <summary>
/// Represents a user's participation record for a single event.
/// </summary>
public class Attendee
{
	public int EventId { get; set; }

	public string EventName { get; set; } = string.Empty;

	public DateTime EventDate { get; set; }

	public string Location { get; set; } = string.Empty;

	public DateTime RegisteredAt { get; set; } = DateTime.Now;

	public bool HasCheckedIn { get; set; }
}
