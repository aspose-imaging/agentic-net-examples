using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "template.png";
        string outputPath = "blurred.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Compute average brightness before filtering
            int[] beforePixels = raster.GetDefaultArgb32Pixels(raster.Bounds);
            long beforeSum = 0;
            foreach (int argb in beforePixels)
            {
                int r = (argb >> 16) & 0xFF;
                int g = (argb >> 8) & 0xFF;
                int b = argb & 0xFF;
                beforeSum += (r + g + b) / 3;
            }
            double beforeBrightness = (double)beforeSum / beforePixels.Length;

            // Apply motion blur (size 10, angle 150)
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(10, 1.0, 150.0));

            // Compute average brightness after filtering
            int[] afterPixels = raster.GetDefaultArgb32Pixels(raster.Bounds);
            long afterSum = 0;
            foreach (int argb in afterPixels)
            {
                int r = (argb >> 16) & 0xFF;
                int g = (argb >> 8) & 0xFF;
                int b = argb & 0xFF;
                afterSum += (r + g + b) / 3;
            }
            double afterBrightness = (double)afterSum / afterPixels.Length;

            // Output the brightness shift
            double shift = afterBrightness - beforeBrightness;
            Console.WriteLine($"Brightness shift: {shift}");

            // Save the processed image as PNG
            raster.Save(outputPath, new PngOptions());
        }
    }
}