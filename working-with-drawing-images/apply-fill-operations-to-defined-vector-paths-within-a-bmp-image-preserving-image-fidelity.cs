using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Define output BMP file path and canvas size
        string outputPath = "filled_paths.bmp";
        int width = 500;
        int height = 500;

        // Configure BMP options (24 bits per pixel) and bind to the output file
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create the BMP image canvas
        using (Image image = Image.Create(bmpOptions, width, height))
        {
            // Initialize Graphics for drawing on the image
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // Create a GraphicsPath and a closed Figure to hold shapes
            GraphicsPath path = new GraphicsPath();
            Figure figure = new Figure();
            figure.IsClosed = true;

            // Add a rectangle shape
            figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));

            // Add an ellipse shape
            figure.AddShape(new EllipseShape(new RectangleF(300f, 100f, 150f, 150f)));

            // Add a polygon shape (triangle)
            figure.AddShape(new PolygonShape(
                new PointF[]
                {
                    new PointF(100f, 300f),
                    new PointF(150f, 350f),
                    new PointF(50f, 350f)
                },
                true));

            // Attach the figure to the path
            path.AddFigure(figure);

            // Fill the defined path with a solid brush
            using (Brush fillBrush = new SolidBrush(Color.LightBlue))
            {
                graphics.FillPath(fillBrush, path);
            }

            // Optionally draw the outline of the path
            Pen outlinePen = new Pen(Color.DarkBlue, 2);
            graphics.DrawPath(outlinePen, path);

            // Save the image (no need to specify path again because it's bound)
            image.Save();
        }
    }
}