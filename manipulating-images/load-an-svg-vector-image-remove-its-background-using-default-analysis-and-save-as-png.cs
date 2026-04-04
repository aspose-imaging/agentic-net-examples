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

        // Load SVG image
        using (SvgImage svgImage = new SvgImage(inputPath))
        {
            // Remove background using default analysis
            svgImage.RemoveBackground();

            // Configure rasterization options for PNG output
            var rasterizationOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size // preserve original size
            };

            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save as PNG
            svgImage.Save(outputPath, pngOptions);
        }
    }
}