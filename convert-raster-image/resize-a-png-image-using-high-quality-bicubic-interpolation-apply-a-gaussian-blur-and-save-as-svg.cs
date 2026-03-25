using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.svg";

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
            // Cast to RasterImage for pixel operations
            RasterImage raster = (RasterImage)image;

            // Example resize dimensions (half the original size)
            int newWidth = raster.Width / 2;
            int newHeight = raster.Height / 2;

            // Resize using high‑quality bicubic interpolation (CubicConvolution)
            raster.Resize(newWidth, newHeight, ResizeType.CubicConvolution);

            // Apply Gaussian blur (radius 5, sigma 4.0)
            raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Prepare SVG save options
            SvgOptions svgOptions = new SvgOptions
            {
                // Optional: set vector rasterization options if needed
                VectorRasterizationOptions = new SvgRasterizationOptions()
            };

            // Save the processed image as SVG
            raster.Save(outputPath, svgOptions);
        }
    }
}