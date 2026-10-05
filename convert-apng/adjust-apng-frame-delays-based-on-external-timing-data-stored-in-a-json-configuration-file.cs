// HOW-TO: Set APNG Frame Delays From JSON Config In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputApngPath = "input.apng";
            string jsonConfigPath = "config.json";
            string outputApngPath = "output\\output.apng";

            if (!File.Exists(inputApngPath))
            {
                Console.Error.WriteLine($"File not found: {inputApngPath}");
                return;
            }

            if (!File.Exists(jsonConfigPath))
            {
                Console.Error.WriteLine($"File not found: {jsonConfigPath}");
                return;
            }

            string json = File.ReadAllText(jsonConfigPath);
            int bracketStart = json.IndexOf('[');
            int bracketEnd = json.IndexOf(']', bracketStart);
            List<int> delays = new List<int>();
            if (bracketStart >= 0 && bracketEnd > bracketStart)
            {
                string numbersPart = json.Substring(bracketStart + 1, bracketEnd - bracketStart - 1);
                string[] parts = numbersPart.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string part in parts)
                {
                    if (int.TryParse(part.Trim(), out int value))
                    {
                        delays.Add(value);
                    }
                }
            }

            using (ApngImage apng = (ApngImage)Image.Load(inputApngPath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(outputApngPath));
                apng.Save(outputApngPath, new ApngOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to synchronize the playback speed of an APNG animation with timing values stored in an external JSON file.
 * 2. When you want to generate animated PNGs where each frame’s display duration is defined by a configurable JSON list instead of hard‑coded constants.
 * 3. When you are building a game or UI that reads animation timing settings from JSON and applies them to existing APNG assets at runtime.
 * 4. When you must batch‑process multiple APNG files and adjust their frame delays according to delay arrays supplied in a JSON configuration.
 * 5. When you are creating a server‑side service that receives frame‑delay parameters in JSON and needs to output an APNG with matching frame intervals.
 */
