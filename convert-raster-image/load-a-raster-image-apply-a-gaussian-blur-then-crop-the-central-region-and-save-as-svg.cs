using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the raster image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access raster-specific methods
            RasterImage raster = (RasterImage)image;

            // Apply Gaussian blur with radius 5 and sigma 4.0 to the whole image
            raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Define central crop rectangle (half width and height, centered)
            int cropX = raster.Width / 4;
            int cropY = raster.Height / 4;
            int cropWidth = raster.Width / 2;
            int cropHeight = raster.Height / 2;
            var cropRect = new Rectangle(cropX, cropY, cropWidth, cropHeight);

            // Crop the image
            raster.Crop(cropRect);

            // Save the processed image as SVG
            raster.Save(outputPath, new SvgOptions());
        }
    }
}