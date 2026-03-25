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
        // Hard‑coded input and output paths
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
            RasterImage rasterImage = (RasterImage)image;

            // Apply Gaussian blur (radius = 5, sigma = 4.0) to the whole image
            rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Determine the central rectangle (half width and height, centered)
            int cropX = rasterImage.Width / 4;
            int cropY = rasterImage.Height / 4;
            int cropWidth = rasterImage.Width / 2;
            int cropHeight = rasterImage.Height / 2;
            var centralRect = new Rectangle(cropX, cropY, cropWidth, cropHeight);

            // Crop the image to the central region
            rasterImage.Crop(centralRect);

            // Save the processed image as SVG
            // SvgOptions are used to specify vector output format
            var svgOptions = new SvgOptions();
            image.Save(outputPath, svgOptions);
        }
    }
}