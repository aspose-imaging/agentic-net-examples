using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Jpeg;

class DrawJpegOnVector
{
    static void Main()
    {
        // Define folder where input JPEG and output SVG will be stored
        string dir = @"c:\temp\";

        // Load the JPEG image as a raster image
        using (RasterImage jpegImage = (RasterImage)Image.Load(dir + "sample.jpg"))
        {
            // Create an SVG graphics surface (vector image) with desired size and DPI
            int vectorWidth = 800;
            int vectorHeight = 600;
            int dpi = 96;
            SvgGraphics2D svgGraphics = new SvgGraphics2D(vectorWidth, vectorHeight, dpi);

            // Draw the JPEG onto the SVG canvas at position (50,50) with size 300x200
            svgGraphics.DrawImage(jpegImage, new Aspose.Imaging.Point(50, 50), new Aspose.Imaging.Size(300, 200));

            // Finalize the recording and obtain the SVG image object
            using (SvgImage svgImage = svgGraphics.EndRecording())
            {
                // Save the resulting SVG file
                svgImage.Save(dir + "output.svg");
            }
        }
    }
}