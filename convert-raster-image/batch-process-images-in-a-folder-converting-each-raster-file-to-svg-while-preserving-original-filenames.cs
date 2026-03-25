using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output directories
        string inputDirectory = @"C:\Images\Input";
        string outputDirectory = @"C:\Images\Output";

        // Ensure the input directory exists
        if (!Directory.Exists(inputDirectory))
        {
            Console.Error.WriteLine($"Input directory does not exist: {inputDirectory}");
            return;
        }

        // Create the output directory if it does not exist
        Directory.CreateDirectory(outputDirectory);

        // Define raster file extensions to process
        string[] rasterExtensions = new[] { ".jpg", ".jpeg", ".png", ".bmp", ".gif", ".tif", ".tiff", ".webp" };

        // Enumerate all files in the input directory
        foreach (string filePath in Directory.GetFiles(inputDirectory))
        {
            // Skip non‑raster files
            if (!rasterExtensions.Contains(Path.GetExtension(filePath).ToLower()))
                continue;

            // Verify the input file exists
            if (!File.Exists(filePath))
            {
                Console.Error.WriteLine($"File not found: {filePath}");
                return;
            }

            // Build the output SVG path preserving the original filename
            string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(filePath) + ".svg");

            // Ensure the output directory exists (unconditional as required)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the raster image and convert to SVG
            using (Image image = Image.Load(filePath))
            {
                // Configure SVG rasterization options
                var rasterOptions = new SvgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };

                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save as SVG
                image.Save(outputPath, svgOptions);
            }
        }
    }
}