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

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load source raster image
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Configure APNG creation options
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 200,               // Default frame duration (ms)
                NumPlays = 5,                         // Number of animation loops (0 = infinite)
                ColorType = PngColorType.TruecolorWithAlpha,
                KeepMetadata = true                   // Preserve source metadata
            };

            // Create APNG image bound to the output file
            using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, sourceImage.Width, sourceImage.Height))
            {
                // Remove the automatically added first frame
                apngImage.RemoveAllFrames();

                // Add frames with specific timings
                apngImage.AddFrame(sourceImage, createOptions.DefaultFrameTime); // Frame 1 using default time
                apngImage.AddFrame(sourceImage, 500);                            // Frame 2 with 500 ms
                apngImage.AddFrame(sourceImage, 1000);                           // Frame 3 with 1000 ms

                // Save the APNG (output path already bound via FileCreateSource)
                apngImage.Save();
            }
        }
    }
}