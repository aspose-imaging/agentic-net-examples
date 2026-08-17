// HOW-TO: Get GraphicsPath Bounding Rectangle and Align Elements in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "input.png";
            string outputPath = "output.png";

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
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Create a graphics path and add a rectangle shape
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                RectangleF rect = new RectangleF(50f, 50f, 200f, 150f);
                figure.AddShape(new RectangleShape(rect));
                path.AddFigure(figure);

                // Draw the original path
                graphics.DrawPath(new Pen(Color.Black, 2), path);

                // Use the original rectangle as bounds
                RectangleF bounds = rect;

                // Align an additional element: draw a red rectangle around the bounds
                graphics.DrawRectangle(new Pen(Color.Red, 2), new RectangleF(bounds.X, bounds.Y, bounds.Width, bounds.Height));

                // Save the modified image
                image.Save(outputPath);
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
 * 1. When you need to determine the exact bounding rectangle of a GraphicsPath in a PNG file so you can place other graphics precisely.
 * 2. When you want to draw a red outline around a previously drawn shape to highlight its area in a C# image‑processing routine.
 * 3. When generating dynamic diagrams that require aligning labels or icons to the edges of vector shapes created with Aspose.Imaging.
 * 4. When building a custom UI overlay that must snap buttons or tooltips to the corners of a rectangle drawn on an image.
 * 5. When automating image annotation where the annotation box must match the size and position of an existing graphics path.
 */
