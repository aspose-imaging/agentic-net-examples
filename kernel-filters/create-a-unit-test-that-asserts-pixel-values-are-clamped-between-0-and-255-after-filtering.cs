using System;
using System.IO;
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

            // Load image and apply a filter
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage rasterImage = (Aspose.Imaging.RasterImage)image;

                rasterImage.Filter(rasterImage.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

                PngOptions pngOptions = new PngOptions();
                rasterImage.Save(outputPath, pngOptions);
            }

            // Verify pixel values are clamped between 0 and 255
            using (Aspose.Imaging.Image resultImage = Aspose.Imaging.Image.Load(outputPath))
            {
                Aspose.Imaging.RasterImage resultRaster = (Aspose.Imaging.RasterImage)resultImage;
                int width = resultRaster.Width;
                int height = resultRaster.Height;
                bool allInRange = true;

                for (int y = 0; y < height && allInRange; y++)
                {
                    for (int x = 0; x < width && allInRange; x++)
                    {
                        int argb = resultRaster.GetArgb32Pixel(x, y);
                        int a = (argb >> 24) & 0xFF;
                        int r = (argb >> 16) & 0xFF;
                        int g = (argb >> 8) & 0xFF;
                        int b = argb & 0xFF;

                        if (a < 0 || a > 255 ||
                            r < 0 || r > 255 ||
                            g < 0 || g > 255 ||
                            b < 0 || b > 255)
                        {
                            allInRange = false;
                        }
                    }
                }

                if (allInRange)
                {
                    Console.WriteLine("Pixel values are within the 0-255 range.");
                }
                else
                {
                    Console.Error.WriteLine("Pixel values out of the 0-255 range detected.");
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
 * 1. When a developer needs to ensure that applying a sharpen filter to a PNG image using Aspose.Imaging in C# does not produce pixel values outside the 0‑255 range, they can use this unit test to validate clamping.
 * 2. When integrating image preprocessing into an automated build pipeline, a developer can run this test to confirm that filtered raster images remain within valid ARGB byte limits before deployment.
 * 3. When creating a photo‑editing web service that sharpens user‑uploaded PNG files, the code helps verify that the service returns correctly clamped pixel data, preventing corrupted output.
 * 4. When performing batch image processing with Aspose.Imaging’s FilterOptions, a developer can employ this test to detect any overflow errors caused by high‑strength sharpen parameters.
 * 5. When writing unit tests for a C# library that manipulates raster images, this example demonstrates how to assert that the resulting image’s alpha, red, green, and blue channels stay between 0 and 255 after filtering.
 */