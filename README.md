# Municipal Services Application

# Part 1
This is a C# Windows Forms application built for a South African municipality. It allows citizens to report service issues (like sanitation, roads, and utilities problems) through a simple interface.

This is Part 1 of the project. Only the "Report Issues" feature has been implemented. "Local Events and Announcements" and "Service Request Status" are disabled for now and will be added in a later part of the project.

## Table of Contents

- How to Compile
- How to Run
- How to Use
- Data Storage
- Project Structure
- Known Limitations

## How to Compile

1. Open MunicipalServicesApp.sln in Visual Studio 2022.
2. Make sure the required .NET SDK/Framework is installed on your machine.
3. Build the solution using Build > Build Solution, or press Ctrl+Shift+B.
4. Check the Error List to confirm the build succeeded with 0 errors.

## How to Run

Option A : From Visual Studio:
Press F5 to launch the application in Debug mode.

Option B : From the compiled executable:
Go to MunicipalServicesApp\bin\Debug\ and run MunicipalServicesApp.exe directly.

## How to Use

When the application starts, the Main Menu opens with four options:

- Report Issues (enabled)
- View Reported Issues (enabled)
- Local Events and Announcements (disabled, coming later)
- Service Request Status (disabled, coming later)

### Reporting an Issue

1. Click "Report Issues".
2. Type in the Location of the issue.
3. Select a Category from the dropdown (e.g. Sanitation, Roads, Utilities).
4. Type a Description of the issue.
5. Optionally, click "Attach Image/Document" to attach a photo or file. If you choose an image file (.jpg, .jpeg, or .png), a preview will show up. If nothing is attached, the app will say "No picture attached."
6. As you fill in the form, a progress bar and short message update to show how far along you are.
7. Click "Submit" once everything is filled in.
8. A "Thank You" screen appears showing a summary of your report. From there you can either go back to the Main Menu or view all reported issues.

### Viewing Reported Issues

1. Click "View Reported Issues" from the Main Menu (or from the Thank You screen).
2. Click on any issue in the list to see its full details: location, category, description, and file name.
3. If an image was attached, it will be shown in the preview box. If not, it will say "No file was uploaded."
4. Click "Back to Main Menu" to return.

### Navigation

Every screen has a way to get back to the Main Menu. Closing the Main Menu window closes the whole application.

## Data Storage

Reported issues are stored in memory while the app is running, using a List<Issue> (see IssueManager.cs). Each Issue object (see Issue.cs) stores the location, category, description, attached file path, and the date and time it was reported.

Note: the data is not saved to disk. All reports are lost once the application is closed.

## Project Structure

| File | Description |
|---|---|
| Form1.cs | Main Menu |
| ReportIssuesForm.cs | Report Issues form |
| ViewIssuesForm.cs | View Reported Issues form |
| ThankYouForm.cs | Confirmation screen shown after submitting a report |
| Issue.cs | Data model for a single reported issue |
| IssueManager.cs | Stores the list of all reported issues |
| AppTheme.cs | Shared colours, fonts, and styling used across the app |
| Resources.resx | Icon images used in the interface |

## Known Limitations

- Local Events and Announcements and Service Request Status are not implemented yet and are disabled.
- Reported issues are not saved permanently, they are lost when the app closes.


# Part 2: Local Events and Announcements

## 1. What was added in Part 2

Part 2 adds a new **Local Events and Announcements** page to the Municipal Services Application. The page can be opened from the main menu. The "Local Events and Announcements" option was disabled ("Coming soon") in Part 1 and is now enabled.

The new page has these features:

- A list of **upcoming local events**, shown in date order with the date, time, event name, category and location.
- A **search bar** to find events by keyword, by category and by date.
- An **event details** box that shows the full information of the selected event.
- An **announcement banner** at the top that shows the most urgent announcement first.
- A **Recommended for you** box that suggests events and shows the reason for each suggestion.
- A **Recently viewed** box that lists the events the user opened.

## 2. Requirements, how to compile and how to run

Requirements are the same as Part 1:

- Windows 10 or Windows 11
- Visual Studio 2022 with the **.NET desktop development** workload
- .NET 6 or later (the program uses `PriorityQueue`, which needs .NET 6 or later)

**To compile:**

1. Open the folder and double-click **MunicipalServicesApp.sln**.
2. In the menu choose **Build** and then **Build Solution** (or press **Ctrl + Shift + B**).
3. The Output window must end with `Build: 1 succeeded, 0 failed`.

**To run:**

1. Press **F5**. The main menu opens.
2. Click **Local Events and Announcements**. The new page opens.

## 3. How to use the Local Events and Announcements page

### Announcement banner

- The banner at the top shows the **most urgent announcement**. Each announcement has a priority, and the banner has its own colour for urgent announcements (red).
- The button on the right (for example **Next (3 more)**) shows the next announcement.

### Searching for events

| Control | What it does |
|---|---|
| **Search** box | Finds events that contain the typed words. Earlier searches are suggested as you type. |
| **Category** list | Shows only events in the chosen category. **All categories** shows every event. |
| **Filter by date** tick box and date picker | Shows only the events on the chosen day. Tick the box to switch the date filter on. |
| **Search** button (or the Enter key) | Runs the search. |
| **Clear** button | Removes the search words, category and date filter and shows all events again. |

The message under the list shows how many events were found, for example `12 event(s) found`.

### Event details

Click an event in the list. The **Event details** box on the right shows its name, date and time, location, category and description.

### Recommended for you

The **Recommended for you** box suggests events the user may like. Each suggestion shows the event name, the date and the reason, for example **More Culture events**. The suggestions change when the user searches or opens events. Click a suggestion to see its details.

### Recently viewed

The **Recently viewed** box lists the events the user opened, with the newest event at the top. Click an event in this list to see its details again.

### Back to the main menu

Click **Back to Menu** to go back to the main menu. The window can be minimised, maximised and made bigger or smaller.

## 4. Data structures used

All the data structures are in `EventManager.cs`.

| Data structure | What it is used for |
|---|---|
| `SortedDictionary<DateTime, List<EventItem>>` | Keeps the events grouped by date. Going through it gives the events in date order. |
| `Dictionary<int, EventItem>` | Stores every event by its id so events can be found and looped through quickly. |
| `Dictionary<string, int>` | Counts how much the user is interested in each category and search word. Used for recommendations. |
| `HashSet<string>` | Keeps each event category once only. Fills the **Category** list. |
| `SortedSet<DateTime>` | Keeps each event date once only, in order. Used for the date picker and to find the next date with events. |
| `PriorityQueue<Announcement, int>` | Stores the announcements so the most urgent one always comes out first. |
| `Queue<string>` | Remembers the last searches (first in, first out) for the search suggestions. |
| `Stack<EventItem>` | Remembers the events the user opened (last in, first out) for **Recently viewed**. |

## 5. How the recommendation feature works

1. When the user **searches**, the program remembers the words and the category that were used. It counts them in dictionaries.
2. When the user **opens an event**, the program remembers it on a stack (the newest event is on top) and counts its category.
3. If the user has opened an event, the page suggests other upcoming events from the **same category** as the event that is open. Events that match the user's earlier search words are ranked higher.
4. If the user has only searched and has not opened an event yet, the page uses the counted search words and categories to suggest events.
5. Each suggestion shows the reason under it, for example **More Sports events**. When the event also matches a search word, the reason adds that word, for example **More Sports events | matches "charity"**.

Example: when the user opens the **Charity Fun Run** (Sports), the page recommends the **Youth Soccer Tournament**, because it is also a Sports event.

The page only leaves out the event that is open at that moment, so an event that was opened earlier can be recommended again.

## 6. Sample data

The program starts with 12 sample events and 4 announcements, which are created in `EventManager.cs`. The event dates are worked out from today's date, so there are always upcoming events when the program runs. This means the dates on the screen change from day to day.

## 7. Suggested test steps

1. Run the application and open **Local Events and Announcements**. The list shows 12 events and the banner shows the red urgent announcement.
2. Type `Charity` in the **Search** box and click **Search**. Only the **Charity Fun Run** is shown. Click it. The **Recommended for you** box suggests another Sports event, the **Youth Soccer Tournament**.
3. Click **Clear**. Choose the category **Culture** and click **Search**. Two events are shown: the **Heritage Day Cultural Market** and the **Community Jazz Evening**.
4. Click **Clear**. Tick **Filter by date**, pick the date of the first event in the list, and click **Search**. Only the events on that day are shown.
5. Click **Clear**. Click any event in the list. Its details are shown in the **Event details** box, and the event is added to **Recently viewed**.
6. Click the button on the right of the banner. The next announcement is shown.
7. Click **Back to Menu**. The main menu opens again.

## 8. Files for Part 2

| File | Purpose |
|---|---|
| `EventItem.cs` | The `EventItem` and `Announcement` classes. |
| `EventManager.cs` | Holds the events and announcements, all the data structures, the search and the recommendation logic. |
| `LocalEventsForm.cs` and `LocalEventsForm.Designer.cs` | The Local Events and Announcements page. |
| `Form1.cs` | Changed so the Local Events and Announcements button is enabled and opens the new page. |

## 9. Limitations

- The events, announcements, searches and viewed events are only kept in memory. They are lost when the application is closed.
- Users cannot add their own events or announcements yet.
- **Service Request Status** will be added in a later part.

## 10. Troubleshooting

| Problem | Fix |
|---|---|
| `PriorityQueue` cannot be found | Right-click the project, choose **Properties** and set **Target framework** to **.NET 8.0** (or .NET 6.0). |
| The dates on the screen are different from the screenshots | This is normal. The sample dates are created from today's date. |
