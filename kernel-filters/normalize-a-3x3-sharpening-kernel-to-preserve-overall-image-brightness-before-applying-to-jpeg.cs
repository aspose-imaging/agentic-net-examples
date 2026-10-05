// HOW-TO: Normalize Sharpening Kernel and Apply Convolution Filter to JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                double[,] kernel = new double[,]
                {
                    { 0, -1, 0 },
                    { -1, 5, -1 },
                    { 0, -1, 0 }
                };

                double sum = 0;
                for (int i = 0; i < kernel.GetLength(0); i++)
                {
                    for (int j = 0; j < kernel.GetLength(1); j++)
                    {
                        sum += kernel[i, j];
                    }
                }

                double factor = sum != 0 ? sum : 1;
                double[,] normalizedKernel = new double[3, 3];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        normalizedKernel[i, j] = kernel[i, j] / factor;
                    }
                }

                var filterOptions = new ConvolutionFilterOptions(normalizedKernel);
                image.Filter(image.Bounds, filterOptions);

                var jpegOptions = new JpegOptions();
                jpegOptions.Source = new FileCreateSource(outputPath, false);
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
 * 1. When you need to enhance the details of a JPEG photo while keeping its overall brightness unchanged using Aspose.Imaging in C#.
 * 2. When you want to apply a custom 3x3 sharpening filter to batch‑process images without introducing over‑exposure.
 * 3. When you must normalize a convolution kernel to avoid brightness shifts before saving the result as a new JPEG file.
 * 4. When you are building an automated image‑processing pipeline that sharpens pictures and writes them directly to disk with Aspose.Imaging.
 * 5. When you need to ensure a sharpening operation works on any JPEG input, handling missing files and creating output directories safely.
 */
