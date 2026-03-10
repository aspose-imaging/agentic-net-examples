using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Folder where input and output files are located
        string dir = @"C:\temp\";

        // Dimensions of the SVG canvas
        int canvasWidth = 600;
        int canvasHeight = 400;
        int dpi = 96;

        // Load the raster image (PNG, JPEG, BMP, etc.) that will be drawn onto the SVG canvas
        using (RasterImage raster = (RasterImage)Image.Load(dir + "sample.png"))
        {
            // Create an SVG graphics object that records drawing commands
            SvgGraphics2D graphics = new SvgGraphics2D(canvasWidth, canvasHeight, dpi);

            // Draw the raster image at position (50,50) with a size of 200x150 pixels
            graphics.DrawImage(raster, new Point(50, 50), new Size(200, 150));

            // Finish recording and obtain the resulting SvgImage
            using (SvgImage svgImage = graphics.EndRecording())
            {
                // Configure rasterization options for converting SVG to PNG
                SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
                {
                    // Use the SVG image size as the page size for rasterization
                    PageSize = svgImage.Size,
                    // Optional: set background color, smoothing, etc.
                    BackgroundColor = Color.White,
                    SmoothingMode = SmoothingMode.AntiAlias,
                    TextRenderingHint = TextRenderingHint.AntiAlias
                };

                // Create PNG save options and attach the rasterization settings
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save the SVG content rasterized as a PNG file
                svgImage.Save(dir + "output.png", pngOptions);
            }
        }
    }
}