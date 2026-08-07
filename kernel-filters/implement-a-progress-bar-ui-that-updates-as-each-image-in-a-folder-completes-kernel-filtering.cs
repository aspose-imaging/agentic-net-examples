using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ProgressManagement;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "InputImages";
            string outputDirectory = "OutputImages";

            Directory.CreateDirectory(outputDirectory);

            string[] inputFiles = Directory.GetFiles(inputDirectory);
            int totalFiles = inputFiles.Length;
            int processedCount = 0;

            foreach (string inputPath in inputFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + "_filtered.png");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                var saveOptions = new PngOptions();
                saveOptions.ProgressEventHandler = delegate (ProgressEventHandlerInfo info)
                {
                    Console.WriteLine($"Saving \"{fileNameWithoutExt}\": {info.EventType} {info.Value}/{info.MaxValue}");
                };

                using (Image image = Image.Load(inputPath))
                {
                    var rasterImage = (RasterImage)image;
                    rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));
                    rasterImage.Save(outputPath, saveOptions);
                }

                processedCount++;
                Console.WriteLine($"Processed {processedCount}/{totalFiles}");
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
 * 1. When a developer needs to batch‑process a collection of JPEG or PNG photos to apply a Gaussian blur for privacy masking while showing a console progress bar for each file saved.
 * 2. When an automated image‑pipeline must read images from an input folder, apply a kernel filter such as GaussianBlurFilterOptions, and write the filtered results to an output directory with real‑time progress updates in C#.
 * 3. When a desktop utility is required to convert raw image files to PNG, apply a 5‑pixel radius blur, and display per‑image save progress using Aspose.Imaging’s ProgressEventHandler.
 * 4. When a server‑side service processes user‑uploaded pictures, runs a raster image filter on each file, and logs the number of processed files versus total to monitor batch completion.
 * 5. When a developer builds a command‑line tool that iterates over all files in a folder, applies a Gaussian kernel filter, saves the output with a “_filtered” suffix, and provides a simple progress indicator for monitoring long‑running image transformations.
 */