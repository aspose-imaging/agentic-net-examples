using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.cmx";
            string outputPath = "Output\\sample.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                // Log conversion parameters
                Console.WriteLine($"Converting CMX to PNG");
                Console.WriteLine($"Input: {inputPath}");
                Console.WriteLine($"Output: {outputPath}");
                Console.WriteLine($"Image dimensions: {image.Width}x{image.Height}");

                var rasterOptions = new CmxRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a print shop needs to batch‑convert legacy CMX vector files to PNG for web preview while recording each conversion’s input path, output path, and image dimensions in NLog for audit trails.
 * 2. When a document management system automatically transforms uploaded CMX drawings into PNG thumbnails and logs the rasterization settings with NLog to help support teams diagnose mismatched colors or sizes.
 * 3. When a CI/CD pipeline validates that CMX assets are correctly rendered as PNGs and uses NLog to capture conversion parameters for each build to ensure reproducible results.
 * 4. When a GIS application processes large collections of CMX maps into PNG raster images and logs conversion details with NLog to monitor performance and detect files that exceed expected dimensions.
 * 5. When a software vendor provides a command‑line utility for end‑users to convert CMX files to PNG and wants NLog entries for every operation to generate detailed usage reports and error diagnostics.
 */