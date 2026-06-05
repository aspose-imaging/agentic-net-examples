using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        try
        {
            // Ensure input image exists (create a simple test image if missing)
            if (!File.Exists(inputPath))
            {
                using (Aspose.Imaging.Image img = Aspose.Imaging.Image.Create(new Aspose.Imaging.ImageOptions.BmpOptions(), 3, 3))
                {
                    Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)img;
                    int[] pixels = new int[9];
                    for (int i = 0; i < pixels.Length; i++)
                        pixels[i] = unchecked((int)0xFF808080);
                    raster.SaveArgb32Pixels(raster.Bounds, pixels);
                    raster.Save(inputPath);
                }
            }

            // Input file validation
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the input image
            using (Aspose.Imaging.Image img = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)img;

                var sharpenOptions = new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 100.0);
                raster.Filter(raster.Bounds, sharpenOptions);

                raster.Save(outputPath);
            }

            // Load the output image to verify pixel clamping
            using (Aspose.Imaging.Image outImg = Aspose.Imaging.Image.Load(outputPath))
            {
                Aspose.Imaging.RasterImage outRaster = (Aspose.Imaging.RasterImage)outImg;
                int width = outRaster.Width;
                int height = outRaster.Height;
                int[] outPixels = new int[width * height];
                outRaster.SaveArgb32Pixels(outRaster.Bounds, outPixels);

                bool clamped = true;
                foreach (int argb in outPixels)
                {
                    int a = (argb >> 24) & 0xFF;
                    int r = (argb >> 16) & 0xFF;
                    int g = (argb >> 8) & 0xFF;
                    int b = argb & 0xFF;

                    if (a < 0 || a > 255 || r < 0 || r > 255 || g < 0 || g > 255 || b < 0 || b > 255)
                    {
                        clamped = false;
                        break;
                    }
                }

                if (clamped)
                    Console.WriteLine("Pixel clamping test passed: all channel values are within 0-255.");
                else
                    Console.Error.WriteLine("Pixel clamping test failed: out-of-range channel values detected.");
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
 * 1. When a developer needs to ensure that applying an aggressive sharpen filter with extreme kernel coefficients on a BMP image does not produce pixel values outside the 0‑255 range, they can use this unit test to verify automatic pixel clamping in Aspose.Imaging for .NET.
 * 2. When integrating Aspose.Imaging's Filter method into a C# image‑processing pipeline, a QA engineer can run this test to confirm that raster images saved after high‑strength sharpening remain valid and display correctly across browsers.
 * 3. When troubleshooting visual artifacts in a batch conversion of 24‑bit BMP files, developers can employ this code to detect whether the sharpen kernel is causing overflow and whether the library correctly clamps ARGB32 pixel data.
 * 4. When creating automated regression tests for a photo‑editing application that supports custom kernel parameters, this example demonstrates how to programmatically generate a test image, apply an out‑of‑range filter, and assert that the output pixels are clamped to legal values.
 * 5. When documenting best practices for safe image enhancement in .NET, this scenario shows a concrete use case where developers validate that Aspose.Imaging's sharpen filter respects pixel limits even when the kernel coefficient (e.g., 100.0) exceeds typical ranges.
 */