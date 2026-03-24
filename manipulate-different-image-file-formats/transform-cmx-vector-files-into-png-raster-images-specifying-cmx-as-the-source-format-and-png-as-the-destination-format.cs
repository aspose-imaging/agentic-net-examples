using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\sample.cmx";
        string outputPath = @"c:\temp\sample.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CMX image
        using (Image image = Image.Load(inputPath))
        {
            // Set up rasterization options for CMX
            var rasterOptions = new CmxRasterizationOptions
            {
                // Optional: set background color, page size, etc.
                // BackgroundColor = Color.White,
                // PageWidth = 0, // preserve aspect ratio
                // PageHeight = 0
            };

            // Configure PNG save options with the rasterization settings
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image as PNG
            image.Save(outputPath, pngOptions);
        }
    }
}