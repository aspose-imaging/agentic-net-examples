using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input/input.png";
        string outputPath = "output/output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                double[,] kernel = new double[,]
                {
                    { 0, -1, 0 },
                    { -1, 5, -1 },
                    { 0, -1, 0 }
                };

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel, 1.0, 0);

                raster.Filter(raster.Bounds, filterOptions);

                raster.Save(outputPath);
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
 * 1. When a C# developer needs to sharpen PNG images in a batch processing pipeline using Aspose.Imaging’s convolution filter with a custom 3×3 kernel.
 * 2. When an application must validate that the custom kernel matrix dimensions match the required size before applying a filter to avoid runtime errors in image processing.
 * 3. When a .NET service processes user‑uploaded photos and wants to enhance edge details by applying a Laplacian‑like kernel to raster images.
 * 4. When a desktop utility needs to load an image, apply a convolution filter, and save the result to a different folder while handling missing files gracefully.
 * 5. When a developer is integrating Aspose.Imaging into a C# project to perform real‑time image sharpening on PNG files before displaying them in a UI.
 */