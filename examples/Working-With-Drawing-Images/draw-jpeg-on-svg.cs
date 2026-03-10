using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Folder where the source JPEG and the resulting SVG will be stored
        string dir = @"c:\temp\";

        // Desired size of the output SVG image
        int svgWidth = 800;
        int svgHeight = 600;
        int dpi = 96;

        // Load the JPEG image as a RasterImage
        using (RasterImage jpeg = (RasterImage)Image.Load(dir + "sample.jpg"))
        {
            // Create an SVG graphics context
            SvgGraphics2D graphics = new SvgGraphics2D(svgWidth, svgHeight, dpi);

            // Draw the JPEG onto the SVG at position (100,100) with original size
            graphics.DrawImage(jpeg, new Aspose.Imaging.Point(100, 100));

            // Alternatively, draw the JPEG scaled to a specific rectangle
            // graphics.DrawImage(jpeg, new Aspose.Imaging.Point(100, 100), new Aspose.Imaging.Size(300, 200));

            // Finish recording and obtain the SVG image object
            using (SvgImage svgImage = graphics.EndRecording())
            {
                // Save the SVG to disk
                svgImage.Save(dir + "output.svg");
            }
        }
    }
}