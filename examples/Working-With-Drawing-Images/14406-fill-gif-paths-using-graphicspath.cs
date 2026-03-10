using System;
using Aspose.Imaging;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.FileFormats.Gif; // For GIF specific types if needed

class FillGraphicsPathOnGif
{
    static void Main()
    {
        // Load an existing GIF image (lifecycle: load)
        using (Image image = Image.Load("input.gif"))
        {
            // Initialize Graphics object for the image
            Graphics graphics = new Graphics(image);

            // Create a new GraphicsPath
            GraphicsPath path = new GraphicsPath();

            // Create a closed figure to hold shapes
            Figure figure = new Figure { IsClosed = true };

            // Add a rectangle shape to the figure (you can add other shapes as needed)
            figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 200f)));

            // Add the figure to the path
            path.AddFigure(figure);

            // Fill the interior of the path with a solid red brush (feature: FillPath)
            graphics.FillPath(new SolidBrush(Color.Red), path);

            // Save the modified image (lifecycle: save)
            image.Save("output.gif");
        }
    }
}