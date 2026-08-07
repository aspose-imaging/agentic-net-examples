using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input directory containing PNG files
        string inputDirectory = "C:\\Images\\";

        try
        {
            // Get all PNG files in the directory
            string[] pngFiles = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string filePath in pngFiles)
            {
                // Verify the input file exists
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                // Load the image
                using (Image image = Image.Load(filePath))
                {
                    // Cast to RasterImage to access filtering
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply sharpen filter (kernel size 5, sigma 4.0) to the whole image
                    rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

                    // Ensure the output directory exists (unconditional)
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                    // Overwrite the original file with the filtered image
                    rasterImage.Save(filePath);
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
 * 1. When a developer needs to automatically enhance the visual sharpness of a large collection of PNG assets—such as product photos for an e‑commerce site—by applying a sharpen filter and saving the results back to the original files.
 * 2. When a batch image‑processing pipeline must prepare PNG screenshots for documentation by increasing edge contrast without creating duplicate files, using C# and Aspose.Imaging’s SharpenFilterOptions.
 * 3. When a content‑management system imports user‑uploaded PNG graphics and the backend must improve clarity in place before publishing, leveraging Directory.GetFiles and RasterImage.Filter.
 * 4. When a desktop application needs to clean up a folder of scanned PNG diagrams, applying a 5‑pixel kernel sharpen filter to each file and overwriting the originals safely.
 * 5. When an automated build script for a game’s UI assets must ensure all PNG textures are sharpened for better on‑screen detail, using Aspose.Imaging’s raster image filtering in a C# loop.
 */