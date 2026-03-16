using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Output file path and canvas size
        string outputPath = "output.jpg";
        int width = 500;
        int height = 500;

        // Configure JPEG options with a file source
        JpegOptions jpegOptions = new JpegOptions();
        jpegOptions.Source = new FileCreateSource(outputPath, false);
        jpegOptions.Quality = 90;

        // Create the JPEG image canvas
        using (Image image = Image.Create(jpegOptions, width, height))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // Create an array of Figure objects
            Figure[] figures = new Figure[2];

            // First figure with a rectangle and an ellipse
            Figure figure1 = new Figure();
            figure1.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));
            figure1.AddShape(new EllipseShape(new RectangleF(300f, 50f, 150f, 150f)));
            figures[0] = figure1;

            // Second figure with a pie shape
            Figure figure2 = new Figure();
            figure2.AddShape(new PieShape(
                new RectangleF(new PointF(100f, 250f), new SizeF(200f, 200f)),
                0f,
                120f));
            figures[1] = figure2;

            // Create a GraphicsPath and add the figures array
            GraphicsPath path = new GraphicsPath();
            path.AddFigures(figures);

            // Draw the path using a black pen
            Pen pen = new Pen(Color.Black, 2);
            graphics.DrawPath(pen, path);

            // Save the image (source is already bound to the file)
            image.Save();
        }
    }
}