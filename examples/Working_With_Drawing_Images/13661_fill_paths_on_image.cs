using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Output file path
        string outputPath = "output.png";

        // Create a file stream for the output image
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Set up PNG options with the stream as source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            // Create a 500x500 PNG image
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.LightGray);

                // Create a graphics path and a figure
                Aspose.Imaging.GraphicsPath path = new Aspose.Imaging.GraphicsPath();
                Aspose.Imaging.Figure figure = new Aspose.Imaging.Figure();

                // Add shapes to the figure
                figure.AddShape(new RectangleShape(new Aspose.Imaging.RectangleF(50f, 50f, 200f, 150f)));
                figure.AddShape(new EllipseShape(new Aspose.Imaging.RectangleF(100f, 200f, 150f, 100f)));
                figure.AddShape(new PieShape(
                    new Aspose.Imaging.RectangleF(
                        new Aspose.Imaging.PointF(200f, 100f),
                        new Aspose.Imaging.SizeF(150f, 150f)),
                    0f, 120f));

                // Add the figure to the path
                path.AddFigure(figure);

                // Create a solid brush for filling
                using (SolidBrush brush = new SolidBrush())
                {
                    brush.Color = Aspose.Imaging.Color.Yellow;
                    brush.Opacity = 100;

                    // Fill the path with the brush
                    graphics.FillPath(brush, path);
                }

                // Save the image (stream is already bound)
                image.Save();
            }
        }
    }
}