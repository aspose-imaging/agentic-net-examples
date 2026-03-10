using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.FileFormats.Svg.SvgImage;
using Aspose.Imaging.FileFormats.Svg.SvgImage;
using Aspose.Imaging.FileFormats.Svg.SvgImage;
using Aspose.Imaging.FileFormats.Svg.SvgImage;
using Aspose.Imaging.FileFormats.Svg.SvgImage;
using Aspose.Imaging.FileFormats.Svg.SvgImage;
using Aspose.Imaging.FileFormats.Svg.SvgImage;
using Aspose.Imaging.FileFormats.Svg.SvgImage;
using Aspose.Imaging.FileFormats.Svg.SvgImage;
using Aspose.Imaging.FileFormats.Svg.SvgImage;
using Aspose.Imaging.FileFormats.Svg.SvgImage;
using Aspose.Imaging.FileFormats.Svg.SvgImage;
using Aspose.Imaging.FileFormats.Svg.SvgImage;
using Aspose.Imaging.FileFormats.Svg.SvgImage;
using Aspose.Imaging.FileFormats.Svg.SvgImage;
using Aspose.Imaging.FileFormats.Svg.SvgImage;
using Aspose.Imaging.FileFormats.Svg.SvgImage;
using Aspose.Imaging.FileFormats.Svg.SvgImage;
using Aspose.Imaging.FileFormats.Svg.SvgImage;
using Aspose.Imaging.FileFormats.Svg.SvgImage;
using Aspose.Imaging.FileFormats.Svg.SvgImage;
using Aspose.Imaging.FileFormats.Svg.SvgImage;
using Aspose.Imaging.FileFormats.Svg.SvgImage;
using Aspose.Imaging.FileFormats.Svg.SvgImage;
using Aspose.Imaging.FileFormats.Svg.SvgImage;
using Aspize.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main()
    {
        // Directory containing the source raster image and where the output SVG will be saved
        string dir = @"C:\Temp\";

        // Define the size of the vector (SVG) canvas
        int vectorWidth = 800;
        int vectorHeight = 600;
        int dpi = 96;

        // Create an SVG graphics recorder
        SvgGraphics2D graphics = new SvgGraphics2D(vectorWidth, vectorHeight, dpi);

        // Load the raster image to be drawn
        using (RasterImage raster = (RasterImage)Image.Load(dir + "sample.jpg"))
        {
            // Source rectangle: portion of the raster image to copy (x, y, width, height)
            Rectangle srcRect = new Rectangle(50, 50, 200, 150);

            // Destination rectangle: where the portion will be placed on the SVG canvas
            Rectangle destRect = new Rectangle(100, 100, 300, 225);

            // Draw the specified portion of the raster image onto the SVG canvas
            graphics.DrawImage(srcRect, destRect, raster);
        }

        // Finalize the SVG recording and obtain the SVG image object
        using (SvgImage svgImage = graphics.EndRecording())
        {
            // Save the resulting SVG file
            svgImage.Save(dir + "output.svg");
        }
    }
}