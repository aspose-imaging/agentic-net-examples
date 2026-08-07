using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output/output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define a custom kernel (3x3 example)
            double[,] kernel2D = new double[,]
            {
                { 0, -1, 0 },
                { -1, 5, -1 },
                { 0, -1, 0 }
            };

            // Validate kernel dimensions: must be square and odd-sized
            int rows = kernel2D.GetLength(0);
            int cols = kernel2D.GetLength(1);
            if (rows != cols || rows % 2 == 0)
            {
                Console.Error.WriteLine("Kernel must be square with odd dimensions.");
                return;
            }

            // Load the PNG image, apply deconvolution filter, and save
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new DeconvolutionFilterOptions(kernel2D));
                raster.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to sharpen a PNG image using a custom 3x3 kernel and must ensure the kernel is square and odd‑sized before applying the deconvolution filter with Aspose.Imaging for .NET.
 * 2. When building an automated image‑processing pipeline that loads PNG files, validates user‑provided convolution kernels, and applies deconvolution to improve edge definition.
 * 3. When creating a desktop C# application that lets users upload PNG graphics, specify their own filter matrix, and the code must reject even‑sized or non‑square kernels to prevent runtime errors.
 * 4. When integrating Aspose.Imaging into a server‑side service that receives PNG images and custom kernel data via API, the service must verify the kernel dimensions are odd before performing deconvolution for noise reduction.
 * 5. When performing batch processing of PNG assets in a folder, a developer uses this code to ensure each custom kernel meets the required odd‑dimension rule before applying the deconvolution filter and saving the results.
 */