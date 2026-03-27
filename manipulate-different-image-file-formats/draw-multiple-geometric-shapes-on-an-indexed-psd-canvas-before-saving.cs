using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        // Hardcoded output path for the PSD file
        string outputPath = @"C:\temp\output.psd";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create PSD options with a file create source
        var psdOptions = new PsdOptions
        {
            Source = new FileCreateSource(outputPath, false)
        };

        // Create a new PSD image with indexed color (8 bits per pixel)
        using (Image image = Image.Create(psdOptions, 800, 600))
        {
            // Initialize graphics for drawing
            var graphics = new Graphics(image);

            // Clear the canvas with a light gray background
            graphics.Clear(Color.LightGray);

            // Create a graphics path to hold multiple figures
            var graphicsPath = new GraphicsPath();

            // First figure: rectangle and ellipse
            var figure1 = new Figure();
            figure1.AddShape(new RectangleShape(new RectangleF(100f, 100f, 300f, 200f)));
            figure1.AddShape(new EllipseShape(new RectangleF(150f, 150f, 200f, 150f)));

            // Second figure: polygon (triangle) and a closed polyline
            var figure2 = new Figure();
            figure2.AddShape(new PolygonShape(new[]
            {
                new PointF(500f, 100f),
                new PointF(650f, 250f),
                new PointF(500f, 400f)
            }, true));

            // Add the figures to the path
            graphicsPath.AddFigures(new[] { figure1, figure2 });

            // Draw the combined path with a black pen
            graphics.DrawPath(new Pen(Color.Black, 3), graphicsPath);

            // Optionally fill one of the shapes (the rectangle) with a semi‑transparent brush
            var fillBrush = new SolidBrush(Color.FromArgb(128, Color.CornflowerBlue));
            graphics.FillRectangle(fillBrush, new Rectangle(100, 100, 300, 200));

            // Save the PSD image
            image.Save();
        }
    }
}