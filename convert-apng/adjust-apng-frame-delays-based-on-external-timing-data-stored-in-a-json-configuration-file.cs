using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded paths
        string inputImagePath = "input.png";
        string jsonConfigPath = "config.json";
        string outputPath = "output.apng";

        // Validate input files
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
        string outputDir = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrWhiteSpace(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Read and parse frame times from JSON (simple numeric extraction)
        string jsonContent = File.ReadAllText(jsonConfigPath);
        List<uint> frameTimes = new List<uint>();
        string numberBuffer = "";
        foreach (char ch in jsonContent)
        {
            if (char.IsDigit(ch))
            {
                numberBuffer += ch;
            }
            else
            {
                if (numberBuffer.Length > 0)
                {
                    if (uint.TryParse(numberBuffer, out uint value))
                    {
                        frameTimes.Add(value);
                    }
                    numberBuffer = "";
                }
            }
        }
        if (numberBuffer.Length > 0 && uint.TryParse(numberBuffer, out uint lastValue))
        {
            frameTimes.Add(lastValue);
        }

        if (frameTimes.Count == 0)
        {
            Console.Error.WriteLine("No frame times found in configuration.");
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
                DefaultFrameTime = frameTimes[0] // fallback default
            };

            // Create APNG image canvas
            using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, sourceImage.Width, sourceImage.Height))
            {
                // Remove the default initial frame
                apngImage.RemoveAllFrames();

                // Add frames with specific durations
                foreach (uint frameTime in frameTimes)
                {
                    apngImage.AddFrame(sourceImage, frameTime);
                }

                // Save the APNG
                apngImage.Save();
            }
        }
    }
}