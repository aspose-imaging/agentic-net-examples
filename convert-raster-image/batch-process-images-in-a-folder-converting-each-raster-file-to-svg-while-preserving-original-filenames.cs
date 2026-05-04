using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = @"C:\InputImages";
            string outputFolder = @"C:\OutputSvgs";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Supported raster extensions
            string[] extensions = new[] { ".png", ".jpg", ".jpeg", ".bmp", ".tiff", ".tif", ".gif" };

            // Enumerate files in the input folder
            foreach (string filePath in Directory.GetFiles(inputFolder))
            {
                // Skip files that are not raster images
                if (Array.IndexOf(extensions, Path.GetExtension(filePath).ToLowerInvariant()) < 0)
                    continue;

                // Verify input file exists
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                // Build output file path preserving original filename
                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(filePath) + ".svg");

                // Ensure the output directory exists (unconditional)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the raster image and convert to SVG
                using (Image image = Image.Load(filePath))
                {
                    // Set up rasterization options based on the source image size
                    var vectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    };

                    // Save as SVG using the specified options
                    image.Save(outputPath, new SvgOptions
                    {
                        VectorRasterizationOptions = vectorRasterizationOptions
                    });
                }

                Console.WriteLine($"Converted: {filePath} -> {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}