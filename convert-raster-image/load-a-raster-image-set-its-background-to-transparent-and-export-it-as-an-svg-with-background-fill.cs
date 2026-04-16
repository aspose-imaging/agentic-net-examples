using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load raster image
        using (Image image = Image.Load(inputPath))
        {
            // Configure SVG rasterization options with transparent background
            var rasterOptions = new SvgRasterizationOptions
            {
                BackgroundColor = Color.Transparent,
                PageSize = image.Size
            };

            // Set up SVG save options
            var saveOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save as SVG
            image.Save(outputPath, saveOptions);
        }
    }
}