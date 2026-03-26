using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.svg";
        string outputPath = @"C:\temp\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            // Configure rasterization options with transparent background
            var rasterOptions = new SvgRasterizationOptions
            {
                BackgroundColor = Aspose.Imaging.Color.Transparent,
                PageSize = image.Size
            };

            // Set PNG save options and attach rasterization options
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save as PNG with transparent background
            image.Save(outputPath, pngOptions);
        }
    }
}