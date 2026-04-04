using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Initialize graphics object for drawing
            Graphics graphics = new Graphics(image);

            // Create a graphics path to hold the star figure
            GraphicsPath graphicsPath = new GraphicsPath();

            // Define star points (5‑pointed star)
            PointF[] starPoints = new PointF[]
            {
                new PointF(250f,  50f),   // top
                new PointF(317f, 182f),
                new PointF(460f, 200f),
                new PointF(350f, 300f),
                new PointF(380f, 440f),
                new PointF(250f, 370f),
                new PointF(120f, 440f),
                new PointF(150f, 300f),
                new PointF( 40f, 200f),
                new PointF(183f, 182f)
            };

            // Create a figure and add a closed polygon shape representing the star
            Figure starFigure = new Figure();
            starFigure.AddShape(new PolygonShape(starPoints, true));

            // Add the figure to the graphics path
            graphicsPath.AddFigure(starFigure);

            // Draw the star path with a black pen of width 2
            Pen pen = new Pen(Color.Black, 2);
            graphics.DrawPath(pen, graphicsPath);

            // Save the modified image to the output path
            image.Save(outputPath);
        }
    }
}