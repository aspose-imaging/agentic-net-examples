using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output JPEG file path
        string outputPath = "output.jpg";
        int width = 500;
        int height = 500;

        // Configure JPEG options with a file source
        JpegOptions jpegOptions = new JpegOptions();
        jpegOptions.Source = new FileCreateSource(outputPath, false);
        jpegOptions.Quality = 90; // optional quality setting

        // Create the image canvas bound to the output file
        using (Image image = Image.Create(jpegOptions, width, height))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // Build a graphics path with a figure containing shapes
            GraphicsPath path = new GraphicsPath();
            Figure figure = new Figure();

            // Rectangle shape
            figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));
            // Ellipse shape
            figure.AddShape(new EllipseShape(new RectangleF(300f, 100f, 150f, 150f)));
            // Pie shape
            figure.AddShape(new PieShape(new RectangleF(new PointF(150f, 250f), new SizeF(200f, 200f)), 0f, 120f));

            // Add the figure to the path
            path.AddFigure(figure);

            // Draw the path with a blue pen
            Pen pen = new Pen(Color.Blue, 3);
            graphics.DrawPath(pen, path);

            // Save the image (output file is already bound)
            image.Save();
        }
    }
}