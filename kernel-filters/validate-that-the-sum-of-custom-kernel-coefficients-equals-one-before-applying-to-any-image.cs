// HOW-TO: Validate Convolution Kernel Sum Equals One Before Applying Filter in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage raster = image as Aspose.Imaging.RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                double[,] kernel = new double[,]
                {
                    { 0.0, 0.2, 0.0 },
                    { 0.2, 0.2, 0.2 },
                    { 0.0, 0.2, 0.0 }
                };

                double sum = 0.0;
                foreach (double value in kernel)
                {
                    sum += value;
                }

                if (Math.Abs(sum - 1.0) > 1e-6)
                {
                    Console.Error.WriteLine($"Kernel coefficients sum to {sum}, which is not equal to 1.");
                    return;
                }

                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));
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
 * 1. When you need to ensure a custom blur or sharpening kernel does not unintentionally alter image brightness before applying it to a PNG in a .NET application.
 * 2. When processing raster images in C# and you must verify that the convolution matrix is normalized to preserve overall pixel intensity.
 * 3. When building an image‑processing pipeline that applies user‑defined filters and you want to catch invalid kernels early to avoid corrupted output files.
 * 4. When converting or enhancing photographs programmatically and you need to guarantee the filter coefficients sum to 1 to maintain color balance.
 * 5. When automating batch image edits and you require a safety check that prevents applying non‑normalized kernels that could cause over‑exposure or darkening.
 */
