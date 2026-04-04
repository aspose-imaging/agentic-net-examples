using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output BMP file path
        string outputPath = @"C:\temp\circle.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Image dimensions
        int width = 400;
        int height = 400;

        // Create BMP options with a bound file source
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create the image canvas
        using (Image image = Image.Create(bmpOptions, width, height))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // Pen for the Bezier curve
            Pen pen = new Pen(Color.Blue, 2);

            // Circle parameters
            float cx = 200f; // center X
            float cy = 200f; // center Y
            float r = 100f;  // radius
            float c = r * 0.5522847498f; // control point offset

            // Top segment
            graphics.DrawBezier(pen,
                new PointF(cx, cy - r),
                new PointF(cx + c, cy - r),
                new PointF(cx + r, cy - c),
                new PointF(cx + r, cy));

            // Right segment
            graphics.DrawBezier(pen,
                new PointF(cx + r, cy),
                new PointF(cx + r, cy + c),
                new PointF(cx + c, cy + r),
                new PointF(cx, cy + r));

            // Bottom segment
            graphics.DrawBezier(pen,
                new PointF(cx, cy + r),
                new PointF(cx - c, cy + r),
                new PointF(cx - r, cy + c),
                new PointF(cx - r, cy));

            // Left segment
            graphics.DrawBezier(pen,
                new PointF(cx - r, cy),
                new PointF(cx - r, cy - c),
                new PointF(cx - c, cy - r),
                new PointF(cx, cy - r));

            // Save the image (output path already bound)
            image.Save();
        }
    }
}