// HOW-TO: Apply Normalized Convolution Filter to PNG Template in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "template.png";
        string outputPath = "output\\result.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            double[,] kernel = new double[,]
            {
                { 0, -1, 0 },
                { -1, 5, -1 },
                { 0, -1, 0 }
            };

            double sum = 0;
            foreach (double v in kernel)
                sum += v;

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

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, filterOptions);

                var pngOptions = new PngOptions();
                raster.Save(outputPath, pngOptions);
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
 * 1. When you need to sharpen a PNG logo by applying a custom convolution kernel before displaying it in a UI.
 * 2. When you want to enhance edges in a PNG template while preserving overall brightness for high‑contrast thumbnails.
 * 3. When you must normalize a user‑defined kernel so its values sum to one to avoid unintended brightness shifts during image processing.
 * 4. When you are creating a C# batch job that loads PNG files, applies a specific filter, and saves the filtered images to a designated output folder.
 * 5. When you require programmatic control over image detail enhancement in PNG assets using Aspose.Imaging’s ConvolutionFilterOptions.
 */
