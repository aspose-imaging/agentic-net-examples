using System;
using System.IO;
using System.Linq;
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
            string inputPath = "input.png";
            string jsonPath = "config.json";
            string outputPath = "output\\animation.apng";

            // Input validation
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
            if (!File.Exists(jsonPath))
            {
                Console.Error.WriteLine($"File not found: {jsonPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load source raster image
            using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
            {
                // Read and parse JSON configuration for frame delays
                string jsonContent = File.ReadAllText(jsonPath);
                List<uint> frameDelays = jsonContent
                    .Split(new char[] { '[', ']', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Trim())
                    .Where(s => uint.TryParse(s, out _))
                    .Select(s => uint.Parse(s))
                    .ToList();

                // Fallback to a default delay if none provided
                if (frameDelays.Count == 0)
                {
                    frameDelays.Add(100); // 100 ms default
                }

                // Create APNG options with output binding
                ApngOptions createOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    ColorType = PngColorType.TruecolorWithAlpha,
                    DefaultFrameTime = 0 // will be overridden per frame
                };

                // Create APNG image canvas
                using (ApngImage apngImage = (ApngImage)Image.Create(
                    createOptions,
                    sourceImage.Width,
                    sourceImage.Height))
                {
                    // Remove the default frame
                    apngImage.RemoveAllFrames();

                    // Add frames with specific delays
                    foreach (uint delay in frameDelays)
                    {
                        apngImage.AddFrame(sourceImage, delay);
                    }

                    // Save the APNG (output already bound)
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