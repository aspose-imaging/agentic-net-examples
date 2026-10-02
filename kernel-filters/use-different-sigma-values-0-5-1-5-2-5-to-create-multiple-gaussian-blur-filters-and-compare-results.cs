// HOW-TO: Apply Multiple Gaussian Blur Levels to JPEG in C# with Aspose Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = "output";

            double[] sigmas = new double[] { 0.5, 1.5, 2.5 };
            foreach (double sigma in sigmas)
            {
                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    if (!image.IsCached) image.CacheData();

                    var options = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, sigma);
                    image.Filter(image.Bounds, options);

                    string outputPath = Path.Combine(outputDir, $"blur_sigma_{sigma}.jpg");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    image.Save(outputPath);
                }
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
 * 1. When you need to create preview thumbnails with varying blur strengths for a photo gallery.
 * 2. When you want to compare the visual effect of different Gaussian sigma values on a JPEG before choosing the optimal blur for a UI background.
 * 3. When you are building an automated pipeline that generates multiple blurred versions of an image for machine‑learning data augmentation.
 * 4. When you must apply consistent kernel size while experimenting with sigma to fine‑tune the softness of product images for an e‑commerce site.
 * 5. When you need to batch‑process a single source image and save each blurred result to a separate file for quality‑control testing.
 */
