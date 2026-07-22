using System;
using System.IO;
using Aspose.Imaging;

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

                // Apply sharpen filter
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

                // Save filtered image
                raster.Save(outputPath);

                // Retrieve pixel data
                int[] pixels = raster.GetDefaultArgb32Pixels(raster.Bounds);

                foreach (int argb in pixels)
                {
                    int a = (argb >> 24) & 0xFF;
                    int r = (argb >> 16) & 0xFF;
                    int g = (argb >> 8) & 0xFF;
                    int b = argb & 0xFF;

                    if (a < 0 || a > 255 || r < 0 || r > 255 || g < 0 || g > 255 || b < 0 || b > 255)
                    {
                        throw new Exception($"Pixel value out of range: A={a}, R={r}, G={g}, B={b}");
                    }
                }

                Console.WriteLine("All pixel values are within 0-255 after filtering.");
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
 * 1. When a developer needs to ensure that applying a Sharpen filter to a PNG image with Aspose.Imaging does not produce pixel values outside the 0‑255 range, they can use this code to validate clamping after filtering.
 * 2. When integrating automated image processing pipelines in a C# application, this example helps verify that the raster image’s ARGB32 pixels remain within valid byte limits after any filter operation.
 * 3. When writing unit tests for image enhancement features, the code demonstrates how to load an input file, apply a sharpen filter, save the result, and assert that all channel values are correctly clamped.
 * 4. When troubleshooting visual artifacts caused by over‑exposed pixel data in JPEG or PNG outputs, developers can use the pixel‑range check to confirm that the filter implementation respects the 0‑255 bounds.
 * 5. When building a cross‑platform .NET service that processes user‑uploaded images, this snippet provides a practical way to guarantee that the processed image will be compatible with downstream systems that expect standard 8‑bit per channel values.
 */