// HOW-TO: Create SVG From BMP And Set Stroke Width In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input BMP path
            string inputBmpPath = @"C:\Images\source.bmp";

            // Verify input file exists
            if (!File.Exists(inputBmpPath))
            {
                Console.Error.WriteLine($"File not found: {inputBmpPath}");
                return;
            }

            // Hardcoded output SVG path
            string outputSvgPath = @"C:\Images\result.svg";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputSvgPath));

            // Load the BMP image
            using (RasterImage bmpImage = (RasterImage)Image.Load(inputBmpPath))
            {
                // Create an SVG graphics canvas with the same dimensions as the BMP
                int width = bmpImage.Width;
                int height = bmpImage.Height;
                int dpi = 96; // standard screen DPI

                SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

                // Draw the raster BMP onto the SVG canvas
                graphics.DrawImage(bmpImage, new Point(0, 0), new Size(width, height));

                // Create a simple rectangular path to demonstrate stroke width customization
                Figure rectFigure = new Figure { IsClosed = true };
                GraphicsPath rectPath = new GraphicsPath();
                rectPath.AddFigure(rectFigure);
                rectFigure.AddShapes(new Shape[]
                {
                    new RectangleShape(new Rectangle(0, 0, width, height))
                });

                // Set stroke width (e.g., 5 pixels) using a Pen
                Pen strokePen = new Pen(Color.Black, 5);
                graphics.DrawPath(strokePen, rectPath);

                // Finalize SVG image
                using (SvgImage svgImage = graphics.EndRecording())
                {
                    // Save the customized SVG
                    svgImage.Save(outputSvgPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to convert a legacy BMP logo into a scalable SVG for responsive web design while preserving a custom border thickness.
 * 2. When generating vector graphics from raster screenshots to allow designers to edit outlines, such as adding a 5‑pixel stroke around the image.
 * 3. When automating batch processing of product images, converting each BMP to SVG and applying a uniform stroke for consistent branding.
 * 4. When creating printable SVG assets from bitmap assets and requiring precise control over the path stroke width for cut‑line accuracy.
 * 5. When integrating Aspose.Imaging in a C# application to embed raster images into SVG files and programmatically style the vector shapes.
 */
