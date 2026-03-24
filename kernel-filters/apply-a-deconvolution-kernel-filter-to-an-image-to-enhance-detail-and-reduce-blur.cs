using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output_MotionWiener.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering
            RasterImage rasterImage = (RasterImage)image;

            // Create a motion Wiener deconvolution filter
            // Parameters: length (kernel size), sigma (smoothing), angle (degrees)
            var deconvOptions = new MotionWienerFilterOptions(10, 1.0, 90.0);

            // Apply the filter to the whole image
            rasterImage.Filter(rasterImage.Bounds, deconvOptions);

            // Save the processed image
            rasterImage.Save(outputPath);
        }
    }
}