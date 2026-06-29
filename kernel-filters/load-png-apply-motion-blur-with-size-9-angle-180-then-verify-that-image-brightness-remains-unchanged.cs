using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

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

                // Compute average brightness before filtering
                long totalBrightnessBefore = 0;
                int pixelCount = raster.Width * raster.Height;
                for (int y = 0; y < raster.Height; y++)
                {
                    for (int x = 0; x < raster.Width; x++)
                    {
                        int argb = raster.GetArgb32Pixel(x, y);
                        int r = (argb >> 16) & 0xFF;
                        int g = (argb >> 8) & 0xFF;
                        int b = argb & 0xFF;
                        int brightness = (r + g + b) / 3;
                        totalBrightnessBefore += brightness;
                    }
                }

                // Apply motion blur (size 9, smooth 1.0, angle 180)
                raster.Filter(raster.Bounds, new MotionWienerFilterOptions(9, 1.0, 180.0));

                // Compute average brightness after filtering
                long totalBrightnessAfter = 0;
                for (int y = 0; y < raster.Height; y++)
                {
                    for (int x = 0; x < raster.Width; x++)
                    {
                        int argb = raster.GetArgb32Pixel(x, y);
                        int r = (argb >> 16) & 0xFF;
                        int g = (argb >> 8) & 0xFF;
                        int b = argb & 0xFF;
                        int brightness = (r + g + b) / 3;
                        totalBrightnessAfter += brightness;
                    }
                }

                double avgBefore = (double)totalBrightnessBefore / pixelCount;
                double avgAfter = (double)totalBrightnessAfter / pixelCount;
                double diff = Math.Abs(avgBefore - avgAfter);

                if (diff > 0.5) // tolerance
                {
                    Console.WriteLine($"Warning: Brightness changed (Δ={diff:F2})");
                }
                else
                {
                    Console.WriteLine("Brightness unchanged after motion blur.");
                }

                // Save the processed image
                raster.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to add a realistic horizontal motion blur effect to a PNG thumbnail in a C# web application while ensuring the overall image brightness stays consistent for UI branding.
 * 2. When an image‑processing pipeline must simulate camera shake on PNG assets using Aspose.Imaging’s MotionWienerFilterOptions (size 9, angle 180) and then validate that the average luminance has not shifted before publishing.
 * 3. When a desktop utility written in C# has to batch‑process product photos, apply a 9‑pixel reverse‑direction blur, and confirm that the perceived brightness remains unchanged to meet quality‑control standards.
 * 4. When a game developer wants to pre‑render motion‑blurred PNG sprites with Aspose.Imaging, applying a 180‑degree blur and programmatically checking brightness to keep visual consistency across frames.
 * 5. When an automated testing suite for a graphics editor must verify that applying a motion blur filter to a PNG does not alter its average brightness, using raster pixel iteration in C# for regression testing.
 */