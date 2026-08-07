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

            // Get all PNG files in the input folder
            string[] pngFiles = Directory.GetFiles(inputFolder, "*.png");

            foreach (string inputPath in pngFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Load the image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to apply filters
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply a predefined Gaussian blur filter (radius 5, sigma 4.0)
                    rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                    // Build the output JPEG path
                    string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputPath) + ".jpg");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the processed image as JPEG
                    JpegOptions jpegOptions = new JpegOptions();
                    rasterImage.Save(outputPath, jpegOptions);
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
 * 1. When a developer needs to automatically blur and convert a large collection of PNG assets to JPEG for faster web page loading.
 * 2. When a photo‑editing tool must apply a consistent Gaussian blur to every PNG in a directory before archiving them as JPEGs.
 * 3. When a batch‑processing script is required to prepare product images by smoothing PNG files and saving them in a JPEG format for e‑commerce platforms.
 * 4. When an automated build pipeline has to generate preview JPEGs with a predefined blur effect from source PNG graphics.
 * 5. When a migration utility must transform legacy PNG screenshots into compressed JPEGs while applying a blur filter to protect sensitive details.
 */