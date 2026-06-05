using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    // Simple console progress bar
    static void DrawProgressBar(int completed, int total)
    {
        int barWidth = 50;
        double ratio = (double)completed / total;
        int filled = (int)Math.Round(ratio * barWidth);
        string bar = new string('#', filled).PadRight(barWidth, '-');
        int percent = (int)(ratio * 100);
        Console.Write($"\rProcessing: [{bar}] {percent}%");
    }

    static void Main()
    {
        try
        {
            // Hard‑coded input and output directories
            string inputFolder = @"C:\Images\Input";
            string outputFolder = @"C:\Images\Output";

            // Get image files (you can extend the filter as needed)
            string[] files = Directory.GetFiles(inputFolder, "*.*", SearchOption.TopDirectoryOnly);
            // Filter common image extensions
            files = Array.FindAll(files, f =>
                f.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                f.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase));

            int totalFiles = files.Length;
            if (totalFiles == 0)
            {
                Console.WriteLine("No image files found.");
                return;
            }

            for (int i = 0; i < totalFiles; i++)
            {
                string inputPath = files[i];

                // Input file existence check
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + "_sharpened.png";
                string outputPath = Path.Combine(outputFolder, outputFileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load image, apply sharpen filter, and save
                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;
                    // Sharpen filter with kernel size 5 and sigma 4.0
                    raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));
                    raster.Save(outputPath);
                }

                // Update progress bar
                DrawProgressBar(i + 1, totalFiles);
            }

            // Move to next line after progress bar completes
            Console.WriteLine();
            Console.WriteLine("Processing completed.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to batch‑process a folder of JPEG, PNG or BMP files with Aspose.Imaging’s Sharpen filter and wants a console progress bar to show real‑time completion percentage.
 * 2. When an automated image‑enhancement pipeline must convert raw photos to sharpened PNGs while providing visual feedback in a C# command‑line tool.
 * 3. When a Windows service processes incoming product images, applies a kernel filter using Aspose.Imaging, and logs progress to the console for monitoring.
 * 4. When a QA engineer runs regression tests on image‑filtering code and needs a simple progress indicator to verify that all test images are processed without hanging.
 * 5. When a developer integrates Aspose.Imaging into a build script that optimizes graphics assets and wants to display a live progress bar for each file processed.
 */