// HOW-TO: Apply Custom Sharpen Convolution Filter to JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;

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
            using (Aspose.Imaging.RasterImage image = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                if (!image.IsCached)
                    image.CacheData();

                double[,] kernel = new double[,]
                {
                    { 0, -1, 0 },
                    { -1, 5, -1 },
                    { 0, -1, 0 }
                };

                int rows = kernel.GetLength(0);
                int cols = kernel.GetLength(1);
                if (rows != cols || rows % 2 == 0)
                {
                    Console.Error.WriteLine("Invalid kernel dimensions. Kernel must be square with odd size.");
                    return;
                }

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                image.Filter(image.Bounds, filterOptions);
                image.Save(outputPath);
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
 * 1. When you need to sharpen a JPEG image in a .NET application using a custom 3×3 convolution kernel with Aspose.Imaging.
 * 2. When you must ensure a user‑provided kernel is square and odd‑sized before applying a filter to avoid runtime errors.
 * 3. When processing large images that require caching the raster data before applying a convolution filter in C#.
 * 4. When you want to programmatically apply a custom image filter and save the result to a new file path on disk.
 * 5. When integrating Aspose.Imaging into an automated workflow that validates kernel dimensions and applies the filter to batch‑process photos.
 */
