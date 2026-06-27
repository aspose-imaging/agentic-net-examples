using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = @"C:\Images\Input";
            string outputDirectory = @"C:\Images\Output";

            // Get all SVG files in the input directory
            string[] svgFiles = Directory.GetFiles(inputDirectory, "*.svg");

            foreach (string inputPath in svgFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output path (same name with _blur.png suffix)
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + "_blur.png";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the SVG image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage for filtering
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply Gaussian blur filter (radius 5, sigma 4.0) to the whole image
                    rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                    // Save the processed image as PNG
                    rasterImage.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to automatically apply a Gaussian blur filter to every SVG logo in a folder and export the results as PNG thumbnails for a web gallery.
 * 2. When a CI/CD pipeline must preprocess vector assets by rasterizing SVG files, blurring them, and storing the blurred PNGs for use in UI placeholders.
 * 3. When an e‑commerce platform wants to generate blurred background images from product SVG illustrations to improve page load performance.
 * 4. When a marketing automation script has to batch‑process SVG icons, apply a consistent blur filter, and save them as PNGs for email campaign assets.
 * 5. When a desktop application must convert a directory of SVG diagrams into blurred PNG previews for quick visual indexing.
 */