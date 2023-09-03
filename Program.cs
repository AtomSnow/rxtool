using Gtk;

class Program
{
    static void Main(string[] args)
    {
        Application.Init();

        int width = 1280;
        int height = 720;

        // Create the main window
        Window window = new Window($"rxtool");

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
            label.Text = "Button Clicked!";
        };

        window.ShowAll();
        window.DeleteEvent += (o, args) => Application.Quit(); // Close the application on window close

        Application.Run();
    }
}
