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
            string inputPath = "input\\source.png";
            string outputPath = "output\\animation.png";
            string configPath = "config.json";

            // Input file checks
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
            if (!File.Exists(configPath))
            {
                Console.Error.WriteLine($"File not found: {configPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load timing data from JSON (simple format: {"delays":[100,200,150]})
            List<uint> frameDelays = new List<uint>();
            string json = File.ReadAllText(configPath);
            int start = json.IndexOf('[');
            int end = json.IndexOf(']');
            if (start >= 0 && end > start)
            {
                string numbers = json.Substring(start + 1, end - start - 1);
                foreach (var part in numbers.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (uint.TryParse(part.Trim(), out uint value))
                    {
                        frameDelays.Add(value);
                    }
                }
            }

            if (frameDelays.Count == 0)
            {
                Console.Error.WriteLine("No frame delays found in configuration.");
                return;
            }

            // Load source raster image
            using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
            {
                // Create APNG options
                ApngOptions createOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                // Create APNG image canvas
                using (ApngImage apngImage = (ApngImage)Image.Create(
                    createOptions,
                    sourceImage.Width,
                    sourceImage.Height))
                {
                    // Remove default frame
                    apngImage.RemoveAllFrames();

                    // Add frames with specific delays
                    foreach (uint delay in frameDelays)
                    {
                        apngImage.AddFrame(sourceImage, delay);
                    }

                    // Save the APNG file
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
 * 1. When creating an animated PNG (APNG) for a web banner where each frame must display for a duration defined by a marketing schedule stored in a JSON file.
 * 2. When converting a single PNG sprite sheet into an APNG slideshow and need to synchronize frame timing with audio cues described in an external JSON configuration.
 * 3. When generating a product tutorial animation where the step‑by‑step delays are maintained in a JSON manifest and must be applied to each frame using Aspose.Imaging for .NET.
 * 4. When building a game UI animation that reads frame delay values from a server‑provided JSON file to ensure consistent playback across devices.
 * 5. When automating the creation of an APNG advertisement that pulls per‑frame display times from a JSON configuration to match a predefined storyboard.
 */