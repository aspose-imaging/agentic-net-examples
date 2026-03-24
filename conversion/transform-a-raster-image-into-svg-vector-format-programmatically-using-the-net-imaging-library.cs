using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output/output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the raster image
        using (Image image = Image.Load(inputPath))
        {
            // Configure vector rasterization options (page size matches source image)
            var vectorOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };

            // Set up SVG save options
            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = vectorOptions,
                // Optional settings
                Compress = false,
                TextAsShapes = true
            };

            // Save the image as SVG
            image.Save(outputPath, svgOptions);
        }
    }
}