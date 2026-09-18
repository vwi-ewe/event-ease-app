# EventEase

EventEase is a Blazor WebAssembly front-end for a fictional corporate and social event management company. It lets users browse upcoming events, view event details, and register — with clean navigation between pages.

This project was built as a course assignment demonstrating how to accelerate Blazor development with GitHub Copilot.

## Features

- **Event browsing** — a responsive list of events rendered with a reusable Event Card component.
- **Reusable Event Card component** — displays event name, date, and location using data binding.
- **Event details** — dedicated details page reached via a typed route parameter.
- **Registration** — a validated registration form with a confirmation state.
- **Navigation** — `NavLink`-based routing between the event list, details, and registration pages.

## Tech Stack

- .NET 10 / C#
- Blazor WebAssembly
- Bootstrap (bundled in `wwwroot/lib`)

## Project Structure

```
EventEaseApp/
├── Components/
│   └── EventCard.razor        # Reusable event card (name, date, location)
├── Models/
│   └── Event.cs               # Event data model
├── Services/
│   └── EventService.cs        # Provides mock event data
├── Pages/
│   ├── Events.razor           # Event list (/events)
│   ├── EventDetails.razor     # Event details (/events/{id})
│   └── Registration.razor     # Registration form (/register/{id})
├── Layout/
│   ├── MainLayout.razor
│   └── NavMenu.razor          # Navigation menu
├── App.razor                  # Router configuration
└── Program.cs                 # App startup and DI registration
```

## Routes

| Page          | Route                 |
| ------------- | --------------------- |
| Home          | `/`                   |
| Events list   | `/events`             |
| Event details | `/events/{Id:int}`    |
| Registration  | `/register/{Id:int}`  |

## Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)

### Run the app

```powershell
dotnet run --project EventEaseApp\EventEaseApp.csproj
```

Then open the URL shown in the console (for example `https://localhost:5001`) and click **Events** in the navigation menu to browse, view details, and register.

### Build

```powershell
dotnet build EventEaseApp\EventEaseApp.csproj
```

## Data

Event data is currently provided as in-memory mock data via `EventService`. This can later be replaced with a real API or database without changing the components that consume it.

## Next Steps

- Add image and description fields to the event model and card.
- Persist registrations through a backend API.
- Add unit/bUnit tests for the Event Card component and routing.
