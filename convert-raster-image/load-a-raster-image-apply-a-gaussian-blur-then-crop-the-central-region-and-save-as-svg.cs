using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output.svg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access raster‑specific operations
                RasterImage raster = (RasterImage)image;

                // Apply Gaussian blur (radius = 5, sigma = 4.0)
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Calculate central crop rectangle (half the size of the original)
                int cropWidth = raster.Width / 2;
                int cropHeight = raster.Height / 2;
                int cropX = (raster.Width - cropWidth) / 2;
                int cropY = (raster.Height - cropHeight) / 2;
                var cropRect = new Rectangle(cropX, cropY, cropWidth, cropHeight);

                // Crop the image
                raster.Crop(cropRect);

                // Save the processed image as SVG
                var svgOptions = new SvgOptions(); // default options
                raster.Save(outputPath, svgOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}