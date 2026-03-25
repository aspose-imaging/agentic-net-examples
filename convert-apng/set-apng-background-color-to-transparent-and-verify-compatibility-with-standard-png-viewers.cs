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
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source raster image
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Configure APNG options with alpha channel support
            ApngOptions options = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                ColorType = PngColorType.TruecolorWithAlpha,
                DefaultFrameTime = 100 // milliseconds per frame
            };

            // Create APNG image bound to the output file
            using (ApngImage apng = (ApngImage)Image.Create(options, sourceImage.Width, sourceImage.Height))
            {
                // Set transparent background
                apng.HasBackgroundColor = false;
                apng.BackgroundColor = Color.Transparent;

                // Remove any default frame
                apng.RemoveAllFrames();

                // Add a single frame (additional frames can be added similarly)
                apng.AddFrame(sourceImage);

                // Save the APNG (output path already bound)
                apng.Save();
            }
        }
    }
}