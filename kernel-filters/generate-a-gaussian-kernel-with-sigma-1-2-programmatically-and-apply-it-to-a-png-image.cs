// HOW-TO: Apply Gaussian Blur With Sigma 1.2 To PNG Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            double sigma = 1.2;
            int size = 2 * (int)Math.Ceiling(3 * sigma) + 1;
            double[,] kernel = new double[size, size];
            double sum = 0.0;
            int half = size / 2;
            double twoSigmaSq = 2 * sigma * sigma;

            for (int y = -half; y <= half; y++)
            {
                for (int x = -half; x <= half; x++)
                {
                    double value = Math.Exp(-(x * x + y * y) / twoSigmaSq);
                    kernel[y + half, x + half] = value;
                    sum += value;
                }
            }

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    kernel[y, x] /= sum;
                }
            }

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                var filterOptions = new ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, filterOptions);

                var saveOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                raster.Save(outputPath, saveOptions);
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
 * 1. When you need to smooth a PNG photograph to reduce noise before OCR processing.
 * 2. When you want to create a custom blur effect with a specific sigma value for a web‑ready image.
 * 3. When you must programmatically generate a Gaussian kernel and apply it to images in a batch‑processing pipeline.
 * 4. When you are building a C# desktop application that requires real‑time image filtering without external libraries.
 * 5. When you need to preserve PNG transparency while applying a convolution filter for a graphics‑editing tool.
 */
