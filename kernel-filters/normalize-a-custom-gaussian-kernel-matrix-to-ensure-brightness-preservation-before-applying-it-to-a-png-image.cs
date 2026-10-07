// HOW-TO: Normalize Gaussian Kernel and Apply Convolution Filter to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Sources;

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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                double[,] kernel = new double[,]
                {
                    { 0.0625, 0.125, 0.0625 },
                    { 0.125,  0.25,  0.125 },
                    { 0.0625, 0.125, 0.0625 }
                };

                double sum = 0;
                for (int i = 0; i < kernel.GetLength(0); i++)
                {
                    for (int j = 0; j < kernel.GetLength(1); j++)
                    {
                        sum += kernel[i, j];
                    }
                }

                if (sum != 0)
                {
                    for (int i = 0; i < kernel.GetLength(0); i++)
                    {
                        for (int j = 0; j < kernel.GetLength(1); j++)
                        {
                            kernel[i, j] /= sum;
                        }
                    }
                }

                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

                var options = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                raster.Save(outputPath, options);
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
 * 1. When you need to blur a PNG image while preserving overall brightness using a custom Gaussian kernel in a C# application.
 * 2. When you want to preprocess images for computer‑vision pipelines by applying a normalized convolution filter to maintain consistent lighting.
 * 3. When you are building a photo‑editing tool that requires smooth smoothing of PNG assets without darkening the picture.
 * 4. When you must ensure a custom kernel sums to one before filtering to avoid unintended exposure changes in .NET image processing.
 * 5. When you are automating batch image enhancement and need to load, filter, and save PNG files programmatically with Aspose.Imaging.
 */
