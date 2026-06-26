using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input and output directories (relative paths)
            string inputDir = "Input";
            string outputDir = "Output";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Get all BMP files in the input directory
            string[] files = Directory.GetFiles(inputDir, "*.bmp");

            foreach (var inputPath in files)
            {
                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output SVG path
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileName + ".svg");

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the BMP image
                using (Image image = Image.Load(inputPath))
                {
                    // Increase brightness by approximately 10%
                    RasterImage raster = (RasterImage)image;
                    raster.AdjustBrightness(25); // 25 ≈ 10% of the 255 range

                    // Set up SVG conversion options
                    var vectorOptions = new SvgRasterizationOptions { PageSize = image.Size };
                    var svgOptions = new SvgOptions { VectorRasterizationOptions = vectorOptions };

                    // Save as SVG
                    image.Save(outputPath, svgOptions);
                }
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
 * 1. When a developer needs to automatically brighten a collection of legacy BMP assets and generate scalable SVG versions for responsive web design.
 * 2. When a developer wants to preprocess scanned BMP diagrams by increasing their brightness before converting them to SVG for inclusion in technical documentation.
 * 3. When a developer must prepare a batch of BMP product images for print‑ready vector graphics, applying a uniform 10% brightness boost to improve visual consistency.
 * 4. When a developer is building a migration tool that transforms old BMP UI icons into SVG icons while adjusting brightness to match modern UI themes.
 * 5. When a developer requires a C# script to bulk convert BMP screenshots to SVG format with a slight brightness increase for better visibility in analytics dashboards.
 */