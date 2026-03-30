using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\Images\template.png";
        string outputPath = @"C:\Images\output.png";

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
            double beforeBrightness = beforePixels.Average(p =>
            {
                int r = (p >> 16) & 0xFF;
                int g = (p >> 8) & 0xFF;
                int b = p & 0xFF;
                return (r + g + b) / 3.0;
            });

            // Apply motion blur (size 5, angle 315)
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(5, 1.0, 315.0));

            // Compute average brightness after filtering
            int[] afterPixels = raster.LoadArgb32Pixels(raster.Bounds);
            double afterBrightness = afterPixels.Average(p =>
            {
                int r = (p >> 16) & 0xFF;
                int g = (p >> 8) & 0xFF;
                int b = p & 0xFF;
                return (r + g + b) / 3.0;
            });

            // Verify brightness unchanged (tolerance)
            double tolerance = 0.5; // acceptable difference
            if (Math.Abs(afterBrightness - beforeBrightness) <= tolerance)
            {
                Console.WriteLine("Brightness unchanged within tolerance.");
            }
            else
            {
                Console.WriteLine("Brightness changed.");
            }

            // Save the processed image
            raster.Save(outputPath);
        }
    }
}