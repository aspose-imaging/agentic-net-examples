// HOW-TO: Apply Gaussian Blur to Images in a Folder with Progress Bar in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "C:\\Images\\Input";
            string outputFolder = "C:\\Images\\Output";

            Directory.CreateDirectory(outputFolder);

            var imageFiles = Directory.GetFiles(inputFolder)
                .Where(f => new[] { ".jpg", ".jpeg", ".png", ".bmp", ".tif", ".tiff", ".gif", ".webp" }
                .Contains(Path.GetExtension(f).ToLower()))
                .ToArray();

            int total = imageFiles.Length;
            int processed = 0;

            foreach (var inputPath in imageFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileName(inputPath);
                string outputPath = Path.Combine(outputFolder, fileName);
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (var image = Image.Load(inputPath))
                {
                    var raster = image as RasterImage;
                    if (raster == null)
                    {
                        Console.Error.WriteLine($"Unsupported image format: {inputPath}");
                        continue;
                    }

                    var kernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetGaussian(5, 1.0);
                    var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                    raster.Filter(raster.Bounds, filterOptions);

                    var saveOptions = new PngOptions();
                    raster.Save(outputPath, saveOptions);
                }

                processed++;
                int barSize = 30;
                int filled = (int)Math.Round((double)processed / total * barSize);
                string bar = new string('#', filled).PadRight(barSize, '-');
                Console.Write($"\rProcessing: [{bar}] {processed}/{total}");
            }

            Console.WriteLine("\nProcessing complete.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to batch‑process a collection of JPEG, PNG, BMP, or TIFF files to add a Gaussian blur before publishing them online.
 * 2. When you want to convert various image formats to PNG while applying a smoothing filter and track the operation with a console progress bar.
 * 3. When an automated workflow must improve image quality by reducing noise on every picture in a directory using Aspose.Imaging in C#.
 * 4. When a desktop application requires real‑time feedback while applying a convolution filter to each file in a large image dataset.
 * 5. When you are building a preprocessing step for machine‑learning training data that standardizes images with a Gaussian kernel and saves them uniformly.
 */
