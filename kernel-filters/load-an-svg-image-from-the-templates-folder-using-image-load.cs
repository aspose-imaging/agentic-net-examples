using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = Path.Combine("templates", "sample.svg");
        string outputPath = Path.Combine("output", "sample.png");

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
            // Prepare rasterization options for PNG output
            var rasterizationOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save the rasterized image
            image.Save(outputPath, pngOptions);
        }
    }
}