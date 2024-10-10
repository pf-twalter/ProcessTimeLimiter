# ProcessTimeLimiter

**ProcessTimeLimiter** is a simple C# console application that monitors a specified process and terminates it if it runs longer than a given time limit. This is useful for managing system resources and preventing runaway processes.

## Features

- Monitors the specified process by name.
- Terminates the process if it exceeds the defined runtime limit.
- Configurable timeout parameter for flexible usage.
- User-friendly help message in case of incorrect usage.
- **One-File Application** for easy distribution.

## Requirements

- .NET 8 SDK or later.
- Windows operating system (for process monitoring, although it may run on other platforms).

## Installation

1. Clone this repository or download the ZIP file.

   ```bash
   git clone <repository-url>
   ```

2. Navigate to the project directory.

   ```bash
   cd ProcessTimeLimiter
   ```

3. Restore dependencies (if necessary) and build the project.

   ```bash
   dotnet build
   ```

## Creating a One-File Application

To publish the application as a one-file executable, use the following command:

```bash
dotnet publish -c Release -r win-x64 -p:PublishSingleFile=true --self-contained
```

### Parameters:

- **`-c Release`**: Publiziert die Anwendung im Release-Modus.
- **`-r win-x64`**: Gibt die Zielplattform an (Windows 64-Bit).
- **`-p:PublishSingleFile=true`**: Stellt sicher, dass die Anwendung in eine einzige Datei gepackt wird.
- **`--self-contained`**: Stellt sicher, dass die Anwendung alle benötigten .NET-Abhängigkeiten enthält.

### Output

Nach dem erfolgreichen Ausführen des Befehls findest du die ausführbare Datei im Verzeichnis:

```
bin\Release\net8.0\win-x64\publish\
```

## Usage

To run the application, use the following command format:

```bash
ProcessTimeLimiter.exe <processName> <timeoutInSeconds>
```

### Parameters

- **`processName`**: The name of the process to monitor (without the `.exe` extension).
- **`timeoutInSeconds`**: The time limit in seconds after which the process will be terminated.

### Example

To monitor the process `notepad` and terminate it after 600 seconds (10 minutes):

```bash
ProcessTimeLimiter.exe notepad 600
```

### Help

If you run the application without the required parameters or provide invalid parameters, it will display a help message:

```plaintext
Usage: ProcessTimeLimiter <processName> <timeoutInSeconds>

<processName>        The name of the process to monitor (without .exe).
<timeoutInSeconds>   The time limit in seconds before the process is terminated.

Example:
  ProcessTimeLimiter notepad 600
This will monitor 'notepad' and kill it after 600 seconds.
```

## Contributing

Contributions are welcome! Please open an issue or submit a pull request for any improvements or bug fixes.
