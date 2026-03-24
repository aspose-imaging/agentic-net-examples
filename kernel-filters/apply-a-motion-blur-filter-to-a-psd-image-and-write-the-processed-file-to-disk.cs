using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.psd";
        string outputPath = @"C:\Images\output_motion_blur.psd";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PSD image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering capabilities
            RasterImage rasterImage = (RasterImage)image;

            // Apply a motion wiener filter (used here as a motion blur effect) to the whole image
            // Parameters: length, smooth value, angle (degrees)
            var motionFilter = new MotionWienerFilterOptions(10, 1.0, 90.0);
            rasterImage.Filter(rasterImage.Bounds, motionFilter);

            // Save the processed image back to PSD format with default options
            rasterImage.Save(outputPath, new PsdOptions());
        }
    }
}