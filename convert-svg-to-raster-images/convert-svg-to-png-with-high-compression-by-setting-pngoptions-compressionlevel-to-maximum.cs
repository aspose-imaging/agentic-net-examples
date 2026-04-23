using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.svg";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Set up rasterization options for SVG
            var rasterizationOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };

            // Configure PNG save options with maximum compression
            var pngOptions = new PngOptions
            {
                CompressionLevel = 9, // Max compression (0-9)
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save the rasterized PNG
            image.Save(outputPath, pngOptions);
        }
    }
}