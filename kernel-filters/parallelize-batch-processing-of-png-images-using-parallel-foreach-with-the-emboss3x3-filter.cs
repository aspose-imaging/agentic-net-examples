using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = "Input";
            string outputDir = "Output";

            // Validate input directory
            if (!Directory.Exists(inputDir))
            {
                Directory.CreateDirectory(inputDir);
                Console.WriteLine($"Input directory created at: {inputDir}. Add files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Get all PNG files in the input directory
            string[] files = Directory.GetFiles(inputDir, "*.png");

            // Process each file in parallel
            Parallel.ForEach(files, inputPath =>
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output file path
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileName + "_emboss.png");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image, apply Emboss3x3 filter, and save as PNG
                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;
                    raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));
                    raster.Save(outputPath, new PngOptions());
                }
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to quickly generate embossed thumbnails for a large collection of product PNG images in an e‑commerce catalog.
 * 2. When an image‑processing pipeline must apply a 3×3 emboss convolution filter to thousands of user‑uploaded PNG avatars while maximizing CPU utilization.
 * 3. When a desktop application has to batch‑convert scanned PNG documents into stylized embossed graphics for visual effects in a publishing workflow.
 * 4. When a server‑side service processes PNG assets for a game’s texture library, adding depth cues via the Emboss3x3 filter before packaging them for deployment.
 * 5. When a photo‑editing tool automates the creation of embossed PNG overlays for marketing banners, running the filter in parallel to reduce overall processing time.
 */