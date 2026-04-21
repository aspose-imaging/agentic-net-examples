using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\circle_bezier.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a BMP image with desired dimensions
        BmpOptions bmpOptions = new BmpOptions();
        using (Image image = Image.Create(bmpOptions, 400, 400))
        {
            // Initialize graphics object for drawing
            Graphics graphics = new Graphics(image);

            // Fill background with white color
            graphics.Clear(Color.White);

            // Parameters for circle approximation using 4 cubic Bezier curves
            float radius = 150f;               // Circle radius
            float cx = 200f;                   // Center X
            float cy = 200f;                   // Center Y
            float k = 0.552284749831f;         // Approximation constant (4/3 * tan(π/8))
            float ox = radius * k;             // Horizontal offset for control points
            float oy = radius * k;             // Vertical offset for control points

            // Top‑right quadrant
            graphics.DrawBezier(
                new Pen(Color.Blue, 2),
                new PointF(cx + radius, cy),
                new PointF(cx + radius, cy - oy),
                new PointF(cx + ox, cy - radius),
                new PointF(cx, cy - radius));

            // Bottom‑right quadrant
            graphics.DrawBezier(
                new Pen(Color.Blue, 2),
                new PointF(cx, cy - radius),
                new PointF(cx - ox, cy - radius),
                new PointF(cx - radius, cy - oy),
                new PointF(cx - radius, cy));

            // Bottom‑left quadrant
            graphics.DrawBezier(
                new Pen(Color.Blue, 2),
                new PointF(cx - radius, cy),
                new PointF(cx - radius, cy + oy),
                new PointF(cx - ox, cy + radius),
                new PointF(cx, cy + radius));

            // Top‑left quadrant
            graphics.DrawBezier(
                new Pen(Color.Blue, 2),
                new PointF(cx, cy + radius),
                new PointF(cx + ox, cy + radius),
                new PointF(cx + radius, cy + oy),
                new PointF(cx + radius, cy));

            // Save the image to the specified path
            image.Save(outputPath);
        }
    }
}