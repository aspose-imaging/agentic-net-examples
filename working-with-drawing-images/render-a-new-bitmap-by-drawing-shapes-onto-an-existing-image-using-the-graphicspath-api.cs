using System;
using System.IO;
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

        // Load the existing image
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            // Create graphics for drawing
            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

            // Create a graphics path and a figure
            Aspose.Imaging.GraphicsPath path = new Aspose.Imaging.GraphicsPath();
            Aspose.Imaging.Figure figure = new Aspose.Imaging.Figure();

            // Add shapes to the figure
            figure.AddShape(new RectangleShape(new Aspose.Imaging.RectangleF(10f, 10f, 200f, 200f)));
            figure.AddShape(new EllipseShape(new Aspose.Imaging.RectangleF(250f, 50f, 150f, 150f)));
            figure.AddShape(new PieShape(
                new Aspose.Imaging.RectangleF(new Aspose.Imaging.PointF(100f, 200f), new Aspose.Imaging.SizeF(200f, 200f)),
                0f, 90f));

            // Add the figure to the graphics path
            path.AddFigure(figure);

            // Draw the path onto the image
            graphics.DrawPath(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2), path);

            // Save the modified image
            image.Save(outputPath);
        }
    }
}