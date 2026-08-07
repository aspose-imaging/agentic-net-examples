using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded paths
            string inputImagePath = "input.png";
            string jsonConfigPath = "config.json";
            string outputPath = "output.apng";

            // Input validation
            if (!File.Exists(inputImagePath))
            {
                Console.Error.WriteLine($"File not found: {inputImagePath}");
                return;
            }
            if (!File.Exists(jsonConfigPath))
            {
                Console.Error.WriteLine($"File not found: {jsonConfigPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load source raster image
            using (RasterImage sourceImage = (RasterImage)Image.Load(inputImagePath))
            {
                // Parse frame delays from JSON (expects an array of numbers)
                var delays = new List<uint>();
                string json = File.ReadAllText(jsonConfigPath);
                string number = "";
                foreach (char ch in json)
                {
                    if (char.IsDigit(ch))
                    {
                        number += ch;
                    }
                    else
                    {
                        if (number.Length > 0)
                        {
                            delays.Add(uint.Parse(number));
                            number = "";
                        }
                    }
                }
                if (number.Length > 0)
                {
                    delays.Add(uint.Parse(number));
                }

                // Create APNG options
                ApngOptions createOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    DefaultFrameTime = 0, // will be set per frame
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                // Create APNG image canvas
                using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, sourceImage.Width, sourceImage.Height))
                {
                    // Remove default frame
                    apngImage.RemoveAllFrames();

                    // Add frames with specific delays
                    foreach (uint delay in delays)
                    {
                        apngImage.AddFrame(sourceImage, delay);
                    }

                    // Save the APNG (output is already bound via FileCreateSource)
                    apngImage.Save();
                }
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
 * 1. When a developer wants to generate an animated PNG (APNG) whose frame timing is driven by a JSON configuration file that stores per‑frame delay values.
 * 2. When an application needs to synchronize animation speed with external data such as sensor readings or user‑defined timelines stored in JSON.
 * 3. When a game or UI designer must create a sprite sheet animation where each frame’s display duration is customized without hard‑coding values in C#.
 * 4. When a content management system must convert a static PNG into an APNG and apply variable frame delays based on metadata exported as JSON.
 * 5. When a developer is building a reporting tool that visualizes step‑by‑step processes, using JSON‑defined delays to control the pacing of each APNG frame.
 */