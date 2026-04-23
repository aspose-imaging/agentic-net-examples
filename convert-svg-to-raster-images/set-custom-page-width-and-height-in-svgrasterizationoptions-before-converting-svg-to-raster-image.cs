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
        using (SvgImage svgImage = (SvgImage)Image.Load(inputPath))
        {
            // Configure rasterization options with custom page size
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                // Set custom width and height (in pixels)
                PageWidth = 800f,
                PageHeight = 600f,
                // Optional: preserve aspect ratio if one dimension is zero (not needed here)
                // PageSize = new System.Drawing.SizeF(800, 600)
            };

            // Prepare PNG save options and attach rasterization settings
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image
            svgImage.Save(outputPath, pngOptions);
        }
    }
}