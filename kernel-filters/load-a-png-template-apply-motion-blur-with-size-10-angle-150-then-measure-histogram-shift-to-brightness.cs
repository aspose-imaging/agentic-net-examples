using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\template.png";
            string outputPath = "Output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                int[] pixelsBefore = raster.GetDefaultArgb32Pixels(raster.Bounds);
                double sumBefore = 0;
                foreach (int argb in pixelsBefore)
                {
                    int r = (argb >> 16) & 0xFF;
                    int g = (argb >> 8) & 0xFF;
                    int b = argb & 0xFF;
                    double lum = 0.299 * r + 0.587 * g + 0.114 * b;
                    sumBefore += lum;
                }
                double avgBefore = sumBefore / pixelsBefore.Length;

                raster.Filter(raster.Bounds, new MotionWienerFilterOptions(10, 1.0, 150.0));

                int[] pixelsAfter = raster.GetDefaultArgb32Pixels(raster.Bounds);
                double sumAfter = 0;
                foreach (int argb in pixelsAfter)
                {
                    int r = (argb >> 16) & 0xFF;
                    int g = (argb >> 8) & 0xFF;
                    int b = argb & 0xFF;
                    double lum = 0.299 * r + 0.587 * g + 0.114 * b;
                    sumAfter += lum;
                }
                double avgAfter = sumAfter / pixelsAfter.Length;

                double brightnessShift = avgAfter - avgBefore;
                Console.WriteLine($"Brightness shift: {brightnessShift}");

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