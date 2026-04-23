using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ProgressManagement;

class Program
{
    // Holds the name of the file currently being processed for progress callbacks
    private static string _currentFileName = string.Empty;

    // Progress callback for loading operations
    private static void LoadProgressCallback(ProgressEventHandlerInfo info)
    {
        Console.Write($"\rLoading {_currentFileName}: {info.EventType} {info.Value}/{info.MaxValue}   ");
    }

    // Progress callback for saving operations
    private static void SaveProgressCallback(ProgressEventHandlerInfo info)
    {
        Console.Write($"\rSaving   {_currentFileName}: {info.EventType} {info.Value}/{info.MaxValue}   ");
    }

    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = @"C:\Images\Input";
            string outputFolder = @"C:\Images\Output";

            // Get all PNG files in the input folder
            string[] files = Directory.GetFiles(inputFolder, "*.png");

            int totalFiles = files.Length;
            int processedCount = 0;

            foreach (string inputPath in files)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                _currentFileName = Path.GetFileName(inputPath);

                // Prepare output path
                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputPath) + "_sharpened.png");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load image with progress handler
                using (Image image = Image.Load(inputPath, new LoadOptions { ProgressEventHandler = LoadProgressCallback }))
                {
                    // Cast to RasterImage to apply filter
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply sharpen filter
                    rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

                    // Save image with progress handler
                    rasterImage.Save(outputPath, new Aspose.Imaging.ImageOptions.PngOptions { ProgressEventHandler = SaveProgressCallback });
                }

                processedCount++;
                // Overall progress
                Console.WriteLine($"\rProcessed {processedCount}/{totalFiles} images.                              ");
            }

            Console.WriteLine("All images processed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}