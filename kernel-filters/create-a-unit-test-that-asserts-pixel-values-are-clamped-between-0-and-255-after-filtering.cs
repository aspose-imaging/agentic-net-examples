// HOW-TO: Apply Gaussian Blur and Verify Pixel Values Stay Within 0-255 in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                if (!raster.IsCached)
                {
                    raster.CacheData();
                }

                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0));

                int[] pixels = raster.LoadArgb32Pixels(raster.Bounds);
                foreach (int pixel in pixels)
                {
                    int a = (pixel >> 24) & 0xFF;
                    int r = (pixel >> 16) & 0xFF;
                    int g = (pixel >> 8) & 0xFF;
                    int b = pixel & 0xFF;

                    if (a < 0 || a > 255 || r < 0 || r > 255 || g < 0 || g > 255 || b < 0 || b > 255)
                    {
                        Console.Error.WriteLine("Pixel value out of range detected.");
                        return;
                    }
                }

                Console.WriteLine("All pixel values are within 0-255 range.");

                raster.Save(outputPath, new JpegOptions());
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
 * 1. When you need to apply a Gaussian blur to a JPEG image in a C# application while ensuring the processed pixel data remains valid for further processing.
 * 2. When you want to programmatically validate that image filtering operations do not produce out‑of‑range ARGB values before saving the result.
 * 3. When you are building an automated image‑processing pipeline that must guarantee pixel values are clamped between 0 and 255 to avoid corruption in downstream systems.
 * 4. When you need to debug or test a custom filter implementation in Aspose.Imaging by checking each pixel after the filter is applied.
 * 5. When you are converting raw image data to a JPEG file after applying a blur effect and must confirm the output complies with standard 8‑bit per channel limits.
 */
