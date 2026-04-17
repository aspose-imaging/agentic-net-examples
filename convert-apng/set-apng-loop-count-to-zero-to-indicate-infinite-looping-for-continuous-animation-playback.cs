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
        string outputPath = "output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        string outputDir = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrWhiteSpace(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Load source raster image
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Configure APNG options with infinite looping
            ApngOptions options = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                NumPlays = 0, // 0 indicates infinite looping
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create APNG image canvas
            using (ApngImage apngImage = (ApngImage)Image.Create(options, sourceImage.Width, sourceImage.Height))
            {
                // Remove default frame and add the source frame
                apngImage.RemoveAllFrames();
                apngImage.AddFrame(sourceImage);

                // Save the APNG image
                apngImage.Save();
            }
        }
    }
}