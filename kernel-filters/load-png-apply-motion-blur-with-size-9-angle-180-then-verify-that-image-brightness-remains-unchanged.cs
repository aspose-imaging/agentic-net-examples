// HOW-TO: Apply Motion Blur to PNG and Verify Brightness Remains Same in C# (Aspose.Imaging for .NET)
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

                // Compute original average brightness
                long sumR = 0, sumG = 0, sumB = 0;
                int width = raster.Width;
                int height = raster.Height;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int argb = raster.GetArgb32Pixel(x, y);
                        sumR += (argb >> 16) & 0xFF;
                        sumG += (argb >> 8) & 0xFF;
                        sumB += argb & 0xFF;
                    }
                }
                double pixelCount = width * height;
                double originalBrightness = (sumR + sumG + sumB) / (3.0 * pixelCount);

                // Apply motion blur (size 9, sigma 1.0, angle 180)
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(9, 1.0, 180.0));

                // Compute new average brightness
                sumR = sumG = sumB = 0;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int argb = raster.GetArgb32Pixel(x, y);
                        sumR += (argb >> 16) & 0xFF;
                        sumG += (argb >> 8) & 0xFF;
                        sumB += argb & 0xFF;
                    }
                }
                double newBrightness = (sumR + sumG + sumB) / (3.0 * pixelCount);

                if (Math.Abs(originalBrightness - newBrightness) < 0.01)
                    Console.WriteLine("Brightness unchanged.");
                else
                    Console.WriteLine("Brightness changed.");

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
 * 1. When you need to add a realistic motion‑blur effect to a PNG while ensuring the overall image brightness does not shift, this code shows how to apply the filter and compare average luminance.
 * 2. When building an automated photo‑enhancement pipeline that must keep exposure consistent after applying blur, you can use this example to compute and validate brightness before saving the result.
 * 3. When creating a game asset workflow that applies directional blur to sprites and must guarantee visual consistency across frames, the snippet demonstrates the required Aspose.Imaging calls.
 * 4. When developing a quality‑control tool that checks whether image‑processing operations like motion blur alter the perceived brightness of PNG files, this code provides the measurement technique.
 * 5. When integrating Aspose.Imaging into a C# application to process user‑uploaded PNGs with motion blur and need to log any unexpected brightness changes, the example illustrates the verification steps.
 */
