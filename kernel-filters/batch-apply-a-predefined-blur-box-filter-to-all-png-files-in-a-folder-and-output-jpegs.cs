// HOW-TO: Batch Apply Gaussian Blur to PNGs and Save as JPEGs in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = @"C:\Images\Input";
            string outputFolder = @"C:\Images\Output";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all PNG files in the input folder
            string[] pngFiles = Directory.GetFiles(inputFolder, "*.png");

            foreach (string inputPath in pngFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine the output JPEG path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".jpg");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the PNG image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to apply filters
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply a Gaussian blur filter (acts as a blur box)
                    rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                    // Save the result as JPEG
                    rasterImage.Save(outputPath, new JpegOptions());
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
 * 1. When you need to automatically blur a collection of product photos in PNG format before publishing them as smaller JPEG thumbnails.
 * 2. When you want to preprocess scanned documents by applying a blur box filter to reduce noise and then convert them to JPEG for web display.
 * 3. When a photo‑editing tool must batch‑process user‑uploaded PNG images, add a Gaussian blur effect, and store the results as JPEGs for faster loading.
 * 4. When you are building a server‑side script that prepares PNG assets for email newsletters by blurring and converting them to JPEG to meet size limits.
 * 5. When you need to migrate a legacy PNG image library to JPEG while applying a consistent blur filter to protect sensitive details across all files.
 */
