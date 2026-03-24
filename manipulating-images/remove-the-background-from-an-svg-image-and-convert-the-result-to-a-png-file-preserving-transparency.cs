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
        using (SvgImage svgImage = new SvgImage(inputPath))
        {
            // Remove any background, making it transparent
            svgImage.RemoveBackground();

            // Set up rasterization options for PNG output
            var rasterizationOptions = new SvgRasterizationOptions
            {
                // Preserve original size
                PageSize = svgImage.Size,
                // Ensure background is transparent
                BackgroundColor = Aspose.Imaging.Color.Transparent
            };

            // Configure PNG save options with the rasterization settings
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save the rasterized PNG image
            svgImage.Save(outputPath, pngOptions);
        }
    }
}