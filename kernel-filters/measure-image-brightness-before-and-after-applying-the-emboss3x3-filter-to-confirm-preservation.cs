using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output_emboss.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;

                // Measure brightness before filter
                int[] pixelsBefore = rasterImage.GetDefaultArgb32Pixels(rasterImage.Bounds);
                long sumBefore = 0;
                foreach (int pixel in pixelsBefore)
                {
                    int r = (pixel >> 16) & 0xFF;
                    int g = (pixel >> 8) & 0xFF;
                    int b = pixel & 0xFF;
                    sumBefore += r + g + b;
                }
                double brightnessBefore = sumBefore / (double)(pixelsBefore.Length * 3);
                Console.WriteLine($"Brightness before: {brightnessBefore:F2}");

                // Apply Emboss3x3 filter
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));

                // Measure brightness after filter
                int[] pixelsAfter = rasterImage.GetDefaultArgb32Pixels(rasterImage.Bounds);
                long sumAfter = 0;
                foreach (int pixel in pixelsAfter)
                {
                    int r = (pixel >> 16) & 0xFF;
                    int g = (pixel >> 8) & 0xFF;
                    int b = pixel & 0xFF;
                    sumAfter += r + g + b;
                }
                double brightnessAfter = sumAfter / (double)(pixelsAfter.Length * 3);
                Console.WriteLine($"Brightness after: {brightnessAfter:F2}");

                // Save the filtered image
                PngOptions options = new PngOptions();
                rasterImage.Save(outputPath, options);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}