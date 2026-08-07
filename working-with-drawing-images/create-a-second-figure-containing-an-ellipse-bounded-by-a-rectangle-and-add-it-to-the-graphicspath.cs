using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"c:\temp\output.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up PNG options with a file create source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image (500x500)
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Create a graphics path
                GraphicsPath graphicspath = new GraphicsPath();

                // First figure (example rectangle)
                Figure figure1 = new Figure();
                figure1.AddShape(new RectangleShape(new RectangleF(10f, 10f, 200f, 200f)));
                graphicspath.AddFigure(figure1);

                // Second figure containing an ellipse bounded by a rectangle
                Figure figure2 = new Figure();
                // Ellipse bounded by the specified rectangle
                figure2.AddShape(new EllipseShape(new RectangleF(250f, 250f, 200f, 150f)));
                graphicspath.AddFigure(figure2);

                // Draw the path with a black pen
                graphics.DrawPath(new Pen(Color.Black, 2), graphicspath);

                // Save the image (output path already bound via FileCreateSource)
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
 * 1. When a developer needs to generate a PNG report thumbnail that highlights a selected area with a rectangle and an ellipse for visual annotation.
 * 2. When an application must programmatically create a placeholder image for a UI component, drawing basic shapes like a rectangle and an ellipse to indicate layout zones.
 * 3. When a batch process creates custom watermarks by overlaying geometric figures onto blank canvases before compositing with other images.
 * 4. When a testing tool requires a deterministic image file containing known shapes to validate image processing algorithms such as shape detection or bounding‑box calculations.
 * 5. When a documentation generator automatically produces diagrammatic examples in PNG format, illustrating how to use Aspose.Imaging’s GraphicsPath and Figure classes.
 */