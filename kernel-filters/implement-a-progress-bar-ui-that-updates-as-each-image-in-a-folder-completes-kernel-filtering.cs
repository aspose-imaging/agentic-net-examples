using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ProgressManagement;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputFolder = @"C:\Images\Input";
        string outputFolder = @"C:\Images\Output";

        try
        {
            // Get all image files in the input folder (adjust the pattern as needed)
            string[] files = Directory.GetFiles(inputFolder, "*.*", SearchOption.TopDirectoryOnly);
            int totalFiles = files.Length;
            int processedFiles = 0;

            // Simple console progress bar settings
            const int progressBarWidth = 50;

            foreach (string inputPath in files)
            {
                // Verify input file exists
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

                    // Apply sharpen filter with kernel size 5 and sigma 4.0
                    raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

                    // Save the processed image
                    raster.Save(outputPath);
                }

                // Update progress bar
                processedFiles++;
                int filled = (int)((double)processedFiles / totalFiles * progressBarWidth);
                string bar = new string('#', filled).PadRight(progressBarWidth, '-');
                Console.Write($"\rProcessing: [{bar}] {processedFiles}/{totalFiles}");
            }

            // Move to next line after completion
            Console.WriteLine();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}