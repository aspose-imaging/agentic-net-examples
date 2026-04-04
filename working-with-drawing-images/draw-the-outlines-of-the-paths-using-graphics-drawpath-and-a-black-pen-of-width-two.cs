using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

public class Program
{
    public static void Main(string[] args)
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\output.png";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up PNG options with a bound file source
        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        // Create the image canvas
        using (Image image = Image.Create(pngOptions, 500, 500))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // Build a graphics path with a figure and shapes
            GraphicsPath path = new GraphicsPath();
            Figure figure = new Figure();

            figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 300f, 300f)));
            figure.AddShape(new EllipseShape(new RectangleF(100f, 100f, 200f, 200f)));

            path.AddFigure(figure);

            // Draw the outline of the path using a black pen of width 2
            graphics.DrawPath(new Pen(Color.Black, 2), path);

            // Save the image (bound to the output file)
            image.Save();
        }
    }
}