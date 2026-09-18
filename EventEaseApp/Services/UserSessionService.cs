using EventEaseApp.Models;

namespace EventEaseApp.Services;

/// <summary>
/// Tracks the current user session and their event attendance in memory.
/// Registered as a singleton so state persists across page navigation.
/// </summary>
public class UserSessionService
{
	/// <summary>Raised whenever the session state changes so components can refresh.</summary>
	public event Action? OnChange;

	public UserSession CurrentSession { get; private set; } = new();

	public bool IsSignedIn => CurrentSession.IsActive;

	public IReadOnlyList<Attendee> Registrations => CurrentSession.Registrations;

	/// <summary>Starts or updates the current user session.</summary>
	public void SignIn(string name, string email)
	{
		CurrentSession.Name = name;
		CurrentSession.Email = email;
		CurrentSession.SignedInAt = DateTime.Now;
		NotifyStateChanged();
	}

	/// <summary>Clears the current session and all attendance records.</summary>
	public void SignOut()
	{
		CurrentSession = new UserSession();
		NotifyStateChanged();
	}

	/// <summary>Registers the current user for an event (no duplicates).</summary>
	public void RegisterForEvent(Event @event)
	{
		if (CurrentSession.Registrations.Any(a => a.EventId == @event.Id))
		{
			return;
		}

		CurrentSession.Registrations.Add(new Attendee
		{
			EventId = @event.Id,
			EventName = @event.Name,
			EventDate = @event.Date,
			Location = @event.Location
		});

		NotifyStateChanged();
	}

	public bool IsRegisteredFor(int eventId) =>
		CurrentSession.Registrations.Any(a => a.EventId == eventId);

	/// <summary>Toggles the check-in state for a registered event.</summary>
	public void ToggleCheckIn(int eventId)
	{
		var attendee = CurrentSession.Registrations.FirstOrDefault(a => a.EventId == eventId);
		if (attendee is not null)
		{
			attendee.HasCheckedIn = !attendee.HasCheckedIn;
			NotifyStateChanged();
		}
	}

	/// <summary>Removes a registration.</summary>
	public void CancelRegistration(int eventId)
	{
		var attendee = CurrentSession.Registrations.FirstOrDefault(a => a.EventId == eventId);
		if (attendee is not null)
		{
			CurrentSession.Registrations.Remove(attendee);
			NotifyStateChanged();
		}
	}

	private void NotifyStateChanged() => OnChange?.Invoke();
}
