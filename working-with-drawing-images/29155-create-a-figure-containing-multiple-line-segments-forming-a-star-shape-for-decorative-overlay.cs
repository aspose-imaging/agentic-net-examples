using System;
using System.IO;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
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

        // Load the base image
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            // Create graphics for drawing
            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

            // Create a graphics path and a figure
            Aspose.Imaging.GraphicsPath graphicsPath = new Aspose.Imaging.GraphicsPath();
            Aspose.Imaging.Figure figure = new Aspose.Imaging.Figure();

            // Define points for a star shape (10-pointed star)
            Aspose.Imaging.PointF[] starPoints = new Aspose.Imaging.PointF[]
            {
                new Aspose.Imaging.PointF(250f, 50f),
                new Aspose.Imaging.PointF(300f, 200f),
                new Aspose.Imaging.PointF(450f, 200f),
                new Aspose.Imaging.PointF(330f, 300f),
                new Aspose.Imaging.PointF(380f, 450f),
                new Aspose.Imaging.PointF(250f, 350f),
                new Aspose.Imaging.PointF(120f, 450f),
                new Aspose.Imaging.PointF(170f, 300f),
                new Aspose.Imaging.PointF(50f, 200f),
                new Aspose.Imaging.PointF(200f, 200f)
            };

            // Add a closed polygon shape representing the star
            figure.AddShape(new PolygonShape(starPoints, true));

            // Add the figure to the graphics path
            graphicsPath.AddFigure(figure);

            // Draw the star outline with a yellow pen
            graphics.DrawPath(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Yellow, 3), graphicsPath);

            // Save the resulting image
            image.Save(outputPath);
        }
    }
}