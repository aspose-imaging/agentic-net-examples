using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output path
            string outputPath = "output/output.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up PNG options with a bound file source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image canvas (500x500)
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Build a graphics path with a rectangle and an ellipse
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 200f)));
                figure.AddShape(new EllipseShape(new RectangleF(150f, 150f, 200f, 200f)));
                path.AddFigure(figure);

                // Draw the path outline with a black pen of width 2
                Pen pen = new Pen(Color.Black, 2);
                graphics.DrawPath(pen, path);

                // Save the image (output is already bound to the file)
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
 * 1. When a developer needs to generate a PNG thumbnail that highlights the borders of UI components such as buttons or panels for documentation or design reviews.
 * 2. When creating a printable report that overlays vector outlines on a white canvas to illustrate layout zones, using C# and Aspose.Imaging's GraphicsPath and Pen.
 * 3. When building a web service that returns a PNG image with highlighted geometric shapes (rectangle and ellipse) for a mapping or diagramming application.
 * 4. When automating the production of test images that verify the correctness of shape rendering pipelines by drawing black outlines of shapes with a 2‑pixel pen.
 * 5. When developing a desktop utility that visualizes collision boundaries or hit‑boxes in a game by drawing path outlines onto a PNG file using Aspose.Imaging for .NET.
 */