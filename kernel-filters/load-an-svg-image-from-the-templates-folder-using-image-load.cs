using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "templates/sample.svg";
        string outputPath = "output/sample.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image using Aspose.Imaging.Image.Load
        using (Image image = Image.Load(inputPath))
        {
            // Set up rasterization options for SVG to PNG conversion
            var rasterizationOptions = new SvgRasterizationOptions();

            // Configure PNG save options with the rasterization settings
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save the rasterized image to the output path
            image.Save(outputPath, pngOptions);
        }
    }
}