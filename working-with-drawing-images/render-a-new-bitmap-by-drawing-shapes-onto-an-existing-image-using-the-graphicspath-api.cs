using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        // Load an existing image from disk
        using (Image image = Image.Load("input.jpg"))
        {
            // Create a Graphics object for drawing on the loaded image
            Graphics graphics = new Graphics(image);

            // Clear the surface (optional, comment out if you want to keep original background)
            // graphics.Clear(Aspose.Imaging.Color.White);

            // Create a new GraphicsPath instance
            GraphicsPath graphicsPath = new GraphicsPath();

            // Create a Figure to hold multiple shapes
            Figure figure = new Figure();

            // Add a rectangle shape to the figure
            figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));

            // Add an ellipse shape to the figure
            figure.AddShape(new EllipseShape(new RectangleF(300f, 80f, 180f, 120f)));

            // Add a pie shape to the figure
            figure.AddShape(new PieShape(new RectangleF(150f, 250f, 200f, 200f), 0f, 120f));

            // Add the figure to the graphics path
            graphicsPath.AddFigure(figure);

            // Draw the path onto the image using a black pen of width 3
            graphics.DrawPath(new Pen(Aspose.Imaging.Color.Black, 3), graphicsPath);

            // Save the modified image to a new file
            image.Save("output.jpg");
        }
    }
}