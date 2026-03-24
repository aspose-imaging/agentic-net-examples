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
        string outputPath = "output/output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image as a RasterImage
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Configure APNG creation options
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 100, // default frame duration in milliseconds
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create an APNG image bound to the output file
            using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, sourceImage.Width, sourceImage.Height))
            {
                // Remove the default empty frame
                apngImage.RemoveAllFrames();

                // Add the source image as the first (and only) frame
                apngImage.AddFrame(sourceImage);

                // Save the APNG image (output path already bound via FileCreateSource)
                apngImage.Save();
            }
        }
    }
}