using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output/output.png";

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
            // Configure rasterization options for transparent background
            var rasterizationOptions = new SvgRasterizationOptions
            {
                // Set background to transparent
                BackgroundColor = Aspose.Imaging.Color.Transparent,
                // Use the original SVG size
                PageSize = image.Size
            };

            // Configure PNG save options
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save as PNG with transparent background
            image.Save(outputPath, pngOptions);
        }
    }
}