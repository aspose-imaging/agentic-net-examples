using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Canvas dimensions and DPI
        int width = 600;
        int height = 400;
        int dpi = 96;

        // Create an SVG graphics context
        SvgGraphics2D svgGraphics = new SvgGraphics2D(width, height, dpi);

        // Draw vector elements
        svgGraphics.DrawRectangle(new Pen(Color.Black, 1), 0, 0, width, height);
        svgGraphics.FillRectangle(new Pen(Color.LightGray, 1), new SolidBrush(Color.LightGray), 0, 0, width, height);
        svgGraphics.DrawLine(new Pen(Color.DarkGreen, 1), 0, 0, width, height);
        svgGraphics.DrawLine(new Pen(Color.DarkGreen, 1), 0, height, width, 0);
        svgGraphics.DrawArc(new Pen(Color.Blue, 2), new Rectangle(0, 0, 200, 200), 90, 270);
        svgGraphics.FillArc(new Pen(Color.LightCoral, 10), new SolidBrush(Color.LightSkyBlue), new Rectangle(0, 0, 150, 150), 90, 270);
        svgGraphics.DrawCubicBezier(new Pen(Color.Red, 2),
            new PointF(0, 0),
            new PointF(200, 133),
            new PointF(400, 166),
            new PointF(600, 400));
        svgGraphics.DrawString(new Font("Arial", 48, FontStyle.Regular), "Hello World!", new Point(200, 300), Color.DarkRed);

        // Finalize SVG image
        using (SvgImage svgImage = svgGraphics.EndRecording())
        {
            // Save SVG file (optional)
            string svgPath = Path.Combine(Environment.CurrentDirectory, "vector_output.svg");
            svgImage.Save(svgPath);

            // Rasterize SVG to BMP
            string bmpPath = Path.Combine(Environment.CurrentDirectory, "raster_output.bmp");
            Source bmpSource = new FileCreateSource(bmpPath, false);
            BmpOptions bmpOptions = new BmpOptions() { Source = bmpSource };
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();
            rasterOptions.PageSize = svgImage.Size;
            bmpOptions.VectorRasterizationOptions = rasterOptions;

            // Save rasterized BMP
            svgImage.Save(bmpPath, bmpOptions);
        }
    }
}