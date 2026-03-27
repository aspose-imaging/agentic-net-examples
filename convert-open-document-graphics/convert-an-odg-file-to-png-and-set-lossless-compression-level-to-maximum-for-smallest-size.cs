using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.odg";
        string outputPath = @"C:\Images\sample.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PNG save options with maximum lossless compression
            var pngOptions = new PngOptions
            {
                CompressionLevel = 9,               // Max compression (0-9)
                Progressive = true                  // Optional: enable progressive loading
            };

            // Set vector rasterization options required for ODG conversion
            var rasterOptions = new OdgRasterizationOptions
            {
                PageSize = image.Size,               // Preserve original size
                BackgroundColor = Color.White        // White background for transparent areas
            };
            pngOptions.VectorRasterizationOptions = rasterOptions;

            // Save as PNG
            image.Save(outputPath, pngOptions);
        }
    }
}