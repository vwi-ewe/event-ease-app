using EventEaseApp.Models;

namespace EventEaseApp.Services;

public class EventService
{
	private readonly List<Event> _events = new()
	{
		new Event { Id = 1, Name = "Copenhagen Light Festival", Date = new DateTime(2025, 2, 7), Location = "Copenhagen" },
		new Event { Id = 2, Name = "Roskilde Summer Concert", Date = new DateTime(2025, 6, 28), Location = "Roskilde" },
		new Event { Id = 3, Name = "Aarhus Food & Wine Celebration", Date = new DateTime(2025, 8, 15), Location = "Aarhus" },
		new Event { Id = 4, Name = "Midsummer Bonfire Party", Date = new DateTime(2025, 6, 23), Location = "Skagen" },
		new Event { Id = 5, Name = "Odense Hans Christian Andersen Festival", Date = new DateTime(2025, 8, 22), Location = "Odense" },
		new Event { Id = 6, Name = "Tivoli Christmas Market", Date = new DateTime(2025, 12, 6), Location = "Copenhagen" },
		new Event { Id = 7, Name = "Custom Corporate Gala", Date = new DateTime(2025, 10, 4), Location = "Aalborg" },
		new Event { Id = 8, Name = "Billund Family Fun Day", Date = new DateTime(2025, 7, 12), Location = "Billund" }
	};

	public List<Event> GetEvents() => _events;

	public Event? GetEventById(int id) => _events.FirstOrDefault(e => e.Id == id);

	/// <summary>
	/// Generates a large in-memory dataset for testing rendering performance
	/// (used alongside Virtualize in the events list).
	/// </summary>
	public List<Event> GetLargeEventDataset(int count = 10000)
	{
		var cities = new[] { "Copenhagen", "Aarhus", "Odense", "Aalborg", "Roskilde", "Billund" };
		var events = new List<Event>(count);
		var startDate = new DateTime(2025, 1, 1);

		for (var i = 1; i <= count; i++)
		{
			events.Add(new Event
			{
				Id = i,
				Name = $"EventEase Session #{i}",
				Date = startDate.AddDays(i % 365),
				Location = cities[i % cities.Length]
			});
		}

		return events;
	}
}
