// HOW-TO: Apply Motion Blur to PNG and Verify Brightness with Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

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

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                // Load original pixels for brightness check
                int[] beforePixels = raster.LoadArgb32Pixels(raster.Bounds);

                // Apply motion blur (size 9, angle 180)
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.GetBlurMotion(9, 180)));

                // Load pixels after filter
                int[] afterPixels = raster.LoadArgb32Pixels(raster.Bounds);

                // Compute average brightness before and after
                double beforeBrightness = 0;
                double afterBrightness = 0;
                for (int i = 0; i < beforePixels.Length; i++)
                {
                    int argb = beforePixels[i];
                    int r = (argb >> 16) & 0xFF;
                    int g = (argb >> 8) & 0xFF;
                    int b = argb & 0xFF;
                    beforeBrightness += (r + g + b) / 3.0;
                }
                for (int i = 0; i < afterPixels.Length; i++)
                {
                    int argb = afterPixels[i];
                    int r = (argb >> 16) & 0xFF;
                    int g = (argb >> 8) & 0xFF;
                    int b = argb & 0xFF;
                    afterBrightness += (r + g + b) / 3.0;
                }
                beforeBrightness /= beforePixels.Length;
                afterBrightness /= afterPixels.Length;

                const double tolerance = 0.01;
                if (Math.Abs(beforeBrightness - afterBrightness) > tolerance)
                {
                    Console.WriteLine("Brightness changed after applying motion blur.");
                }
                else
                {
                    Console.WriteLine("Brightness remains unchanged after applying motion blur.");
                }

                // Save the processed image
                var saveOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                raster.Save(outputPath, saveOptions);
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
 * 1. When you need to add a realistic motion‑blur effect to a PNG while ensuring the overall image brightness stays the same, this code shows how to do it with Aspose.Imaging in C#.
 * 2. When validating that a blur filter does not unintentionally darken or brighten a product photo before publishing it on an e‑commerce site, you can use this example to compare pixel brightness before and after the filter.
 * 3. When building an automated graphics pipeline that applies motion blur to frames of an animation and must keep exposure consistent across frames, the snippet demonstrates loading, filtering, and brightness verification.
 * 4. When creating a diagnostic tool to test the impact of different convolution kernels on PNG assets in a game’s asset pipeline, this code provides a baseline for measuring brightness preservation.
 * 5. When teaching image‑processing concepts such as convolution filters and brightness analysis to junior developers, the example offers a clear, hands‑on C# implementation using Aspose.Imaging.
 */
