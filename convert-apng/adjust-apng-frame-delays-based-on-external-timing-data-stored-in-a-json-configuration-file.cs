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
        // Hardcoded paths
        string inputImagePath = "input.png";
        string jsonConfigPath = "config.json";
        string outputPath = "output\\animation.apng";

        // Validate input image
        if (!File.Exists(inputImagePath))
        {
            Console.Error.WriteLine($"File not found: {inputImagePath}");
            return;
        }

        // Validate JSON config
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
            // Read and parse JSON configuration (expects an array of integers)
            string json = File.ReadAllText(jsonConfigPath);
            List<uint> frameTimes = new List<uint>();
            string numberBuffer = "";
            foreach (char c in json)
            {
                if (char.IsDigit(c))
                {
                    numberBuffer += c;
                }
                else
                {
                    if (numberBuffer.Length > 0)
                    {
                        if (uint.TryParse(numberBuffer, out uint value))
                            frameTimes.Add(value);
                        numberBuffer = "";
                    }
                }
            }
            if (numberBuffer.Length > 0 && uint.TryParse(numberBuffer, out uint lastValue))
                frameTimes.Add(lastValue);

            // Create APNG options
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                ColorType = PngColorType.TruecolorWithAlpha,
                DefaultFrameTime = frameTimes.Count > 0 ? frameTimes[0] : (uint)100
            };

            // Create APNG image canvas
            using (ApngImage apngImage = (ApngImage)Image.Create(
                createOptions,
                sourceImage.Width,
                sourceImage.Height))
            {
                // Remove the default frame
                apngImage.RemoveAllFrames();

                // Add frames with specific durations
                foreach (uint ft in frameTimes)
                {
                    apngImage.AddFrame(sourceImage, ft);
                }

                // If no frame times were provided, add a single default frame
                if (frameTimes.Count == 0)
                {
                    apngImage.AddFrame(sourceImage);
                }

                // Save the APNG file
                apngImage.Save();
            }
        }
    }
}