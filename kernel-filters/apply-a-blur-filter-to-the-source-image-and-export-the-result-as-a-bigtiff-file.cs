using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for filtering
            RasterImage raster = (RasterImage)image;

            // Apply Gaussian blur (radius 5, sigma 4.0) to the entire image
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

            // Prepare BigTIFF options
            var options = new BigTiffOptions(TiffExpectedFormat.Default);

            // Save the processed image as BigTIFF
            raster.Save(outputPath, options);
        }
    }
}