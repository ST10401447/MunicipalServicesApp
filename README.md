# Municipal Services Application

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


