using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.dib";
        string outputPath = @"C:\Images\output_motion_blur.dib";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DIB image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to enable filtering
            RasterImage rasterImage = (RasterImage)image;

            // Motion blur parameters: length (kernel size), smooth (smoothing factor), angle (degrees)
            int length = 10;
            double smooth = 1.0;
            double angle = 45.0;

            // Apply the motion blur filter to the entire image
            rasterImage.Filter(rasterImage.Bounds, new MotionWienerFilterOptions(length, smooth, angle));

            // Save the processed image
            rasterImage.Save(outputPath);
        }
    }
}