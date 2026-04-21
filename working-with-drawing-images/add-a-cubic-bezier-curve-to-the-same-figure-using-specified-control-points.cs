using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded output path
        string outputPath = "output\\output.png";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up PNG options with a file create source bound to the output path
        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        // Create a new image with the specified dimensions
        using (Image image = Image.Create(pngOptions, 600, 400))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);

            // Clear the canvas with white background
            graphics.Clear(Color.White);

            // Create a graphics path and a figure
            GraphicsPath path = new GraphicsPath();
            Figure figure = new Figure();

            // Add a cubic Bezier curve to the figure using the specified control points
            figure.AddShape(new BezierShape(new PointF[]
            {
                new PointF(0, 0),          // Start point
                new PointF(200, 133),      // First control point
                new PointF(400, 166),      // Second control point
                new PointF(600, 400)       // End point
            }));

            // Add the figure to the path
            path.AddFigure(figure);

            // Draw the path with a red pen of width 2
            graphics.DrawPath(new Pen(Color.Red, 2), path);
        }

        // Save the image (the output path is already bound via FileCreateSource)
        // Image.Save() was called implicitly by disposing the image in the using block
    }
}