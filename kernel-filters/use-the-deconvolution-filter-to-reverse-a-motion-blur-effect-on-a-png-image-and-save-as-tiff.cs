using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.tif";

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
            // Cast to RasterImage to apply filters
            RasterImage rasterImage = (RasterImage)image;

            // Apply a motion deconvolution filter (MotionWienerFilterOptions)
            // Parameters: length = 10, smooth = 1.0, angle = 90.0 degrees
            var motionOptions = new MotionWienerFilterOptions(10, 1.0, 90.0);
            rasterImage.Filter(rasterImage.Bounds, motionOptions);

            // Save the result as a TIFF file
            var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            rasterImage.Save(outputPath, tiffOptions);
        }
    }
}