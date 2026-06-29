using System;
using System.IO;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ProgressManagement;

class Program
{
    // Progress callback for load/save operations (optional, shows internal progress)
    private static void ProgressCallback(ProgressEventHandlerInfo info)
    {
        // Simple console output for internal Aspose.Imaging progress
        Console.WriteLine($"{info.EventType} : {info.Value}/{info.MaxValue}");
    }

    static void Main()
    {
        // Hardcoded input and output directories
        string inputDirectory = @"C:\Images\Input";
        string outputDirectory = @"C:\Images\Output";

        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all image files in the input directory (common extensions)
            string[] files = Directory.GetFiles(inputDirectory, "*.*", SearchOption.TopDirectoryOnly);
            int totalFiles = files.Length;
            if (totalFiles == 0)
            {
                Console.WriteLine("No files found in the input directory.");
                return;
            }

            int processedCount = 0;

            foreach (string inputPath in files)
            {
                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Determine output file path (same name with suffix)
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string extension = Path.GetExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, $"{fileName}_sharpen{extension}");

                // Ensure output directory exists (already created above, but follow rule)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load image with progress handler (optional)
                using (Image image = Image.Load(inputPath, new LoadOptions { ProgressEventHandler = ProgressCallback }))
                {
                    // Cast to RasterImage to apply filter
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply sharpen filter (kernel size 5, sigma 4.0)
                    var sharpenOptions = new SharpenFilterOptions(5, 4.0);
                    rasterImage.Filter(rasterImage.Bounds, sharpenOptions);

                    // Save image with progress handler (optional)
                    rasterImage.Save(outputPath, new Aspose.Imaging.ImageOptions.PngOptions { ProgressEventHandler = ProgressCallback });
                }

                processedCount++;

                // Update simple console progress bar
                double percent = (double)processedCount / totalFiles * 100;
                Console.Write($"\rProcessing: {processedCount}/{totalFiles} ({percent:0.00}%)");
            }

            Console.WriteLine("\nProcessing completed.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a desktop photo‑organizer needs to batch sharpen thousands of JPEG and PNG files before publishing them to an online gallery, this code applies a kernel filter to each image while updating a progress bar for the user.
 * 2. When an automated document‑processing workflow must enhance scanned TIFF pages with edge‑sharpening and provide real‑time status feedback, developers can use this snippet to filter each file and report progress.
 * 3. When a C# image‑editing application offers a “Batch Sharpen” feature that processes a selected folder and keeps the UI responsive by showing how many images have completed filtering, the example demonstrates the required Aspose.Imaging integration.
 * 4. When a digital asset management system needs to re‑apply a custom sharpening kernel to all assets in a legacy archive and log the per‑file progress for monitoring, this code provides the necessary batch‑processing logic.
 * 5. When a Windows service watches an input directory, applies a sharpening filter to newly added images, writes the results to an output folder, and sends progress updates to a dashboard, this example shows how to implement it.
 */