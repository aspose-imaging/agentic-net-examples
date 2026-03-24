using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input\\sample.bmp";
        string outputPath = "output\\filled.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Create a Graphics object for drawing
            Graphics graphics = new Graphics(image);

            // Create a GraphicsPath and a closed Figure
            GraphicsPath path = new GraphicsPath();
            Figure figure = new Figure { IsClosed = true };
            path.AddFigure(figure);

            // Add shapes to the Figure
            figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));
            figure.AddShape(new EllipseShape(new RectangleF(300f, 100f, 150f, 150f)));
            figure.AddShape(new PolygonShape(new PointF[]
            {
                new PointF(100f, 300f),
                new PointF(150f, 350f),
                new PointF(50f, 350f)
            }));

            // Fill the path with a yellow brush
            using (SolidBrush fillBrush = new SolidBrush(Color.Yellow))
            {
                graphics.FillPath(fillBrush, path);
            }

            // Outline the path with a green pen
            Pen outlinePen = new Pen(Color.Green, 2);
            graphics.DrawPath(outlinePen, path);

            // Save the modified image as BMP
            BmpOptions bmpOptions = new BmpOptions();
            image.Save(outputPath, bmpOptions);
        }
    }
}