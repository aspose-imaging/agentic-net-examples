using System;
using System.IO;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
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
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            // Create a Graphics instance for drawing
            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

            // Create a GraphicsPath to hold vector figures
            Aspose.Imaging.GraphicsPath graphicsPath = new Aspose.Imaging.GraphicsPath();

            // Create a Figure and add shapes to it
            Aspose.Imaging.Figure figure = new Aspose.Imaging.Figure();
            figure.AddShape(new Aspose.Imaging.Shapes.RectangleShape(new Aspose.Imaging.RectangleF(50f, 50f, 200f, 150f)));
            figure.AddShape(new Aspose.Imaging.Shapes.EllipseShape(new Aspose.Imaging.RectangleF(300f, 100f, 150f, 150f)));
            figure.AddShape(new Aspose.Imaging.Shapes.PieShape(
                new Aspose.Imaging.RectangleF(new Aspose.Imaging.PointF(200f, 200f), new Aspose.Imaging.SizeF(100f, 100f)),
                0f, 90f));

            // Add the figure to the path
            graphicsPath.AddFigure(figure);

            // Draw the path onto the image
            graphics.DrawPath(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 3), graphicsPath);

            // Save the modified image as JPEG
            image.Save(outputPath);
        }
    }
}