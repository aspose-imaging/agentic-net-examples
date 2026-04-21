using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.svg";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Desired output dimensions
        int targetWidth = 800;
        int targetHeight = 600;

        // Load SVG image from file
        using (SvgImage svgImage = new SvgImage(inputPath))
        {
            // Configure rasterization options with custom page size
            SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
            {
                PageSize = new Size(targetWidth, targetHeight)
            };

            // Set PNG save options and attach rasterization options
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save rasterized PNG
            svgImage.Save(outputPath, pngOptions);
        }
    }
}