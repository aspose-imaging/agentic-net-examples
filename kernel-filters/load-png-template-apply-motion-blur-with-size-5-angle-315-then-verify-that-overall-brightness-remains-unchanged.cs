// HOW-TO: Apply Motion Blur to PNG and Verify Brightness Consistency in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "template.png";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                Rectangle bounds = raster.Bounds;

                int[] beforePixels = raster.GetDefaultArgb32Pixels(bounds);
                double beforeBrightness = 0;
                foreach (int pixel in beforePixels)
                {
                    Color c = Color.FromArgb(pixel);
                    beforeBrightness += (c.R + c.G + c.B) / 3.0;
                }
                beforeBrightness /= beforePixels.Length;

                var motionOptions = new MotionWienerFilterOptions(5, 1.0, 315.0);
                raster.Filter(bounds, motionOptions);

                int[] afterPixels = raster.GetDefaultArgb32Pixels(bounds);
                double afterBrightness = 0;
                foreach (int pixel in afterPixels)
                {
                    Color c = Color.FromArgb(pixel);
                    afterBrightness += (c.R + c.G + c.B) / 3.0;
                }
                afterBrightness /= afterPixels.Length;

                double tolerance = 0.5;
                if (Math.Abs(afterBrightness - beforeBrightness) > tolerance)
                {
                    Console.WriteLine("Warning: Brightness changed after applying motion blur.");
                }

                PngOptions saveOptions = new PngOptions
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
 * 1. When you need to add a realistic motion blur effect to a PNG template while confirming that the image’s overall brightness remains unchanged.
 * 2. When generating marketing assets that require a directional blur at a 315° angle without affecting exposure for consistent visual branding.
 * 3. When preprocessing PNG images for UI animations in a C# application and you must ensure the blur filter does not alter the perceived brightness.
 * 4. When writing automated image‑processing tests that compare pixel brightness before and after applying a motion‑blur filter in .NET.
 * 5. When integrating Aspose.Imaging filters into a reporting dashboard and you need to validate that the applied motion blur preserves the original brightness level.
 */
