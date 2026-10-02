// HOW-TO: Apply Gaussian Blur to JPEG Images in C# with Aspose.Imaging (Aspose.Imaging for .NET)
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

                image.Filter(image.Bounds, new GaussianBlurFilterOptions(5, 1.0));

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
 * 1. When a Blazor WebAssembly app needs to let users upload photos and automatically soften them with a Gaussian blur before saving as JPEG.
 * 2. When you want to perform client‑side image preprocessing in C# to reduce detail for privacy or artistic effect without sending the file to a server.
 * 3. When an online photo editor requires fast, cached raster image handling and needs to apply a blur filter to large JPEGs directly in the browser.
 * 4. When you must ensure uploaded images are processed locally, applying a Gaussian blur with specific radius and sigma values before storing them in a cloud bucket.
 * 5. When a C# web application needs to convert raw user uploads into optimized JPEGs after applying a blur filter for thumbnails or preview images.
 */
