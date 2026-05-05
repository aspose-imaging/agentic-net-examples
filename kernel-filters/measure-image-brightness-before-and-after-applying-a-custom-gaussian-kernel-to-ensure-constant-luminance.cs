using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

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

                if (!raster.IsCached)
                {
                    raster.CacheData();
                }

                int[] pixelsBefore = raster.LoadArgb32Pixels(raster.Bounds);
                double sumBefore = 0;
                foreach (int pixel in pixelsBefore)
                {
                    int r = (pixel >> 16) & 0xFF;
                    int g = (pixel >> 8) & 0xFF;
                    int b = pixel & 0xFF;
                    sumBefore += (r + g + b) / 3.0;
                }
                double brightnessBefore = sumBefore / pixelsBefore.Length;

                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                int[] pixelsAfter = raster.LoadArgb32Pixels(raster.Bounds);
                double sumAfter = 0;
                foreach (int pixel in pixelsAfter)
                {
                    int r = (pixel >> 16) & 0xFF;
                    int g = (pixel >> 8) & 0xFF;
                    int b = pixel & 0xFF;
                    sumAfter += (r + g + b) / 3.0;
                }
                double brightnessAfter = sumAfter / pixelsAfter.Length;

                raster.Save(outputPath, new PngOptions());

                Console.WriteLine($"Brightness before: {brightnessBefore:F2}");
                Console.WriteLine($"Brightness after: {brightnessAfter:F2}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}