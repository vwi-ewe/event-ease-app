# EventEase

EventEase is a Blazor WebAssembly front-end for a fictional event-management company. It lets users browse fun events (celebrations, concerts, and custom events) held across Denmark, view event details, register with a validated form, and track their attendance — with clean navigation between pages.

This project was built as a course assignment demonstrating how to accelerate Blazor development with GitHub Copilot. See [docs/COPILOT-SUMMARY.md](docs/COPILOT-SUMMARY.md) for how Copilot assisted at each stage.

## Features

- **Event browsing** — a virtualized, responsive list of Danish events rendered with a reusable Event Card component.
- **Reusable Event Card component** — displays event name, date, and location using data binding, with null/invalid-data guards.
- **Event details** — dedicated details page reached via a typed route parameter.
- **Registration form with validation** — name, email, and optional phone validated with `DataAnnotations` and inline messages.
- **User session tracking** — a singleton `UserSessionService` keeps the signed-in user and their registrations in sync across pages.
- **Attendance tracker** — check in/out of registered events, cancel registrations, and view live counts.
- **Performance** — the event list uses Blazor's `Virtualize` for smooth rendering of large datasets.
- **Graceful error handling** — invalid routes and unknown event ids resolve to friendly Not Found states.
- **Colorful theme** — light pink, green, purple, and yellow accents (content stays in English).
- **Navigation** — `NavLink`-based routing between the event list, details, registration, and attendance pages.

## Tech Stack

- .NET 10 / C#
- Blazor WebAssembly
- Bootstrap (bundled in `wwwroot/lib`)

## Project Structure

```
EventEaseApp/
├── Components/
│   └── EventCard.razor        # Reusable event card (name, date, location) + accent colors
├── Models/
│   ├── Event.cs               # Event data model with validation
│   ├── RegistrationModel.cs   # Validated registration form model
│   └── UserSession.cs         # Session + Attendee (attendance) models
├── Services/
│   ├── EventService.cs        # Provides mock event data
│   └── UserSessionService.cs  # Session state management (singleton)
├── Pages/
│   ├── Events.razor           # Event list (/events), virtualized
│   ├── EventDetails.razor     # Event details (/events/{id})
│   ├── Registration.razor     # Registration form (/register/{id})
│   ├── Attendance.razor       # Attendance tracker (/attendance)
│   └── NotFound.razor         # Friendly not-found page
├── Layout/
│   ├── MainLayout.razor
│   └── NavMenu.razor          # Navigation menu + current user
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
| Attendance    | `/attendance`         |

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

## Data & State

Event data is provided as in-memory mock data via `EventService` (fun events set across Denmark). User sessions and attendance are held in memory by the singleton `UserSessionService`. Both can later be replaced with a real API or database without changing the components that consume them.

## Next Steps

- Persist the user session across browser refresh (e.g., `localStorage`).
- Add image and description fields to the event model and card.
- Persist registrations through a backend API.
- Add unit/bUnit tests for the Event Card, registration validation, and routing.
