using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.otg";
        string outputPath = @"C:\Images\sample_converted.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the OTG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PNG save options with maximum lossless compression
            var pngOptions = new PngOptions
            {
                CompressionLevel = 9 // maximum compression (0-9)
            };

            // Set up rasterization options for vector OTG content
            var otgRasterOptions = new OtgRasterizationOptions
            {
                PageSize = image.Size // preserve original dimensions
            };
            pngOptions.VectorRasterizationOptions = otgRasterOptions;

            // Save the image as PNG using the configured options
            image.Save(outputPath, pngOptions);
        }
    }
}