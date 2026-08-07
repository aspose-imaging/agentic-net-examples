using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path
            string outputPath = @"C:\temp\output.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up PNG options with a file source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image canvas
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Build a graphics path with a rectangle and an ellipse
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 200f)));
                figure.AddShape(new EllipseShape(new RectangleF(150f, 100f, 200f, 150f)));
                path.AddFigure(figure);

                // Draw the path outline with a contrasting black pen
                graphics.DrawPath(new Pen(Color.Black, 3), path);

                // Save the image (output file already bound via FileCreateSource)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When generating a PNG thumbnail that highlights selected regions with a black outline for a web‑based image annotation tool.
 * 2. When creating a PNG diagram that requires a high‑contrast vector border around combined shapes such as rectangles and ellipses using Aspose.Imaging in C#.
 * 3. When building a desktop application that visualizes geometric intersections by drawing the path outline with a contrasting pen on a white canvas.
 * 4. When exporting a diagram to PNG where the outline of merged shapes must stand out against a light background for accessibility compliance.
 * 5. When developing a batch image‑processing script that adds a clear black stroke around custom graphics paths to improve visual distinction before saving the file.
 */