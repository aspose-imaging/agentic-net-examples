using System;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;

class Program
{
    static void Main(string[] args)
    {
        // Output GIF file path
        string outputPath = "output.gif";

        // Create GIF options (default settings)
        GifOptions gifOptions = new GifOptions();

        // Create a GIF frame block of desired size
        using (GifFrameBlock frameBlock = new GifFrameBlock(500, 500))
        {
            // Initialize Graphics object for drawing on the frame block
            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(frameBlock);

            // Create a GraphicsPath to hold figures and shapes
            Aspose.Imaging.GraphicsPath graphicsPath = new Aspose.Imaging.GraphicsPath();

            // Create a Figure and add shapes to it
            Aspose.Imaging.Figure figure = new Aspose.Imaging.Figure();
            figure.AddShape(new Aspose.Imaging.Shapes.RectangleShape(new Aspose.Imaging.RectangleF(10f, 10f, 300f, 300f)));
            figure.AddShape(new Aspose.Imaging.Shapes.EllipseShape(new Aspose.Imaging.RectangleF(50f, 50f, 300f, 300f)));
            figure.AddShape(new Aspose.Imaging.Shapes.PieShape(
                new Aspose.Imaging.RectangleF(new Aspose.Imaging.PointF(250f, 250f), new Aspose.Imaging.SizeF(200f, 200f)),
                0f, 45f));

            // Add the figure to the graphics path
            graphicsPath.AddFigure(figure);

            // Draw the path onto the frame using a black pen
            graphics.DrawPath(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2), graphicsPath);

            // Create a GIF image from the frame block and save it
            using (GifImage gifImage = new GifImage(frameBlock))
            {
                gifImage.Save(outputPath, gifOptions);
            }
        }
    }
}