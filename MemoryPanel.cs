using System;
using System.Collections.Generic;
using System.IO;

class MemoryPanelEntry
{
    public int Id { get; set; }
    public double Frequency { get; set; }
    public string DataType { get; set; }

    public MemoryPanelEntry(int id, double frequency, string dataType)
    {
        Id = id;
        Frequency = frequency;
        DataType = dataType;
    }
}

class MemoryPanel
{
    public List<MemoryPanelEntry> Entries { get; set; }

    public MemoryPanel()
    {
        Entries = new List<MemoryPanelEntry>();
    }
}

class MemoryPanelFileHandler
{
    public static void SaveMemoryPanelToFile(MemoryPanel memoryPanel, string filePath)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var entry in memoryPanel.Entries)
                {
                    writer.WriteLine($"{entry.Id},{entry.Frequency},{entry.DataType}");
                }
            }

            Console.WriteLine($"MemoryPanel saved to {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving MemoryPanel: {ex.Message}");
        }
    }

    public static MemoryPanel LoadMemoryPanelFromFile(string filePath)
    {
        var memoryPanel = new MemoryPanel();

        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 3 &&
                        int.TryParse(parts[0], out int id) &&
                        double.TryParse(parts[1], out double frequency))
                    {
                        string dataType = parts[2];
                        memoryPanel.Entries.Add(new MemoryPanelEntry(id, frequency, dataType));
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading MemoryPanel: {ex.Message}");
        }

        return memoryPanel;
    }
}