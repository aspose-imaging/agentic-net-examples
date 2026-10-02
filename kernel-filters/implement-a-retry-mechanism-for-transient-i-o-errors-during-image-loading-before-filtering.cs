// HOW-TO: Retry Loading Image With Transient I/O Errors And Apply Gaussian Blur In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        const string inputPath = "input\\input.jpg";
        const string outputPath = "output\\output.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            const int maxAttempts = 3;
            int attempt = 0;
            RasterImage raster = null;

            while (attempt < maxAttempts)
            {
                try
                {
                    var image = Image.Load(inputPath);
                    raster = (RasterImage)image;
                    break;
                }
                catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
                {
                    attempt++;
                    if (attempt >= maxAttempts)
                    {
                        Console.Error.WriteLine($"Failed to load image after {maxAttempts} attempts: {ex.Message}");
                        return;
                    }
                }
            }

            if (raster == null)
            {
                Console.Error.WriteLine("Unable to load image.");
                return;
            }

            using (raster)
            {
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0);
                raster.Filter(raster.Bounds, filterOptions);

                var jpegOptions = new JpegOptions();
                raster.Save(outputPath, jpegOptions);
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
 * 1. When a batch job must process user‑uploaded photos that may be temporarily locked, this code retries loading the file, applies a Gaussian blur, and saves the result as a JPEG.
 * 2. When an automated image‑pipeline runs on a network share prone to occasional access errors, the retry loop ensures the image is loaded before applying a blur filter.
 * 3. When a desktop application needs to gracefully handle transient I/O failures while reading a JPEG, blur it for privacy, and write the processed image back.
 * 4. When a server‑side service processes incoming JPG files and must guarantee the filter is applied even if the file is momentarily unavailable due to file‑system latency.
 * 5. When integrating Aspose.Imaging into a C# workflow that requires robust error handling for unauthorized or locked files before performing Gaussian blur and saving the output.
 */
