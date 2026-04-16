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
            // Configure rasterization options for SVG
            var rasterizationOptions = new SvgRasterizationOptions
            {
                // Set page size to match the SVG dimensions
                PageSize = image.Size,
                // Disable background color to obtain transparency
                BackgroundColor = Aspose.Imaging.Color.Transparent
            };

            // Configure PNG save options and attach rasterization options
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save the rasterized PNG image
            image.Save(outputPath, pngOptions);
        }
    }
}