using System;
using System.IO;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output_motion_wiener.png";

        // Verify that the input file exists
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
            // Cast to RasterImage to access filtering capabilities
            RasterImage rasterImage = (RasterImage)image;

            // Create MotionWiener filter options:
            // size = 10 (kernel size), sigma = 1.0 (smoothing), angle = 0.0 (horizontal direction)
            var motionWienerOptions = new MotionWienerFilterOptions(10, 1.0, 0.0);

            // Apply the filter to the entire image bounds
            rasterImage.Filter(rasterImage.Bounds, motionWienerOptions);

            // Save the processed image as PNG
            rasterImage.Save(outputPath);
        }
    }
}