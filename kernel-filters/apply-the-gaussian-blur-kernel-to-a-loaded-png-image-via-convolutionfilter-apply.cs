// HOW-TO: Apply Gaussian Blur to PNG Image Using Aspose.Imaging Convolution Filter in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                double[,] kernel = new double[,]
                {
                    { 0.0625, 0.125, 0.0625 },
                    { 0.125,  0.25,  0.125 },
                    { 0.0625, 0.125, 0.0625 }
                };

                var filterOptions = new ConvolutionFilterOptions(kernel);
                image.Filter(image.Bounds, filterOptions);

                var saveOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                image.Save(outputPath, saveOptions);
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
 * 1. When you need to soften the edges of a product photo in a PNG before publishing it on an e‑commerce website.
 * 2. When you want to reduce visual noise in scanned PNG documents by applying a Gaussian blur filter in a C# batch job.
 * 3. When creating a thumbnail generator that adds a subtle blur to background PNG layers for a mobile app UI.
 * 4. When preprocessing PNG assets for a game to achieve a smooth glow effect using Aspose.Imaging’s convolution filter.
 * 5. When automating image preparation for machine‑learning training data, applying Gaussian blur to PNG samples to augment the dataset.
 */
