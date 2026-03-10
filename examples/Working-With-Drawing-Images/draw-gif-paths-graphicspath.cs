using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Input and output GIF file paths
        string inputPath = "input.gif";
        string outputPath = "output.gif";

        // Load the GIF image
        using (GifImage gif = (GifImage)Image.Load(inputPath))
        {
            // Ensure the GIF has at least one frame
            if (gif.PageCount == 0)
            {
                Console.WriteLine("The GIF contains no frames.");
                return;
            }

            // Set the active frame to the first frame
            gif.ActiveFrame = (GifFrameBlock)gif.Pages[0];

            // Create a Graphics object for drawing on the active frame
            Graphics graphics = new Graphics(gif.ActiveFrame);

            // Build a GraphicsPath with a rectangle, ellipse, and pie shape
            GraphicsPath path = new GraphicsPath();
            Figure figure = new Figure();

            // Rectangle shape
            figure.AddShape(new RectangleShape(new RectangleF(10f, 10f, 200f, 200f)));
            // Ellipse shape
            figure.AddShape(new EllipseShape(new RectangleF(50f, 50f, 200f, 200f)));
            // Pie shape
            figure.AddShape(new PieShape(
                new RectangleF(new PointF(100f, 100f), new SizeF(150f, 150f)),
                0f,
                120f));

            // Add the figure to the path
            path.AddFigure(figure);

            // Draw the path onto the GIF frame using a blue pen
            graphics.DrawPath(new Pen(Color.Blue, 3), path);

            // Save the modified GIF with default options
            GifOptions options = new GifOptions();
            gif.Save(outputPath, options);
        }
    }
}