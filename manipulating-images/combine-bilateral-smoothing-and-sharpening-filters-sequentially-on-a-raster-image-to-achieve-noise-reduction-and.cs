// HOW-TO: Apply Bilateral Smoothing Followed By Sharpen Filter To JPEG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

namespace ImagingNet
{
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
                    image.Filter(image.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.BilateralSmoothingFilterOptions());
                    image.Filter(image.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions());
                    image.Save(outputPath, new JpegOptions());
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to clean up noisy JPEG photos taken in low light while preserving edge detail for a web gallery, you can apply bilateral smoothing then sharpening with Aspose.Imaging in C#.
 * 2. When preparing product images for an e‑commerce site, you can reduce sensor noise and enhance product outlines before saving the final JPEG using the combined filters.
 * 3. When processing scanned documents that contain grainy backgrounds, the code can smooth the background and sharpen text edges to improve readability.
 * 4. When building a desktop photo‑editing tool that offers a “noise‑reduce and sharpen” feature, this snippet demonstrates how to implement it with Aspose.Imaging’s filter API.
 * 5. When automating batch conversion of raw camera files to JPEGs with consistent noise reduction and edge clarity, the bilateral smoothing followed by a sharpen filter ensures uniform quality across all images.
 */
