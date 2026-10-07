// HOW-TO: Apply Motion Blur to PNG and Verify Brightness Consistency in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "template.png";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        try
        {
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                int[] beforePixels = raster.LoadArgb32Pixels(raster.Bounds);
                double beforeSum = 0;
                for (int i = 0; i < beforePixels.Length; i++)
                {
                    int argb = beforePixels[i];
                    int r = (argb >> 16) & 0xFF;
                    int g = (argb >> 8) & 0xFF;
                    int b = argb & 0xFF;
                    beforeSum += (r + g + b) / 3.0;
                }
                double beforeAvg = beforeSum / beforePixels.Length;

                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(5, 1.0, 315));

                int[] afterPixels = raster.LoadArgb32Pixels(raster.Bounds);
                double afterSum = 0;
                for (int i = 0; i < afterPixels.Length; i++)
                {
                    int argb = afterPixels[i];
                    int r = (argb >> 16) & 0xFF;
                    int g = (argb >> 8) & 0xFF;
                    int b = argb & 0xFF;
                    afterSum += (r + g + b) / 3.0;
                }
                double afterAvg = afterSum / afterPixels.Length;

                double diff = Math.Abs(afterAvg - beforeAvg);
                Console.WriteLine($"Brightness change: {diff}");

                PngOptions options = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                raster.Save(outputPath, options);
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
 * 1. When generating product mockups, you can blur a PNG template while ensuring the overall brightness stays the same for consistent visual appearance.
 * 2. When creating automated UI tests, you may apply a motion blur effect to screenshots and verify that the brightness level is unchanged to detect unintended color shifts.
 * 3. When preparing images for video game assets, you can simulate motion blur on PNG textures and confirm brightness stability to maintain lighting consistency.
 * 4. When building a batch image processing pipeline, you can use this code to apply a directional blur to each PNG file and automatically check that the average luminance is preserved.
 * 5. When developing a photo‑editing feature, you can demonstrate the motion‑blur filter and programmatically validate that it does not alter the image’s overall brightness.
 */
