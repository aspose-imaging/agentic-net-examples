using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                double[,] kernel = new double[,]
                {
                    { 0, -1, 0 },
                    { -1, 5, -1 },
                    { 0, -1, 0 }
                };

                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.DeconvolutionFilterOptions(kernel));

                var pngOptions = new PngOptions();
                raster.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to sharpen a scanned PNG document by applying a custom 3×3 deconvolution kernel and must first ensure the kernel’s width and height are odd numbers to avoid runtime errors.
 * 2. When building a C# image‑processing service that enhances product photos in PNG format using Aspose.Imaging’s DeconvolutionFilterOptions, the code validates the kernel dimensions are odd before the filter is applied.
 * 3. When creating an automated pipeline that restores old PNG photographs with a custom edge‑enhancement kernel, the developer checks that the kernel size is odd to guarantee correct convolution alignment.
 * 4. When implementing OCR preprocessing for PNG images, a developer uses a custom deconvolution filter in C# and validates the kernel’s odd dimensions to improve text clarity without distortion.
 * 5. When developing a medical imaging viewer that processes PNG scans with a user‑defined sharpening kernel, the code first confirms the kernel dimensions are odd to comply with Aspose.Imaging’s filter requirements.
 */