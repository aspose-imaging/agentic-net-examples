using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.svg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (creates if missing)
            string outDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outDir ?? ".");

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Configure SVG rasterization options with transparent background
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    BackgroundColor = Color.Transparent,
                    PageSize = image.Size
                };

                // Set up SVG save options
                var saveOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save the image as SVG
                image.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}