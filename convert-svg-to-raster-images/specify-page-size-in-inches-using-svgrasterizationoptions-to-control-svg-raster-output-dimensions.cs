using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.png";

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
            // Configure SVG rasterization options with page size in inches
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                // Example: 4 inches width, 3 inches height
                PageSize = new SizeF(4.0f, 3.0f),
                BackgroundColor = Color.White
            };

            // Set PNG save options and attach rasterization options
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image
            image.Save(outputPath, pngOptions);
        }
    }
}