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
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage
                RasterImage rasterImage = (RasterImage)image;

                // Cache data for safe pixel access
                if (!rasterImage.IsCached)
                {
                    rasterImage.CacheData();
                }

                // Measure brightness before filtering
                int[] beforePixels = rasterImage.GetDefaultArgb32Pixels(rasterImage.Bounds);
                double sumBefore = 0;
                foreach (int argb in beforePixels)
                {
                    var color = Aspose.Imaging.Color.FromArgb(argb);
                    sumBefore += (color.R + color.G + color.B) / 3.0;
                }
                double beforeBrightness = sumBefore / beforePixels.Length;
                Console.WriteLine($"Average brightness before: {beforeBrightness:F2}");

                // Apply custom Gaussian blur (radius 5, sigma 4.0)
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Measure brightness after filtering
                int[] afterPixels = rasterImage.GetDefaultArgb32Pixels(rasterImage.Bounds);
                double sumAfter = 0;
                foreach (int argb in afterPixels)
                {
                    var color = Aspose.Imaging.Color.FromArgb(argb);
                    sumAfter += (color.R + color.G + color.B) / 3.0;
                }
                double afterBrightness = sumAfter / afterPixels.Length;
                Console.WriteLine($"Average brightness after: {afterBrightness:F2}");

                // Save the filtered image
                var pngOptions = new PngOptions();
                rasterImage.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}