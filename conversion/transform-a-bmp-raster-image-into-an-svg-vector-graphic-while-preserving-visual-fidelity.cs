using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class BmpToSvgConverter
{
    static void Main()
    {
        // Input BMP file path
        string inputBmpPath = @"C:\Temp\sample.bmp";
        // Output SVG file path
        string outputSvgPath = @"C:\Temp\sample_converted.svg";

        // Load the BMP image using Aspose.Imaging's generic loader
        using (Image bmpImage = Image.Load(inputBmpPath))
        {
            // Cast to RasterImage to access drawing capabilities
            RasterImage raster = (RasterImage)bmpImage;

            // Create an SVG graphics context with the same dimensions as the BMP
            // DPI is set to 96 (standard screen resolution)
            SvgGraphics2D svgGraphics = new SvgGraphics2D(raster.Width, raster.Height, 96);

            // Draw the raster BMP onto the SVG canvas.
            // The image is placed at (0,0) and scaled to its original size.
            svgGraphics.DrawImage(raster, new Point(0, 0), new Size(raster.Width, raster.Height));

            // Finalize recording and obtain the resulting SvgImage
            using (SvgImage svgImage = svgGraphics.EndRecording())
            {
                // Prepare SVG save options (default settings are sufficient)
                SvgOptions svgOptions = new SvgOptions();

                // Save the SVG vector graphic to the specified file
                svgImage.Save(outputSvgPath, svgOptions);
            }
        }
    }
}