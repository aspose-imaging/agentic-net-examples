using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.odg";
        string outputPath = "output\\converted.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load ODG image and save as SVG preserving vector data
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options based on source image size
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };

            // Set up SVG save options with the rasterization settings
            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the image as SVG
            image.Save(outputPath, svgOptions);
        }
    }
}