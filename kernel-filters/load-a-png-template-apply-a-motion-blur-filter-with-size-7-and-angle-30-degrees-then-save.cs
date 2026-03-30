using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\template.png";
        string outputPath = @"C:\Images\output_motion_blur.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering methods
            RasterImage raster = (RasterImage)image;

            // Apply a motion blur filter with size 7, smooth factor 1.0, and angle 30 degrees
            var motionOptions = new MotionWienerFilterOptions(7, 1.0, 30.0);
            raster.Filter(raster.Bounds, motionOptions);

            // Save the processed image
            raster.Save(outputPath);
        }
    }
}