using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.eps";
        string outputPath = "output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EPS image
        using (var image = (EpsImage)Image.Load(inputPath))
        {
            // Configure rasterization options (e.g., desired page size)
            var rasterOptions = new EpsRasterizationOptions
            {
                PageWidth = 800,   // Width in pixels
                PageHeight = 600   // Height in pixels
            };

            // Set up PNG save options with the rasterization settings
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image to the target format
            image.Save(outputPath, pngOptions);
        }
    }
}