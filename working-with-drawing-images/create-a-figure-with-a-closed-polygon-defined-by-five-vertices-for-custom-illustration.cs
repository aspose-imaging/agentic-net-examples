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
        string outputPath = @"C:\temp\polygon.png";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Set up PNG options with a file source
            var pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image canvas (500x500)
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Create a graphics path and a figure
                GraphicsPath graphicPath = new GraphicsPath();
                Figure figure = new Figure();

                // Define five vertices for the closed polygon
                PointF[] points = new PointF[]
                {
                    new PointF(50f, 50f),
                    new PointF(200f, 30f),
                    new PointF(350f, 100f),
                    new PointF(300f, 250f),
                    new PointF(100f, 200f)
                };

                // Create the polygon shape (closed)
                PolygonShape polygon = new PolygonShape(points, true);

                // Add the polygon to the figure and the figure to the path
                figure.AddShape(polygon);
                graphicPath.AddFigure(figure);

                // Draw the path with a blue pen
                graphics.DrawPath(new Pen(Color.Blue, 2), graphicPath);

                // Save the image (file is already bound to the source)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}