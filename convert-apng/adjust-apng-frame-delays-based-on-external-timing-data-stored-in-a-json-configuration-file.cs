// HOW-TO: Set APNG Frame Delays From JSON File Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string sourceImagePath = "source.png";
            string jsonConfigPath = "frame_delays.json";
            string outputPath = "output_animation.apng";

            // Validate input files
            if (!File.Exists(sourceImagePath))
            {
                Console.Error.WriteLine($"File not found: {sourceImagePath}");
                return;
            }
            if (!File.Exists(jsonConfigPath))
            {
                Console.Error.WriteLine($"File not found: {jsonConfigPath}");
                return;
            }

            // Parse frame delays from JSON (expects an array of numbers)
            List<uint> frameDelays = new List<uint>();
            string json = File.ReadAllText(jsonConfigPath);
            int start = json.IndexOf('[');
            int end = json.IndexOf(']', start);
            if (start >= 0 && end > start)
            {
                string numbers = json.Substring(start + 1, end - start - 1);
                foreach (var part in numbers.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (uint.TryParse(part.Trim(), out uint value))
                        frameDelays.Add(value);
                }
            }

            if (frameDelays.Count == 0)
            {
                Console.Error.WriteLine("No frame delays found in configuration.");
                return;
            }

            // Load source raster image
            using (RasterImage sourceImage = (RasterImage)Image.Load(sourceImagePath))
            {
                // Create APNG with desired options
                ApngOptions createOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                using (ApngImage apngImage = (ApngImage)Image.Create(
                    createOptions,
                    sourceImage.Width,
                    sourceImage.Height))
                {
                    apngImage.RemoveAllFrames();

                    // Add frames with individual delays
                    foreach (uint delay in frameDelays)
                    {
                        apngImage.AddFrame(sourceImage, delay);
                    }

                    // Ensure output directory exists
                    string outputDir = Path.GetDirectoryName(outputPath);
                    if (!string.IsNullOrWhiteSpace(outputDir))
                    {
                        Directory.CreateDirectory(outputDir);
                    }

                    // Save the APNG
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
 * 1. When you need to synchronize an animated PNG with audio or video cues, you can read precise frame‑delay values from a JSON file and apply them using Aspose.Imaging in C#.
 * 2. When a game developer wants to adjust the speed of sprite animations dynamically based on level data stored in JSON, this code shows how to rebuild the APNG with custom delays.
 * 3. When an e‑learning platform must match slide transition timings defined in a configuration file, the example demonstrates loading those timings and updating the APNG frames accordingly.
 * 4. When a marketing team requires different animation pacing for A/B testing and stores the timing parameters in JSON, the snippet lets you generate separate APNGs with the specified delays.
 * 5. When a CI/CD pipeline needs to regenerate animated assets after a data‑driven timing change, the code provides a programmatic way to read the new delays and produce an updated APNG automatically.
 */
