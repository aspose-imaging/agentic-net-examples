using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
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

        // Desired dimensions for the rasterized PNG
        int targetWidth = 800;   // custom width
        int targetHeight = 600;  // custom height

        // Load the SVG image from file
        using (SvgImage svgImage = new SvgImage(inputPath))
        {
            // Configure rasterization options with custom page size
            SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
            {
                PageSize = new Size(targetWidth, targetHeight)
            };

            // Set up PNG save options and attach rasterization options
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save the rasterized image to PNG
            svgImage.Save(outputPath, pngOptions);
        }
    }
}