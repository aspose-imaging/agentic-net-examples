using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ProgressManagement;
using Aspose.Imaging.ImageOptions;

class Program
{
    // Hard‑coded input and output folders
    private const string InputFolder = @"C:\Images\Input";
    private const string OutputFolder = @"C:\Images\Output";

    static void Main()
    {
        // Ensure the output directory exists
        Directory.CreateDirectory(OutputFolder);

        // Get image files (png, jpg, bmp) from the input folder
        string[] files = Directory.GetFiles(InputFolder, "*.*", SearchOption.TopDirectoryOnly)
            .Where(f => f.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                        f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                        f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                        f.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase))
            .ToArray();

        int total = files.Length;
        int processed = 0;

        foreach (string inputPath in files)
        {
            // Input file existence check
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(OutputFolder, fileNameWithoutExt + "_sharpened.png");

            // Ensure the directory for the output file exists (unconditional)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image with a progress callback
            using (Image image = Image.Load(
                inputPath,
                new LoadOptions { ProgressEventHandler = LoadProgress }))
            {
                // Apply a sharpen filter if the image is raster based
                if (image is RasterImage raster)
                {
                    var sharpenOptions = new SharpenFilterOptions(5, 4.0);
                    raster.Filter(raster.Bounds, sharpenOptions);
                }

                // Save the processed image with a progress callback
                var pngOptions = new PngOptions
                {
                    ProgressEventHandler = SaveProgress
                };
                image.Save(outputPath, pngOptions);
            }

            processed++;
            DrawProgressBar(processed, total);
        }

        Console.WriteLine("\nAll images have been processed.");
    }

    // Progress handler for loading operations
    private static void LoadProgress(ProgressEventHandlerInfo info)
    {
        Console.Write($"\rLoading: {info.EventType} {info.Value}/{info.MaxValue}   ");
    }

    // Progress handler for saving operations
    private static void SaveProgress(ProgressEventHandlerInfo info)
    {
        Console.Write($"\rSaving:   {info.EventType} {info.Value}/{info.MaxValue}   ");
    }

    // Simple textual progress bar showing overall folder processing status
    private static void DrawProgressBar(int processed, int total)
    {
        const int barWidth = 40;
        double ratio = (double)processed / total;
        int filled = (int)(ratio * barWidth);
        string bar = new string('#', filled).PadRight(barWidth, '-');
        Console.Write($"\r[{bar}] {processed}/{total} images processed");
    }
}