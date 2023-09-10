# TLF
This is a simple console application written in C# .NET Core that interacts with the TfL (Transport for London) Road Status API. 
The application allows users to query road status information based on a road ID.

## Table of Contents

- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Configuration](#configuration)
- [Usage](#usage)
- [Testing](#testing)


## Prerequisites

Before running this application, ensure you have the following installed:

- Visual Studio 
- .NET Core SDK 
- An active TfL API developer key (App ID and API Key)

## Installation

1. Clone this repository or download the source code.
2. Open the solution file (`TransportForLondon.RoadStatusChecker.sln`) in Visual Studio.
3. Build the solution in Visual Studio.

## Configuration

You can configure the application to use your TfL developer key (App ID and API Key) in the `appsettings.json` file within the project. 
Replace the placeholders `YOUR_APP_ID` and `YOUR_API_KEY` with your actual credentials.

## Usage

To query road status information, follow these steps:

1. Locate the executable file in the "bin" directory of the project.
2. Open a command prompt or terminal.
3. Navigate to the "bin" directory where the executable is located.
4. Set the valid road ID as an argument for the executable.
5. Run the executable.

For example:

1. Locate the `RoadStatus.exe` executable in the "bin" directory.
2. Open a command prompt.
3. Navigate to the "bin" directory.
4. Run the following command:

```bash
RoadStatus.exe A2
```

## Testing

This application includes unit tests and E2E Tests. You can run the tests using Visual Studio's built-in test runner.
The end-to-end (E2E) test requires the configuration of `YOUR_APP_ID` and `YOUR_API_KEY` for it to function correctly.

