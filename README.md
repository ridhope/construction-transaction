# Construction API Transaction 
The Construction API Transaction is an API application designed to help manage construction projects. It provides features for managing projects, users, and various other aspects of construction management. It is built using dotnet.

## Features

- **Project Management**: Create, edit, and delete construction projects.
- **User Management**: Add, edit, and delete users.
- **Reporting**: Generate reports related to projects and users.
- **Security**: User authentication and authorization.

## Installation

1. Clone this repository:
```sh
git clone https://github.com/ridhope/construction-transaction.git
```

2. Navigate to the project directory:
```sh
cd construction-transaction
```

3. Restore dependencies:
```sh
dotnet restore
```

4. Run startwithme.sql on PostgreSQL

5. Build the project:
```sh
dotnet build
```

## Running the Application

To run the application, use the following command:
```sh
dotnet run
```

## Running Tests

To run unit tests, use the following command:

```sh
dotnet test
```

## Configuration

Before running the application, you need to update the configuration file with the necessary settings. Follow these steps:

1. Open the `appsettings.json` file located in the project directory.

2. Update the following configuration settings:

    - `DatabaseConnectionString`: Replace with the connection string for your database.
    - `EmailSettings`: Update the email server settings, including SMTP server, port, username, and password.
    - `OtherSettings`: Modify any other settings specific to your environment.

3. Save the changes to the `appsettings.json` file.

Once you have updated the configuration settings, you can proceed with running the application using the `dotnet run` command.



