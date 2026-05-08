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
                int[] originalPixels = raster.GetDefaultArgb32Pixels(raster.Bounds);
                double originalSum = 0;
                for (int i = 0; i < originalPixels.Length; i++)
                {
                    int pixel = originalPixels[i];
                    int r = (pixel >> 16) & 0xFF;
                    int g = (pixel >> 8) & 0xFF;
                    int b = pixel & 0xFF;
                    originalSum += (r + g + b) / 3.0;
                }
                double originalAvg = originalSum / originalPixels.Length;

                // Apply motion blur (size 10, smooth 1.0, angle 150)
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(10, 1.0, 150.0));

                // Compute new average brightness
                int[] newPixels = raster.GetDefaultArgb32Pixels(raster.Bounds);
                double newSum = 0;
                for (int i = 0; i < newPixels.Length; i++)
                {
                    int pixel = newPixels[i];
                    int r = (pixel >> 16) & 0xFF;
                    int g = (pixel >> 8) & 0xFF;
                    int b = pixel & 0xFF;
                    newSum += (r + g + b) / 3.0;
                }
                double newAvg = newSum / newPixels.Length;

                double brightnessShift = newAvg - originalAvg;
                Console.WriteLine($"Brightness shift: {brightnessShift}");

                // Save the processed image
                raster.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}