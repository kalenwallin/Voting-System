# CSCE 361 Capstone Project - Voting System
<img align="right" src="https://i.imgur.com/qQfjxe2.png" width=45% height=45%>
Author: Kalen Wallin

Developers: Kalen Wallin, Jayden Carlon, Cameron Collingham, Thomas Walton, Joshua Bellmyer

## About
The Voting System is a web appplication created by a group of software engineering students at the University of Nebraska-Lincoln.

## Features
- The main feature of the Voting System is the ability to vote. After voting, a user can view their ballot. After an election, a user can view the results.
- Users must create an account and log in before accessing a ballot.
- Ballots contain multiple electoral races and an issue to vote on.
- A public voter list is made avaible to any third party to view who has or hasn't voted. However, that third party will not be able to view *whom* they have voted for.
- Client-side Form Validation:
  - Email: Must be between 8 and 60 characters and contain an '@' symbol.
  - Password: Must be between 5 and 20 characters. While creating an account, you must type the same password twice.
  - Full Name: Must be between 5 and 20 characters.
  - Ballot: An option must be selected for each race.
- Elections and ballots inaccessible unless signed in.

## Getting started
1. Clone the repository
2. Open the solution file
3. Press the play button at the top of the IDE (IIS Express/Voting System)
4. Create an account/log in
5. Select an election.
6. Vote
7. Press continue and select the same election to view your race selections.
8. Sign out when finished.

## Public Voter List Instructions
1. Click on Public Voter List in the Navigation bar. (No account required)
2. View whether a voter has voted on the ongoing election.
(Green if a user has voted/Red if a user hasn't voted)

## Development Tools
- Visual Studio, .NET Framework, ASP.NET Core 3.1, Razor Pages
- Languages: HTML, CSS, C#, and Javascript.
- Operating System: Windows
- Testing Framework: MSTest

## Database
- Entity Framework Core
- Uses LINQ to query data, prevent attacks
- SQL Server/Local DB

## Design
- Model-View-Controller
  - Razor pages has a view (UI) and a controller to handle input from the user and output information from the database (Model)
  - There are additional controllers to separate concerns of each class (User, Election, Ballot, Issue).

## Testing
- MSTest Unit Tests for Elections, Issues, Candidates, Users, and Ballot controllers.
- Visual Studio Test Runner to run and display test results.

## Contributing
This is a private repository with respect to the University of Nebraska-Lincoln's Academic Integrity Policy. There shall be no contributions from anyone outside of our private group.

## Additional Notes
Everything that happens to the GitHub Repository will be sent to the discord server in the channel *#git-commit-log*
