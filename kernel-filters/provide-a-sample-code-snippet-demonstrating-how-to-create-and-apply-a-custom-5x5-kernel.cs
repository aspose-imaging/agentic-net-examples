// HOW-TO: Apply Custom 5x5 Convolution Kernel to PNG with Aspose Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

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

            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;

                double[,] kernel = new double[5, 5]
                {
                    { 0, 0, 1, 0, 0 },
                    { 0, 1, 2, 1, 0 },
                    { 1, 2, 4, 2, 1 },
                    { 0, 1, 2, 1, 0 },
                    { 0, 0, 1, 0, 0 }
                };

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);

                rasterImage.Filter(rasterImage.Bounds, filterOptions);

                rasterImage.Save(outputPath);
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
 * 1. When you need to sharpen or enhance details in a PNG image by applying a custom 5×5 convolution matrix using C# and Aspose.Imaging.
 * 2. When you want to implement a bespoke edge‑detection filter for JPEG or BMP files in a .NET application without relying on built‑in filters.
 * 3. When you must process scanned documents to improve readability by applying a weighted blur kernel before saving the result as a PNG.
 * 4. When you are building a photo‑editing tool that lets users define their own kernel values for artistic effects and need to apply it programmatically.
 * 5. When you need to batch‑process a folder of images, applying the same custom convolution filter to each file and saving the transformed images to a new directory.
 */
