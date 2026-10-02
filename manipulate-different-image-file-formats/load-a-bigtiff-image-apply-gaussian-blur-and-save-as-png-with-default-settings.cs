// HOW-TO: Apply Gaussian Blur to BigTIFF and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var bigTiff = (Aspose.Imaging.FileFormats.BigTiff.BigTiffImage)Image.Load(inputPath))
            {
                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions
                {
                    Sigma = 2.0
                };
                bigTiff.Filter(bigTiff.Bounds, blurOptions);

                var pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                bigTiff.Save(outputPath, pngOptions);
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
 * 1. When you need to reduce noise in a high‑resolution BigTIFF satellite image before converting it to a web‑friendly PNG.
 * 2. When a medical imaging application must blur patient scans stored as BigTIFF for privacy and then export them as PNG thumbnails.
 * 3. When an archival system requires applying a Gaussian blur to large scanned documents in BigTIFF format before creating PNG previews.
 * 4. When a GIS tool wants to preprocess massive GeoTIFF layers by smoothing them and saving the result as PNG for quick visualization.
 * 5. When a batch‑processing script must automatically load BigTIFF files, apply a blur filter, and output PNGs for downstream machine‑learning pipelines.
 */
