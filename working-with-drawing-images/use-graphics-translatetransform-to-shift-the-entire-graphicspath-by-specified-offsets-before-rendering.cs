// HOW-TO: Apply TranslateTransform To Move GraphicsPath Before Drawing In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path (hardcoded)
            string outputPath = "output.png";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Set up PNG options with a file create source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image canvas
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, 400, 400))
            {
                // Initialize graphics for drawing
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.LightGray);

                // Build a graphics path with shapes
                Aspose.Imaging.GraphicsPath path = new Aspose.Imaging.GraphicsPath();
                Aspose.Imaging.Figure figure = new Aspose.Imaging.Figure();

                // Add a rectangle shape
                figure.AddShape(new Aspose.Imaging.Shapes.RectangleShape(new Aspose.Imaging.RectangleF(50f, 50f, 100f, 100f)));
                // Add an ellipse shape
                figure.AddShape(new Aspose.Imaging.Shapes.EllipseShape(new Aspose.Imaging.RectangleF(200f, 50f, 100f, 150f)));

                path.AddFigure(figure);

                // Shift the entire path by the specified offsets
                graphics.TranslateTransform(50f, 30f);

                // Render the path
                graphics.DrawPath(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 3), path);

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
 * 1. When you need to offset multiple vector shapes together on a PNG canvas without modifying each shape’s coordinates individually.
 * 2. When generating a diagram in C# where all elements must be positioned relative to a margin or padding using Aspose.Imaging.
 * 3. When creating a printable badge or label and you want to shift the entire graphics path to align with page borders before saving as PNG.
 * 4. When re‑using a predefined GraphicsPath in different layouts and you need to place it at various X/Y offsets programmatically with TranslateTransform.
 * 5. When building a dynamic UI thumbnail and you must translate the drawn shapes to fit within a background image using Aspose.Imaging’s Graphics class.
 */
