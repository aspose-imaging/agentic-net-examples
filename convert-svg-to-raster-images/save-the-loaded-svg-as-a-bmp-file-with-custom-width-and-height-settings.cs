using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.svg";
        string outputPath = @"C:\temp\output.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image from the file
        using (SvgImage svgImage = new SvgImage(inputPath))
        {
            // Define rasterization options with custom dimensions
            var rasterOptions = new SvgRasterizationOptions
            {
                PageWidth = 800,   // custom width in pixels
                PageHeight = 600   // custom height in pixels
            };

            // Set BMP save options and attach the rasterization settings
            var bmpOptions = new BmpOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image as BMP
            svgImage.Save(outputPath, bmpOptions);
        }
    }
}