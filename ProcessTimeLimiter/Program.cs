using System.Diagnostics;

// Check if process name and timeout are provided as command line parameters
if (args.Length < 2)
{
    ShowHelp();
    return;
}

string processName = args[0];
if (!int.TryParse(args[1], out int timeLimit) || timeLimit <= 0)
{
    Console.WriteLine("Error: Please provide a valid timeout value greater than 0.");
    ShowHelp();
    return;
}

Console.WriteLine($"Monitoring process: {processName} with timeout of {timeLimit} seconds.");

while (true)
{
    // Get the list of running processes with the specified name
    Process[] processes = Process.GetProcessesByName(processName);

    if (processes.Length > 0)
    {
        foreach (var process in processes)
        {
            // Calculate the running time of the process
            TimeSpan runningTime = DateTime.Now - process.StartTime;

            // If the process has been running longer than the specified timeout, kill it
            if (runningTime.TotalSeconds > timeLimit)
            {
                Console.WriteLine($"Killing process {processName} (PID: {process.Id}) after running for {runningTime.TotalSeconds} seconds.");
                process.Kill();
            }
        }
    }

    // Wait for 1 second before checking again
    Thread.Sleep(1000);
}

// Method to show help message
static void ShowHelp()
{
    Console.WriteLine("Usage: ProcessTimeLimiter <processName> <timeoutInSeconds> [Minimized]");
    Console.WriteLine();
    Console.WriteLine("<processName>        The name of the process to monitor (without .exe).");
    Console.WriteLine("<timeoutInSeconds>   The time limit in seconds before the process is terminated.");
    Console.WriteLine();
    Console.WriteLine("Example:");
    Console.WriteLine("  ProcessTimeLimiter notepad 600 Minimized");
    Console.WriteLine("This will monitor 'notepad' and kill it after 600 seconds.");
}
