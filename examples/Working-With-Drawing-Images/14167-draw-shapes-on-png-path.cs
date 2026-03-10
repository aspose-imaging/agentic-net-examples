using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Output PNG file path
        string outputPath = "output.png";

        // Create a file stream for the output image
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Configure PNG options and bind the stream as the source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            // Create a 500x500 PNG image
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.Wheat);

                // Create a graphics path and a figure
                Aspose.Imaging.GraphicsPath graphicspath = new Aspose.Imaging.GraphicsPath();
                Aspose.Imaging.Figure figure = new Aspose.Imaging.Figure();

                // Add shapes to the figure
                figure.AddShape(new RectangleShape(new Aspose.Imaging.RectangleF(10f, 10f, 300f, 300f)));
                figure.AddShape(new EllipseShape(new Aspose.Imaging.RectangleF(50f, 50f, 300f, 300f)));
                figure.AddShape(new PieShape(
                    new Aspose.Imaging.RectangleF(
                        new Aspose.Imaging.PointF(250f, 250f),
                        new Aspose.Imaging.SizeF(200f, 200f)),
                    0f, 45f));

                // Add the figure to the graphics path
                graphicspath.AddFigure(figure);

                // Draw the path onto the image
                graphics.DrawPath(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2), graphicspath);

                // Save changes (the image is already bound to the stream)
                image.Save();
            }
        }
    }
}