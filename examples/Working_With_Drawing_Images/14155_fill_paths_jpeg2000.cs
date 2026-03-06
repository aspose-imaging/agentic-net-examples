using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Output file path and canvas size
        string outputPath = "output.jp2";
        int width = 500;
        int height = 500;

        // Configure JPEG2000 options with a file create source
        Jpeg2000Options jp2Options = new Jpeg2000Options();
        jp2Options.Source = new FileCreateSource(outputPath, false);

        // Create a JPEG2000 image canvas
        using (Image image = Image.Create(jp2Options, width, height))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // Build a graphics path with several shapes
            GraphicsPath path = new GraphicsPath();
            Figure figure = new Figure();

            // Add a rectangle shape
            figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 200f)));
            // Add an ellipse shape
            figure.AddShape(new EllipseShape(new RectangleF(100f, 100f, 150f, 150f)));
            // Add a pie shape
            figure.AddShape(new PieShape(new RectangleF(200f, 200f, 100f, 100f), 0f, 90f));

            // Attach the figure to the path
            path.AddFigure(figure);

            // Draw the path with a blue pen
            Pen pen = new Pen(Color.Blue, 3);
            graphics.DrawPath(pen, path);

            // Save the image (the file is already bound to the source)
            image.Save();
        }
    }
}