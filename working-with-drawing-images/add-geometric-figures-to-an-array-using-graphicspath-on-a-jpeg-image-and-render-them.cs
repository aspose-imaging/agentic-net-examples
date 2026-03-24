using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.jpg";
        string outputPath = @"C:\temp\output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the JPEG image
        using (Image image = Image.Load(inputPath))
        {
            // Create graphics object for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // Create a GraphicsPath to hold figures
            GraphicsPath graphicsPath = new GraphicsPath();

            // First figure with rectangle, ellipse, and pie shapes
            Figure figure1 = new Figure();
            figure1.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));
            figure1.AddShape(new EllipseShape(new RectangleF(300f, 50f, 150f, 150f)));
            figure1.AddShape(new PieShape(new RectangleF(200f, 250f, 200f, 200f), 0f, 120f));

            // Second figure with arc, polygon, and rectangle shapes
            Figure figure2 = new Figure();
            figure2.AddShape(new ArcShape(new RectangleF(50f, 300f, 150f, 150f), 45f, 270f));
            figure2.AddShape(new PolygonShape(new[]
            {
                new PointF(400f, 300f),
                new PointF(500f, 350f),
                new PointF(450f, 450f),
                new PointF(350f, 400f)
            }, true));
            figure2.AddShape(new RectangleShape(new RectangleF(100f, 500f, 250f, 100f)));

            // Add both figures to the GraphicsPath
            graphicsPath.AddFigures(new[] { figure1, figure2 });

            // Draw the path onto the image
            graphics.DrawPath(new Pen(Color.Black, 2), graphicsPath);

            // Save the modified image as JPEG with options
            JpegOptions jpegOptions = new JpegOptions
            {
                Quality = 90
            };
            image.Save(outputPath, jpegOptions);
        }
    }
}