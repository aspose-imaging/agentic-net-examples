// HOW-TO: Apply 5x5 Gaussian Deconvolution Filter to JPEG in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                if (!image.IsCached)
                    image.CacheData();

                double[,] kernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetGaussian(5, 1.0);
                var deconvOptions = new DeconvolutionFilterOptions(kernel);
                image.Filter(image.Bounds, deconvOptions);

                var saveOptions = new JpegOptions();
                image.Save(outputPath, saveOptions);
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
 * 1. When you need to sharpen a blurry JPEG photo by applying a 5×5 Gaussian deconvolution in a C# application.
 * 2. When you want to improve the clarity of scanned documents before saving them as JPEG files using Aspose.Imaging.
 * 3. When you are building an automated image‑processing pipeline that removes blur from batch‑loaded images with a specific sigma value.
 * 4. When you need to enhance medical or scientific images by deconvolving a known point‑spread function in a .NET environment.
 * 5. When you are creating a desktop tool that restores detail in low‑resolution pictures by applying a custom 5×5 kernel filter.
 */
