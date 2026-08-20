// HOW-TO: Return Blurred WebP Image As FileResult In ASP.NET Core MVC C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.webp";
        string outputPath = "output.webp";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Apply a Gaussian blur filter to the entire image
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Save the processed image as WebP
                raster.Save(outputPath, new WebPOptions());
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
 * 1. When you need to apply a Gaussian blur to user‑uploaded WebP photos and send the processed image back to the browser in an ASP.NET Core MVC application.
 * 2. When building a web service that generates softened thumbnails of WebP graphics on the fly and returns them as downloadable files.
 * 3. When creating an API endpoint that sanitizes images by blurring sensitive areas before delivering the result as a FileResult.
 * 4. When implementing a server‑side image filter for a content management system that stores and serves blurred WebP images directly to clients.
 * 5. When optimizing a photo‑editing web app that applies a blur effect to WebP pictures and streams the edited file without saving it to disk.
 */
