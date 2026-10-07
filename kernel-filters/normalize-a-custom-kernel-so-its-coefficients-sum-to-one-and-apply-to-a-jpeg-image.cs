// HOW-TO: Apply Normalized Custom Convolution Kernel to JPEG Image in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            double[,] kernel = new double[,]
            {
                { 0, 0, 0, 0, 0 },
                { 0, 0.04, 0.04, 0.04, 0 },
                { 0, 0.04, 0.04, 0.04, 0 },
                { 0, 0.04, 0.04, 0.04, 0 },
                { 0, 0, 0, 0, 0 }
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

            var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                image.Filter(image.Bounds, filterOptions);

                var jpegOptions = new JpegOptions();
                image.Save(outputPath, jpegOptions);
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
 * 1. When you need to sharpen, blur, or edge‑detect a JPEG using a custom filter while preserving overall brightness by normalizing the kernel.
 * 2. When you want to preprocess images for a machine‑learning pipeline in a .NET app by applying a user‑defined convolution mask that sums to one.
 * 3. When you must batch‑process a folder of photos and ensure custom kernel coefficients are normalized to avoid unintended color shifts.
 * 4. When you are building a photo‑editing tool that lets users create their own kernels and safely apply them to JPEG files in C#.
 * 5. When you need to integrate image filtering into a C# service that loads, filters, and saves JPEG images without manually calculating kernel normalization.
 */
