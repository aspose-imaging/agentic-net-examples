using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.svg";
        string outputPath = @"C:\Images\output.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image
        using (SvgImage svgImage = (SvgImage)Image.Load(inputPath))
        {
            // Configure rasterization options with anti‑aliasing
            SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size,
                SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias,
                TextRenderingHint = Aspose.Imaging.TextRenderingHint.AntiAlias
            };

            // Set up BMP save options and attach rasterization options
            BmpOptions bmpOptions = new BmpOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save the rasterized image as BMP
            svgImage.Save(outputPath, bmpOptions);
        }
    }
}