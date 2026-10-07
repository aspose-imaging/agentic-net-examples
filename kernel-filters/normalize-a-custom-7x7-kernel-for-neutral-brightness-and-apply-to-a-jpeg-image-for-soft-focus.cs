// HOW-TO: Apply a 7x7 Normalized Convolution Kernel for Soft Focus to JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            double[,] kernel = new double[,]
            {
                { 1.0/49, 1.0/49, 1.0/49, 1.0/49, 1.0/49, 1.0/49, 1.0/49 },
                { 1.0/49, 1.0/49, 1.0/49, 1.0/49, 1.0/49, 1.0/49, 1.0/49 },
                { 1.0/49, 1.0/49, 1.0/49, 1.0/49, 1.0/49, 1.0/49, 1.0/49 },
                { 1.0/49, 1.0/49, 1.0/49, 1.0/49, 1.0/49, 1.0/49, 1.0/49 },
                { 1.0/49, 1.0/49, 1.0/49, 1.0/49, 1.0/49, 1.0/49, 1.0/49 },
                { 1.0/49, 1.0/49, 1.0/49, 1.0/49, 1.0/49, 1.0/49, 1.0/49 },
                { 1.0/49, 1.0/49, 1.0/49, 1.0/49, 1.0/49, 1.0/49, 1.0/49 }
            };

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                image.Filter(image.Bounds, new ConvolutionFilterOptions(kernel));

                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 90,
                    Source = new FileCreateSource(outputPath, false)
                };

                image.Save(outputPath, jpegOptions);
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
 * 1. When you need to blur a JPEG photo slightly to create a soft‑focus effect without changing its overall brightness.
 * 2. When you want to apply a custom 7×7 averaging filter to reduce noise in a raster image before saving it as a high‑quality JPEG.
 * 3. When you must process images in a batch script that normalizes the kernel so the filtered image retains the original exposure.
 * 4. When you are building a C# application that programmatically loads, filters, and re‑encodes JPEG files using Aspose.Imaging.
 * 5. When you need to ensure the output directory exists and handle missing input files gracefully while applying image convolution.
 */
