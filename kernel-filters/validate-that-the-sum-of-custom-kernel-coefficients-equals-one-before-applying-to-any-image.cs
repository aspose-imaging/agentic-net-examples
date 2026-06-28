using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output\\result.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                double[,] kernel = new double[,]
                {
                    { 0.0, 1.0, 0.0 },
                    { 1.0, -4.0, 1.0 },
                    { 0.0, 1.0, 0.0 }
                };

                double sum = 0;
                foreach (double v in kernel)
                {
                    sum += v;
                }

                if (Math.Abs(sum - 1.0) > 1e-6)
                {
                    Console.Error.WriteLine("Kernel coefficients sum is not equal to 1.");
                    return;
                }

                var options = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel, 1.0, 3);
                raster.Filter(raster.Bounds, options);

                var saveOptions = new PngOptions();
                raster.Save(outputPath, saveOptions);
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
 * 1. When processing medical imaging scans in PNG format and applying a custom edge‑enhancement convolution kernel, a developer must verify that the kernel coefficients sum to one to preserve the overall brightness of the image.
 * 2. When building an automated photo‑editing pipeline that uses Aspose.Imaging to apply user‑defined sharpening filters, checking the kernel sum prevents unintended darkening or brightening of the output PNG files.
 * 3. When implementing a real‑time video‑frame analysis tool in C# that reuses the same convolution matrix for each frame, validating the coefficient total ensures consistent luminance across all processed frames.
 * 4. When creating a batch‑processing utility that reads input PNGs, applies a Laplacian‑type filter, and saves results to a designated folder, the sum‑check guards against malformed kernels that could corrupt the saved images.
 * 5. When integrating a custom convolution filter into a desktop application that lets end‑users adjust kernel values, the code must confirm the coefficients add up to one before calling raster.Filter to avoid unexpected visual artifacts.
 */