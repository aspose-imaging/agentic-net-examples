using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputImagePath = "input.png";
            string jsonConfigPath = "config.json";
            string outputPath = "output\\animation.apng";

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

            // Parse frame durations from JSON (expected format: {"frames":[100,200,150]})
            string json = File.ReadAllText(jsonConfigPath);
            int bracketStart = json.IndexOf('[');
            int bracketEnd = json.IndexOf(']');
            List<uint> frameDurations = new List<uint>();
            if (bracketStart >= 0 && bracketEnd > bracketStart)
            {
                string numbers = json.Substring(bracketStart + 1, bracketEnd - bracketStart - 1);
                string[] parts = numbers.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string part in parts)
                {
                    if (uint.TryParse(part.Trim(), out uint value))
                    {
                        frameDurations.Add(value);
                    }
                }
            }

            if (frameDurations.Count == 0)
            {
                Console.Error.WriteLine("No frame durations found in configuration.");
                return;
            }

            // Load source raster image
            using (RasterImage sourceImage = (RasterImage)Image.Load(inputImagePath))
            {
                // Create APNG options
                ApngOptions createOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    ColorType = PngColorType.TruecolorWithAlpha,
                    DefaultFrameTime = 0 // will be overridden per frame
                };

                // Create APNG image bound to output file
                using (ApngImage apngImage = (ApngImage)Image.Create(
                    createOptions,
                    sourceImage.Width,
                    sourceImage.Height))
                {
                    // Remove the default initial frame
                    apngImage.RemoveAllFrames();

                    // Add frames with specific durations
                    foreach (uint frameTime in frameDurations)
                    {
                        apngImage.AddFrame(sourceImage, frameTime);
                    }

                    // Save the APNG (output already bound via FileCreateSource)
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