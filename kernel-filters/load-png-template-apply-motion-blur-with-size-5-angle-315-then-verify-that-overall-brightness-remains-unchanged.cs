using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "template.png";
            string outputPath = "blurred.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Compute average brightness before filtering
                int[] beforePixels = raster.LoadArgb32Pixels(raster.Bounds);
                double beforeSum = 0;
                foreach (int pixel in beforePixels)
                {
                    int r = (pixel >> 16) & 0xFF;
                    int g = (pixel >> 8) & 0xFF;
                    int b = pixel & 0xFF;
                    beforeSum += (r + g + b) / 3.0;
                }
                double beforeBrightness = beforeSum / beforePixels.Length;

                // Apply motion blur (size 5, angle 315)
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(5, 1.0, 315.0));

                // Compute average brightness after filtering
                int[] afterPixels = raster.LoadArgb32Pixels(raster.Bounds);
                double afterSum = 0;
                foreach (int pixel in afterPixels)
                {
                    int r = (pixel >> 16) & 0xFF;
                    int g = (pixel >> 8) & 0xFF;
                    int b = pixel & 0xFF;
                    afterSum += (r + g + b) / 3.0;
                }
                double afterBrightness = afterSum / afterPixels.Length;

                // Verify brightness unchanged (tolerance 0.5%)
                double diff = Math.Abs(beforeBrightness - afterBrightness);
                double tolerance = beforeBrightness * 0.005;
                if (diff <= tolerance)
                {
                    Console.WriteLine("Brightness unchanged after motion blur.");
                }
                else
                {
                    Console.WriteLine("Brightness changed after motion blur.");
                }

                raster.Save(outputPath);
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
 * 1. When generating dynamic marketing banners that require a subtle motion‑blur effect (size 5, angle 315°) on a PNG template while keeping the overall brightness unchanged for consistent brand colors.
 * 2. When creating animated UI overlays in a C# application and need to apply a directional motion blur to a PNG asset without altering its perceived luminance, ensuring visual balance across the interface.
 * 3. When preprocessing PNG sprites for a 2D game engine, adding a motion‑blur filter to simulate speed and verifying that the average brightness stays within a 0.5 % tolerance so the game’s lighting remains uniform.
 * 4. When automating the production of printable PDFs from PNG templates, applying a motion blur to mimic camera shake and confirming brightness unchanged to avoid unexpected exposure shifts in the final print.
 * 5. When building an image‑processing pipeline that adds a 315° motion blur to user‑uploaded PNG logos for artistic effect, and the code checks that overall brightness is unchanged to maintain logo visibility across different backgrounds.
 */