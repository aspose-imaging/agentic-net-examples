// HOW-TO: Clone and Modify a GraphicsPath Then Render Both in C# (Aspose.Imaging for .NET)
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
            // Output file path
            string outputPath = @"output.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

            // Create PNG image options and bind to output file
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image canvas
            using (Image image = Image.Create(pngOptions, 600, 400))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Build the original GraphicsPath
                GraphicsPath originalPath = new GraphicsPath();
                Figure originalFigure = new Figure();
                originalFigure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));
                originalFigure.AddShape(new EllipseShape(new RectangleF(300f, 50f, 150f, 150f)));
                originalPath.AddFigure(originalFigure);

                // Draw the original path
                graphics.DrawPath(new Pen(Color.Black, 2), originalPath);

                // Clone the original path
                GraphicsPath clonedPath = originalPath.DeepClone();

                // Modify the cloned path by adding a new figure
                Figure newFigure = new Figure();
                newFigure.AddShape(new PieShape(new RectangleF(200f, 200f, 200f, 200f), 0f, 120f));
                clonedPath.AddFigure(newFigure);

                // Draw the modified cloned path
                graphics.DrawPath(new Pen(Color.Red, 2), clonedPath);

                // Save the image
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
 * 1. Use this code to draw the original GraphicsPath in black and a modified clone in red, allowing you to show both the unchanged vector shape and its edited version on the same PNG image.
 * 2. Apply the deep clone technique when building an undo feature for a C# drawing app, so the original path remains intact while the user experiments with new figures.
 * 3. Generate a base diagram and then overlay additional annotations by cloning the GraphicsPath, useful for creating layered technical illustrations saved as PNG.
 * 4. Compare two versions of a vector drawing by rendering the original and the altered cloned path with different pen colors, helpful for visual diff reports.
 * 5. Implement a design‑tool workflow where a user adds a pie slice to a copied GraphicsPath, enabling safe experimentation before updating the original artwork.
 */
