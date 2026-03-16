using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Output raster image path
        string outputPath = "output.png";

        // Create a file stream for the output image
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Set PNG options and bind the stream as the source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            // Create a raster canvas of 600x400 pixels
            using (Image image = Image.Create(pngOptions, 600, 400))
            {
                // Initialize graphics for drawing on the canvas
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.LightGray);

                // Create a GraphicsPath to hold figures
                GraphicsPath path = new GraphicsPath();

                // First figure with rectangle, ellipse and pie shapes
                Figure figure1 = new Figure();
                figure1.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));
                figure1.AddShape(new EllipseShape(new RectangleF(300f, 50f, 150f, 150f)));
                figure1.AddShape(new PieShape(new RectangleF(200f, 250f, 200f, 200f), 0f, 120f));
                path.AddFigure(figure1);

                // Second figure with a closed polygon
                Figure figure2 = new Figure();
                figure2.AddShape(new PolygonShape(new PointF[]
                {
                    new PointF(100f, 300f),
                    new PointF(150f, 350f),
                    new PointF(200f, 300f),
                    new PointF(150f, 250f)
                }, true));
                path.AddFigure(figure2);

                // Draw the constructed path with a blue pen
                graphics.DrawPath(new Pen(Color.Blue, 3), path);

                // Fill the same path with a semi‑transparent yellow brush
                using (SolidBrush brush = new SolidBrush())
                {
                    brush.Color = Color.Yellow;
                    brush.Opacity = 128; // 0‑255 range
                    graphics.FillPath(brush, path);
                }

                // Persist the image to the bound stream
                image.Save();
            }
        }
    }
}