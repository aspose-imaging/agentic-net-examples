// HOW-TO: Apply Custom 5x5 Convolution Kernel to JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                if (!image.IsCached) image.CacheData();

                double[,] kernel = new double[5, 5]
                {
                    { 0, 0, 1, 0, 0 },
                    { 0, 1, 2, 1, 0 },
                    { 1, 2, 4, 2, 1 },
                    { 0, 1, 2, 1, 0 },
                    { 0, 0, 1, 0, 0 }
                };

                double sum = 0;
                foreach (double v in kernel) sum += v;
                if (sum != 0)
                {
                    for (int i = 0; i < 5; i++)
                        for (int j = 0; j < 5; j++)
                            kernel[i, j] /= sum;
                }

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                image.Filter(image.Bounds, filterOptions);

                var saveOptions = new JpegOptions();
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
 * 1. When you need to sharpen a JPEG photo by applying a custom 5x5 convolution filter in C#.
 * 2. When you want to implement a custom blur or smoothing effect on raster images using Aspose.Imaging.
 * 3. When you must normalize a kernel matrix before filtering to avoid brightness changes in the output image.
 * 4. When you are processing large images and need to cache raster data before applying a convolution filter.
 * 5. When you need to programmatically apply a custom kernel to an image and save the result as a JPEG file.
 */
