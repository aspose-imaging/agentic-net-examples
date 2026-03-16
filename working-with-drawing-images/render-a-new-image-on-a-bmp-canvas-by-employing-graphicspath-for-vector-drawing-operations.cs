using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Define image dimensions
        int width = 400;
        int height = 300;

        // Create a BMP image using the prescribed creation pattern
        using (FileStream stream = new FileStream("output.bmp", FileMode.Create))
        {
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new Aspose.Imaging.Sources.StreamSource(stream);

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics object for drawing
                Graphics graphics = new Graphics(image);

                // Clear background to white
                graphics.Clear(Color.White);

                // Build a GraphicsPath with a rectangle and an ellipse
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();

                // Add a rectangle shape
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));

                // Add an ellipse shape
                figure.AddShape(new EllipseShape(new RectangleF(120f, 80f, 150f, 100f)));

                // Attach the figure to the path
                path.AddFigure(figure);

                // Define a blue pen with 3‑pixel width
                Pen pen = new Pen(Color.Blue, 3);

                // Render the path onto the image
                graphics.DrawPath(pen, path);

                // Save the image using the prescribed save pattern
                image.Save();
            }
        }
    }
}