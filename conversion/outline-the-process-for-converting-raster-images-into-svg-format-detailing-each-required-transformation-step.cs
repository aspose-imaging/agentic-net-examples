using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input raster image path (e.g., PNG, JPG). Use first argument or default.
        string inputPath = args.Length > 0 ? args[0] : "input.png";
        // Output SVG file path. Use second argument or default.
        string outputPath = args.Length > 1 ? args[1] : "output.svg";

        // Load the raster image. Image.Load works for all supported raster formats.
        using (Image image = Image.Load(inputPath))
        {
            // If the loaded image is a raster type, cache its data for optimal processing.
            if (image is RasterImage raster && !raster.IsCached)
            {
                raster.CacheData();
            }

            // Create SVG save options.
            var svgOptions = new SvgOptions();

            // Configure vector rasterization options.
            // PageSize defines the dimensions of the resulting SVG canvas.
            var vectorOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };
            svgOptions.VectorRasterizationOptions = vectorOptions;

            // Optional: render text as shapes to preserve appearance.
            // svgOptions.TextAsShapes = true;

            // Save the raster image as an SVG file.
            image.Save(outputPath, svgOptions);
        }
    }
}