// HOW-TO: Apply Gaussian Blur to All Images in Folder With Progress Bar in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output directories
        string inputFolder = @"C:\Images\Input";
        string outputFolder = @"C:\Images\Output";

        try
        {
            // Get all files in the input folder (filter common image extensions)
            string[] files = Directory.GetFiles(inputFolder, "*.*", SearchOption.TopDirectoryOnly);
            List<string> imageFiles = new List<string>();
            foreach (var f in files)
            {
                string ext = Path.GetExtension(f).ToLowerInvariant();
                if (ext == ".png" || ext == ".jpg" || ext == ".jpeg" || ext == ".bmp" || ext == ".tif" || ext == ".tiff" || ext == ".gif")
                {
                    imageFiles.Add(f);
                }
            }

            int total = imageFiles.Count;
            int processed = 0;

            foreach (var inputPath in imageFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + "_filtered.png";
                string outputPath = Path.Combine(outputFolder, outputFileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load, filter, and save the image
                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;
                    raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                    // Save as PNG
                    raster.Save(outputPath, new PngOptions());
                }

                // Update progress UI
                processed++;
                int barWidth = 30;
                int filled = (int)((processed / (double)total) * barWidth);
                string bar = new string('#', filled).PadRight(barWidth, '-');
                Console.WriteLine($"[{bar}] {processed}/{total} - Processed: {Path.GetFileName(inputPath)}");
            }

            Console.WriteLine("All images have been processed.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to batch‑apply a Gaussian blur to every PNG, JPEG, BMP, TIFF, or GIF in a directory and save the results as new PNG files.
 * 2. When you want to display a console progress bar that updates after each image is filtered to inform users of processing status.
 * 3. When you must automatically create the output folder if it does not exist before writing the filtered images.
 * 4. When you are converting mixed‑format source images to a consistent PNG format after applying a kernel filter.
 * 5. When you need to verify each input file exists before loading it to prevent crashes in an automated image‑processing pipeline.
 */
