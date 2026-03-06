using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Input raster image (PNG, JPEG, BMP, etc.)
        string inputPath = @"C:\Images\sample.png";
        // Desired SVG output file
        string outputPath = @"C:\Images\sample.svg";

        // Load the raster image using the unified Image.Load method
        using (Image rasterImage = Image.Load(inputPath))
        {
            // Prerequisite check: ensure the image was loaded and has valid dimensions
            if (rasterImage == null || rasterImage.Width == 0 || rasterImage.Height == 0)
                throw new InvalidOperationException("Failed to load a valid raster image.");

            // Create rasterization options for SVG conversion
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                // Match the SVG page size to the original raster dimensions
                PageSize = rasterImage.Size,
                // Optional: set a background color for the SVG canvas
                BackgroundColor = Color.White,
                // Optional: control text rendering and smoothing (not critical for pure raster)
                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                SmoothingMode = SmoothingMode.None
            };

            // Configure SVG save options and attach the rasterization settings
            SvgOptions svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterOptions,
                // Optional: enable compression to produce an SVGZ file
                Compress = false,
                // Optional: render text as shapes (irrelevant for raster images)
                TextAsShapes = false
            };

            // Save the raster image as an SVG file using the defined options
            rasterImage.Save(outputPath, svgOptions);
        }
    }
}