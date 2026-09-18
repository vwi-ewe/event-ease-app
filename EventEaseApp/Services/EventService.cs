using EventEaseApp.Models;

namespace EventEaseApp.Services;

public class EventService
{
	private readonly List<Event> _events = new()
	{
		new Event { Id = 1, Name = "Annual Tech Conference", Date = new DateTime(2025, 9, 18), Location = "Seattle, WA" },
		new Event { Id = 2, Name = "Corporate Gala Dinner", Date = new DateTime(2025, 10, 4), Location = "New York, NY" },
		new Event { Id = 3, Name = "Product Launch Party", Date = new DateTime(2025, 11, 12), Location = "Austin, TX" },
		new Event { Id = 4, Name = "Team Building Retreat", Date = new DateTime(2025, 12, 2), Location = "Denver, CO" }
	};

	public IReadOnlyList<Event> GetEvents() => _events;

	public Event? GetEventById(int id) => _events.FirstOrDefault(e => e.Id == id);
}
