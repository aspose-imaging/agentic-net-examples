using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input SVG path and output PNG path.
        string inputPath = args.Length > 0 ? args[0] : "input.svg";
        string outputPath = args.Length > 1 ? args[1] : "output.png";

        // Ensure the input file exists.
        if (!File.Exists(inputPath))
        {
            Console.WriteLine($"Input file not found: {inputPath}");
            return;
        }

        // Load the SVG image.
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options for the SVG.
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                // Set the page size to match the SVG dimensions.
                PageSize = image.Size,
                // Optional: set background color if needed.
                BackgroundColor = Color.White
            };

            // Set PNG save options and attach the rasterization options.
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized PNG.
            image.Save(outputPath, pngOptions);
        }

        Console.WriteLine($"SVG converted to PNG successfully: {outputPath}");
    }
}