using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

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
            // Configure rasterization options for SVG
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size // Preserve original dimensions
            };

            // Configure PNG options with maximum compression
            var pngOptions = new PngOptions
            {
                CompressionLevel = 9,
                VectorRasterizationOptions = rasterOptions
            };

            // Save as PNG with the specified options
            image.Save(outputPath, pngOptions);
        }
    }
}