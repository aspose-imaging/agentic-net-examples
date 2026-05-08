using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "template.png";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Calculate original average brightness
                int[] originalPixels = raster.GetDefaultArgb32Pixels(raster.Bounds);
                double originalBrightness = originalPixels.Average(p =>
                {
                    int r = (p >> 16) & 0xFF;
                    int g = (p >> 8) & 0xFF;
                    int b = p & 0xFF;
                    return (r + g + b) / 3.0;
                });

                // Apply motion blur (motion wiener filter) with size 5 and angle 315
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(5, 1.0, 315.0));

                // Calculate new average brightness
                int[] newPixels = raster.GetDefaultArgb32Pixels(raster.Bounds);
                double newBrightness = newPixels.Average(p =>
                {
                    int r = (p >> 16) & 0xFF;
                    int g = (p >> 8) & 0xFF;
                    int b = p & 0xFF;
                    return (r + g + b) / 3.0;
                });

                double diff = Math.Abs(originalBrightness - newBrightness);
                if (diff > 0.001)
                {
                    Console.WriteLine($"Brightness changed by {diff:F4}");
                }
                else
                {
                    Console.WriteLine("Brightness unchanged.");
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