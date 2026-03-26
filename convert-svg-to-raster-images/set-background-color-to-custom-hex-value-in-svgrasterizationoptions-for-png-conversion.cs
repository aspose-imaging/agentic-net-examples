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
        string inputPath = @"C:\temp\test.svg";
        string outputPath = @"C:\temp\test.output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            SvgImage svgImage = (SvgImage)image;

            // Configure rasterization options with a custom background color (hex #112233)
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                // Alpha = 255 (fully opaque), Red = 0x11, Green = 0x22, Blue = 0x33
                BackgroundColor = Aspose.Imaging.Color.FromArgb(255, 0x11, 0x22, 0x33),
                PageSize = svgImage.Size
            };

            // Set PNG save options and attach the rasterization options
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized PNG image
            svgImage.Save(outputPath, pngOptions);
        }
    }
}