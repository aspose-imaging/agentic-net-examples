using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input raster image path (PNG, JPEG, BMP, etc.)
        string inputPath = "input.png";
        // Desired SVG output path
        string outputPath = "output.svg";

        // Load the raster image
        using (Image image = Image.Load(inputPath))
        {
            // Ensure the image data is cached for processing
            if (image is RasterImage raster && !raster.IsCached)
            {
                raster.CacheData();
            }

            // Configure SVG rasterization options (page size, background, etc.)
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size,
                BackgroundColor = Color.White
            };

            // Set up SVG save options and assign the rasterization options
            SvgOptions svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the raster image as an SVG file
            image.Save(outputPath, svgOptions);
        }
    }
}