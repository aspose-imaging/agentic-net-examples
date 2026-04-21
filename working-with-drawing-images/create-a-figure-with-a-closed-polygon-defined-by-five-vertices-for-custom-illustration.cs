using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Output file path (hard‑coded)
        string outputPath = @"C:\temp\polygon.png";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a file stream for the output image
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Set PNG options and bind the stream as the source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            // Create a 500x500 image
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                // Create a graphics path and a figure
                Aspose.Imaging.GraphicsPath graphicspath = new Aspose.Imaging.GraphicsPath();
                Aspose.Imaging.Figure figure = new Aspose.Imaging.Figure();

                // Define five vertices for the closed polygon
                Aspose.Imaging.PointF[] points = new Aspose.Imaging.PointF[]
                {
                    new Aspose.Imaging.PointF(100f, 50f),
                    new Aspose.Imaging.PointF(200f, 80f),
                    new Aspose.Imaging.PointF(250f, 200f),
                    new Aspose.Imaging.PointF(150f, 250f),
                    new Aspose.Imaging.PointF(80f, 150f)
                };

                // Create a closed PolygonShape and add it to the figure
                Aspose.Imaging.Shapes.PolygonShape polygon = new Aspose.Imaging.Shapes.PolygonShape(points, true);
                figure.AddShape(polygon);

                // Add the figure to the graphics path
                graphicspath.AddFigure(figure);

                // Draw the path with a black pen
                graphics.DrawPath(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2), graphicspath);

                // Save the image (stream is already bound)
                image.Save();
            }
        }
    }
}