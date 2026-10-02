// HOW-TO: Validate Odd Kernel Size Before Deconvolution Filter on PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

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

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                double[,] kernel = new double[,]
                {
                    { 1, 2, 1 },
                    { 2, 4, 2 },
                    { 1, 2, 1 }
                };

                int width = kernel.GetLength(0);
                int height = kernel.GetLength(1);
                if (width % 2 == 0 || height % 2 == 0)
                {
                    Console.Error.WriteLine("Kernel dimensions must be odd.");
                    return;
                }

                var deconvOptions = new Aspose.Imaging.ImageFilters.FilterOptions.DeconvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, deconvOptions);

                var saveOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
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
 * 1. When you need to sharpen a PNG image using a custom convolution kernel and must ensure the kernel dimensions are odd to avoid runtime errors.
 * 2. When processing scanned documents in C# and applying a deconvolution filter to improve clarity while validating kernel size for compatibility with Aspose.Imaging.
 * 3. When building an automated image‑enhancement pipeline that applies custom deblurring kernels to PNG files and requires pre‑validation of kernel dimensions.
 * 4. When creating a desktop application that lets users upload PNGs and apply user‑defined filters, you must check the kernel is odd before calling the Filter method.
 * 5. When performing scientific image analysis in .NET and using a Gaussian‑like kernel for deconvolution, validating odd dimensions prevents incorrect padding and ensures accurate results.
 */
