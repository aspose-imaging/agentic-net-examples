using System;
using System.IO;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output file paths
        string inputPath = @"c:\temp\input.png";
        string outputPath = @"c:\temp\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            // Create a Graphics object for drawing
            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

            // Clear the canvas with white background
            graphics.Clear(Aspose.Imaging.Color.White);

            // Build a clipping region (a rectangle at (50,50) with size 100x100)
            Aspose.Imaging.GraphicsPath clipPath = new Aspose.Imaging.GraphicsPath();
            Aspose.Imaging.Figure clipFigure = new Aspose.Imaging.Figure();
            clipFigure.AddShape(new RectangleShape(new Aspose.Imaging.RectangleF(50f, 50f, 100f, 100f)));
            clipPath.AddFigure(clipFigure);

            // Apply the clipping region to the graphics object
            Aspose.Imaging.Region clipRegion = new Aspose.Imaging.Region(clipPath);
            graphics.Clip = clipRegion;

            // Draw a larger rectangle that exceeds the clipping bounds;
            // only the portion inside the clipping region will be rendered.
            graphics.DrawRectangle(
                new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 3),
                new Aspose.Imaging.Rectangle(0, 0, 200, 200));

            // Save the modified image to the output path
            image.Save(outputPath);
        }
    }
}