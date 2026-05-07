using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path
            string outputPath = "output.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up PNG options with a file create source
            var pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, 600, 400))
            {
                // Initialize graphics for drawing
                var graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                // Create a graphics path and a figure
                var path = new Aspose.Imaging.GraphicsPath();
                var figure = new Aspose.Imaging.Figure();

                // (Optional) Add a rectangle shape to the figure
                figure.AddShape(new Aspose.Imaging.Shapes.RectangleShape(
                    new Aspose.Imaging.RectangleF(50f, 50f, 200f, 200f)));

                // Add a cubic Bezier curve to the same figure using specified control points
                figure.AddShape(new Aspose.Imaging.Shapes.BezierShape(
                    new Aspose.Imaging.PointF[]
                    {
                        new Aspose.Imaging.PointF(0f, 0f),          // Start point
                        new Aspose.Imaging.PointF(200f, 133f),    // First control point
                        new Aspose.Imaging.PointF(400f, 166f),    // Second control point
                        new Aspose.Imaging.PointF(600f, 400f)     // End point
                    }));

                // Add the figure to the graphics path
                path.AddFigure(figure);

                // Draw the path with a red pen
                graphics.DrawPath(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 2), path);

                // Save the image
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}