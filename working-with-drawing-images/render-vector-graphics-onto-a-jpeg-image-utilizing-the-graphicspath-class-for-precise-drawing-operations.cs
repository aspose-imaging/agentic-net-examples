using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\output.jpg";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure JPEG options with a FileCreateSource bound to the output file
        JpegOptions jpegOptions = new JpegOptions();
        jpegOptions.Source = new FileCreateSource(outputPath, false);

        // Create a JPEG image canvas (500x500 pixels)
        using (Image image = Image.Create(jpegOptions, 500, 500))
        {
            // Initialize Graphics for drawing on the image
            Graphics graphics = new Graphics(image);

            // Clear the canvas with a light gray background
            graphics.Clear(Color.LightGray);

            // Build a GraphicsPath containing a figure with multiple shapes
            GraphicsPath path = new GraphicsPath();
            Figure figure = new Figure();

            // Rectangle shape
            figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));
            // Ellipse shape
            figure.AddShape(new EllipseShape(new RectangleF(300f, 100f, 150f, 150f)));
            // Pie shape
            figure.AddShape(new PieShape(new RectangleF(new PointF(200f, 250f), new SizeF(200f, 200f)), 0f, 120f));

            // Add the figure to the path
            path.AddFigure(figure);

            // Draw the path using a black pen of width 3
            graphics.DrawPath(new Pen(Color.Black, 3), path);

            // Save the image (output file is already bound to the source)
            image.Save();
        }
    }
}