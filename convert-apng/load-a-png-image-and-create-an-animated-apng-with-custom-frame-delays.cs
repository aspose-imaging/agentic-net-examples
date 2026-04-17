using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output_animation.png";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists (safeguard against null/empty)
        string outputDir = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrWhiteSpace(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Load the source PNG image as a raster image
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Configure APNG creation options
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 200, // default frame duration (ms) if not overridden per frame
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create the APNG image with the same dimensions as the source
            using (ApngImage apngImage = (ApngImage)Image.Create(
                createOptions,
                sourceImage.Width,
                sourceImage.Height))
            {
                // Remove the initial frame that exists by default
                apngImage.RemoveAllFrames();

                // Define custom frame delays (in milliseconds)
                uint[] frameDelays = new uint[] { 100, 200, 300, 400, 500 };

                // Add frames with the specified delays
                foreach (uint delay in frameDelays)
                {
                    apngImage.AddFrame(sourceImage, delay);
                }

                // Save the animated APNG to the bound output file
                apngImage.Save();
            }
        }
    }
}