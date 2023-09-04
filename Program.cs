using Gtk;

class Program
{
    static void Main(string[] args)
    {
        Application.Init();

        string name = "rxtool";
        string ver = "0.0.0.0001";
        int width = 1280;
        int height = 720;

        // Create the main window
        Window window = new Window($"{name} {ver}");

        // Set the window's default size
        window.SetDefaultSize(width, height); 
        window.SetSizeRequest(width, height); 

        // Create a vertical box to hold the button
        Box box = new Box(Orientation.Vertical, 0);
        window.Add(box);

        // Create a label to display a message
        Label label = new Label("Click the button:");
        box.PackStart(label, false, false, 10); // Add label to the box

        // Create a button
        Button button = new Button("Click Me");
        box.PackStart(button, false, false, 10); // Add button to the box

        // Handle button click event
        button.Clicked += (sender, e) =>
        {
            /*
            var memoryPanel = new MemoryPanel();
            memoryPanel.Entries.Add(new MemoryPanelEntry(1, 98.5, "FM"));
            memoryPanel.Entries.Add(new MemoryPanelEntry(2, 102.0, "FM"));
            memoryPanel.Entries.Add(new MemoryPanelEntry(3, 107.3, "FM"));
            memoryPanel.Entries.Add(new MemoryPanelEntry(4, 540, "AM"));

            string filePath = "memorypanel.rmem";
            MemoryPanelFileHandler.SaveMemoryPanelToFile(memoryPanel, filePath);
            MemoryPanel loadedMemoryPanel = MemoryPanelFileHandler.LoadMemoryPanelFromFile(filePath);
            foreach (var entry in loadedMemoryPanel.Entries)
            {
                Console.WriteLine($"ID: {entry.Id}, Frequency: {entry.Frequency}, Data Type: {entry.DataType}");
            }
            */
            LogHandler logHandler = new LogHandler();
            logHandler.Log(LogStatus.INFO, "This is an informational message.");
        };

        window.ShowAll();
        window.DeleteEvent += (o, args) => Application.Quit(); // Close the application on window close

        Application.Run();
    }
}
