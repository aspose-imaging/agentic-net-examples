using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging;

// Path to the source BMP file
string inputBmpPath = @"C:\Images\sample.bmp";
// Desired path for the resulting SVG file
string outputSvgPath = @"C:\Images\sample_converted.svg";

// Load the BMP image using the unified Image.Load method
using (RasterImage bmpImage = (RasterImage)Image.Load(inputBmpPath))
{
    // Retrieve dimensions of the BMP to create a matching SVG canvas
    int width = bmpImage.Width;
    int height = bmpImage.Height;
    int dpi = 96; // Standard screen DPI

    // Create an SVG graphics context with the same size as the BMP
    SvgGraphics2D svgGraphics = new SvgGraphics2D(width, height, dpi);

    // Draw the entire BMP onto the SVG canvas; this embeds the raster data as an <image> element
    svgGraphics.DrawImage(bmpImage, new Point(0, 0), new Size(width, height));

    // Finalize recording and obtain the SvgImage instance
    using (SvgImage svgImage = svgGraphics.EndRecording())
    {
        // Prepare SVG save options – keep full color fidelity and avoid compression
        SvgOptions saveOptions = new SvgOptions
        {
            Compress = false,          // No compression to preserve exact data
            TextAsShapes = false       // Text handling not needed for raster image
        };

        // Save the SVG file to the specified location
        svgImage.Save(outputSvgPath, saveOptions);
    }
}