using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load image and process
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Cache data if not already cached
            if (!raster.IsCached)
                raster.CacheData();

            // Measure average brightness before filtering
            int[] beforePixels = raster.GetDefaultArgb32Pixels(raster.Bounds);
            double sumBefore = 0;
            foreach (int argb in beforePixels)
            {
                Color c = Color.FromArgb(argb);
                sumBefore += (c.R + c.G + c.B) / 3.0;
            }
            double avgBrightnessBefore = sumBefore / beforePixels.Length;
            Console.WriteLine($"Average brightness before: {avgBrightnessBefore:F2}");

            // Apply Gaussian blur with custom radius and sigma
            raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Measure average brightness after filtering
            int[] afterPixels = raster.GetDefaultArgb32Pixels(raster.Bounds);
            double sumAfter = 0;
            foreach (int argb in afterPixels)
            {
                Color c = Color.FromArgb(argb);
                sumAfter += (c.R + c.G + c.B) / 3.0;
            }
            double avgBrightnessAfter = sumAfter / afterPixels.Length;
            Console.WriteLine($"Average brightness after: {avgBrightnessAfter:F2}");

            // Save the processed image
            var pngOptions = new PngOptions();
            raster.Save(outputPath, pngOptions);
        }
    }
}