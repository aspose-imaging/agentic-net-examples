using System;
using System.IO;
using System.Linq;
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
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

                double[,] kernel = new double[,]
                {
                    { 0.0, -1.0, 0.0 },
                    { -1.0, 5.0, -1.0 },
                    { 0.0, -1.0, 0.0 }
                };

                double sum = kernel.Cast<double>().Sum();
                if (Math.Abs(sum - 1.0) > 1e-6)
                {
                    Console.Error.WriteLine($"Kernel sum is {sum}, which is not 1. Filter will not be applied.");
                    raster.Save(outputPath);
                    return;
                }

                var options = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel, 1.0, 3);
                raster.Filter(raster.Bounds, options);
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
 * 1. When a developer wants to apply a custom sharpening convolution kernel to a PNG image but must ensure the kernel is normalized so the overall brightness of the image remains unchanged.
 * 2. When building an automated image‑processing pipeline that loads raster images, validates custom filter coefficients, and saves the filtered result to a specific output folder.
 * 3. When integrating Aspose.Imaging in a C# desktop application that lets users upload photos, apply user‑defined filters, and the code must reject kernels whose sum deviates from 1 to avoid over‑exposure.
 * 4. When performing batch processing of scanned documents where each file is checked for existence, a normalized convolution filter is applied, and the processed TIFF or PNG is saved without corrupting the original data.
 * 5. When creating a unit test for image‑filter logic that verifies the code correctly aborts the filter operation if the sum of the kernel coefficients is not exactly one, preventing unintended image artifacts.
 */