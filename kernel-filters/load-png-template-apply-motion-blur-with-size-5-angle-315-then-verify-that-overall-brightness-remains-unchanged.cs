using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "template.png";
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
                int[] originalPixels = raster.LoadArgb32Pixels(raster.Bounds);
                double originalBrightness = 0;
                foreach (int argb in originalPixels)
                {
                    int r = (argb >> 16) & 0xFF;
                    int g = (argb >> 8) & 0xFF;
                    int b = argb & 0xFF;
                    originalBrightness += (r + g + b) / 3.0;
                }
                originalBrightness /= originalPixels.Length;

                // Apply motion blur filter (size 5, angle 315)
                raster.Filter(raster.Bounds, new MotionWienerFilterOptions(5, 1.0, 315.0));

                // Compute new average brightness
                int[] newPixels = raster.LoadArgb32Pixels(raster.Bounds);
                double newBrightness = 0;
                foreach (int argb in newPixels)
                {
                    int r = (argb >> 16) & 0xFF;
                    int g = (argb >> 8) & 0xFF;
                    int b = argb & 0xFF;
                    newBrightness += (r + g + b) / 3.0;
                }
                newBrightness /= newPixels.Length;

                // Verify brightness unchanged
                double diff = Math.Abs(newBrightness - originalBrightness);
                Console.WriteLine($"Original brightness: {originalBrightness:F2}");
                Console.WriteLine($"New brightness: {newBrightness:F2}");
                Console.WriteLine($"Difference: {diff:F2}");

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
 * 1. When a developer needs to add a subtle directional motion blur (size 5, angle 315) to a PNG UI template while confirming that the overall brightness stays unchanged for consistent visual branding.
 * 2. When an e‑commerce site generates stylized product thumbnails by applying a motion‑blur filter to a PNG placeholder and must verify that brightness does not shift, preserving the site’s color palette.
 * 3. When a game developer creates a motion‑blurred splash screen from a PNG asset in C# and uses Aspose.Imaging to ensure the blur does not unintentionally darken or brighten the background, keeping overlaid text readable.
 * 4. When a medical imaging tool overlays a PNG diagram on a scan, applies a motion‑blur effect to simulate movement, and checks brightness consistency to avoid misinterpretation of intensity values.
 * 5. When an automated report generator processes PNG charts, adds a 315‑degree motion blur for visual effect, and programmatically validates that the average pixel brightness remains unchanged to maintain chart legibility.
 */