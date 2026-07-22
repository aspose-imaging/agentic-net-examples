// HOW-TO: Test Pixel Clamping After Over‑Sharpening Filter In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.bmp";
            string outputPath = "output.bmp";

            // Create a 2x2 test image with known colors
            int width = 2, height = 2;
            using (Image img = Image.Create(new BmpOptions(), width, height))
            {
                RasterImage raster = (RasterImage)img;
                int[] pixels = new int[]
                {
                    unchecked((int)0xFFFF0000), // Red
                    unchecked((int)0xFF00FF00), // Green
                    unchecked((int)0xFF0000FF), // Blue
                    unchecked((int)0xFFFFFFFF)  // White
                };
                raster.SaveArgb32Pixels(new Rectangle(0, 0, width, height), pixels);
                raster.Save(inputPath);
            }

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load image and apply a sharpen filter with an exaggerated factor to force overflow
            using (Image img = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)img;
                var options = new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions();
                options.Factor = 10.0; // Large factor to push pixel values beyond 255
                raster.Filter(raster.Bounds, options);
                raster.Save(outputPath);
            }

            // Verify output file exists
            if (!File.Exists(outputPath))
            {
                Console.Error.WriteLine($"File not found: {outputPath}");
                return;
            }

            // Load the filtered image and check that all channel values are clamped to 0‑255
            using (Image img = Image.Load(outputPath))
            {
                RasterImage raster = (RasterImage)img;
                int[] result = raster.LoadArgb32Pixels(new Rectangle(0, 0, raster.Width, raster.Height));

                bool allClamped = result.All(p =>
                {
                    byte a = (byte)((p >> 24) & 0xFF);
                    byte r = (byte)((p >> 16) & 0xFF);
                    byte g = (byte)((p >> 8) & 0xFF);
                    byte b = (byte)(p & 0xFF);
                    return a <= 255 && r <= 255 && g <= 255 && b <= 255;
                });

                Console.WriteLine(allClamped ? "Pixel clamping test passed." : "Pixel clamping test failed.");
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
 * 1. When you need to verify that Aspose.Imaging correctly clamps pixel values after applying a high‑strength sharpen filter to a BMP image in a C# unit test.
 * 2. When you want to create a small test bitmap with known ARGB colors to ensure image processing operations do not produce values outside the 0‑255 range.
 * 3. When you are writing automated tests to confirm that kernel coefficient overflow does not corrupt the output file during image filtering with Aspose.Imaging.
 * 4. When you need to programmatically generate input and output files, apply an exaggerated filter factor, and check that the resulting image file is successfully saved.
 * 5. When you are debugging image processing pipelines and require a reproducible scenario that forces pixel value overflow to validate the library’s clamping behavior.
 */
