using System;
using System.IO;

public enum LogStatus
{
    ERROR,
    INFO,
    WARN
}

public class LogHandler
{
    public string logFilePath;

    public LogHandler()
    {
        string filenamedate = DateTime.Now.ToString("dd_MM_yyyy");
        logFilePath = $"rxtool_{filenamedate}.txt";
    }

    public void Log(LogStatus status, string message)
    {
        string folderPath = "./Logs/";
        if (!Directory.Exists(folderPath))
        {
            // Create the folder because it does not exist
            Directory.CreateDirectory(folderPath);
            LogHandler logHandler = new LogHandler();
            logHandler.Log(LogStatus.INFO, "Log folder created. This is probably your first time launching this program!");
        }
        Console.ForegroundColor = ConsoleColor.White;
        string statusString = Enum.GetName(typeof(LogStatus), status);
        string logMessage = $"[{DateTime.Now}] [{statusString}] → {message}";

        switch (statusString)
        {
            case "ERROR":
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case "INFO":
                Console.ForegroundColor = ConsoleColor.Blue;
                break;
            case "WARN":
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
        }

        // Print the log message to the console
        Console.WriteLine(logMessage);

        // Append the log message to the log file
        using (StreamWriter writer = new StreamWriter(folderPath + logFilePath, true))
        {
            writer.WriteLine(logMessage);
        }
    }
}
