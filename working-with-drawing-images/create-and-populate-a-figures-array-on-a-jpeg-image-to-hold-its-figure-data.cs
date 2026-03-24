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
        using (JpegImage image = new JpegImage(inputPath))
        {
            // Create a Graphics object for drawing (do not wrap in using)
            Graphics graphics = new Graphics(image);

            // Clear the canvas (optional, using a background color)
            graphics.Clear(Color.White);

            // Create a GraphicsPath to hold figures
            GraphicsPath graphicsPath = new GraphicsPath();

            // First figure with a rectangle and an ellipse
            Figure figure1 = new Figure();
            figure1.AddShape(new RectangleShape(new RectangleF(50, 50, 200, 150)));
            figure1.AddShape(new EllipseShape(new RectangleF(300, 50, 150, 150)));

            // Second figure with an arc and a polygon
            Figure figure2 = new Figure();
            figure2.AddShape(new ArcShape(new RectangleF(50, 250, 200, 200), 0, 180));
            figure2.AddShape(new PolygonShape(new[]
            {
                new PointF(300, 250),
                new PointF(350, 300),
                new PointF(300, 350),
                new PointF(250, 300)
            }, true));

            // Add both figures to the GraphicsPath
            graphicsPath.AddFigures(new[] { figure1, figure2 });

            // Draw the path using a black pen
            graphics.DrawPath(new Pen(Color.Black, 2), graphicsPath);

            // Save the modified image to the output path
            image.Save(outputPath);
        }
    }
}