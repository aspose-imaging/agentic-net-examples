using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\output.png";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up PNG options with a FileCreateSource bound to the output file
        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        // Create a new PNG image with the specified dimensions
        using (Image image = Image.Create(pngOptions, 500, 500))
        {
            // Initialize graphics for drawing on the image
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.Wheat);

            // Build a graphics path containing a rectangle, ellipse, and pie shape
            GraphicsPath path = new GraphicsPath();
            Figure figure = new Figure();

            figure.AddShape(new RectangleShape(new RectangleF(10f, 10f, 300f, 300f)));
            figure.AddShape(new EllipseShape(new RectangleF(50f, 50f, 300f, 300f)));
            figure.AddShape(new PieShape(new RectangleF(new PointF(250f, 250f), new SizeF(200f, 200f)), 0f, 45f));

            path.AddFigure(figure);

            // Draw the constructed path with a black pen
            graphics.DrawPath(new Pen(Color.Black, 2), path);

            // Save the image (file is already bound via FileCreateSource)
            image.Save();
        }
    }
}