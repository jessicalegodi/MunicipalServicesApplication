Municipal Services Application

 Part 1

A C# Windows Forms application designed to allow residents to report municipal service delivery issues.

Features

- Municipal Services Main Menu
- Report Issues functionality
- Location input
- Issue category selection
- Detailed issue description
- Image/document attachment
- OpenFileDialog
- Progress indicator
- Dynamic progress messages
- Form validation
- Error messages
- Successful submission confirmation
- List-based storage of reported issues
- Back to Main Menu navigation
- Exit functionality

 Technologies

- C#
- Windows Forms
- .NET Framework 4.8
- Visual Studio
- GitHub

Issue Categories

The application supports:

- Roads
- Water
- Electricity
- Sanitation
- Waste Management
- Street Lighting
- Public Safety
- Other

 User Engagement Strategy

The selected user engagement strategy is a Progress Indicator.

The progress indicator shows the user how far they have progressed when completing a municipal issue report.

Progress is updated when the user:

1. Enters a location
2. Selects a category
3. Enters a description
4. Attaches supporting evidence

Data Structure

The application uses a `List<Issue>` to store reported municipal issues.

Each issue contains:

- Issue ID
- Location
- Category
- Description
- Attachment
- Date Reported

 Validation

The application checks that the required information has been entered before allowing a report to be submitted.

The following validation messages are provided:

- Please enter the location of the issue.
- Please select an issue category.
- Please provide a detailed description of the issue.

Running the Application

The solution can be opened in Visual Studio using the `.sln` file.

Build the solution and run the application.

 Part 1 Scope

The following features are implemented in Part 1:

- Report Issues

The following features are disabled because they are planned for later parts:

- Local Events and Announcements
- Service Request Status
