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
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.png";
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
                // Cast to RasterImage for processing
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur (radius 5, sigma 4.0)
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Calculate central crop rectangle (half size)
                int cropWidth = rasterImage.Width / 2;
                int cropHeight = rasterImage.Height / 2;
                int cropX = (rasterImage.Width - cropWidth) / 2;
                int cropY = (rasterImage.Height - cropHeight) / 2;
                var cropRect = new Rectangle(cropX, cropY, cropWidth, cropHeight);

                // Crop the image
                rasterImage.Crop(cropRect);

                // Save the processed image as SVG
                var svgOptions = new SvgOptions();
                rasterImage.Save(outputPath, svgOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}