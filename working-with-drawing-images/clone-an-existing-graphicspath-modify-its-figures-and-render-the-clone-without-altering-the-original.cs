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

            // Create PNG options with a FileCreateSource bound to the output file
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image canvas (500x500)
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // ----- Original GraphicsPath -----
                GraphicsPath originalPath = new GraphicsPath();
                Figure originalFigure = new Figure();
                originalFigure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 200f)));
                originalPath.AddFigure(originalFigure);

                // Draw the original path with a black pen
                graphics.DrawPath(new Pen(Color.Black, 2), originalPath);

                // ----- Clone and modify -----
                GraphicsPath clonedPath = originalPath.DeepClone();

                // Add an additional ellipse to the cloned path
                Figure extraFigure = new Figure();
                extraFigure.AddShape(new EllipseShape(new RectangleF(150f, 150f, 100f, 100f)));
                clonedPath.AddFigure(extraFigure);

                // Draw the cloned (modified) path with a red pen
                graphics.DrawPath(new Pen(Color.Red, 2), clonedPath);

                // Save the image (the output file is already bound to the source)
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
 * 1. When generating a printable PDF report that needs a base shape such as a logo rectangle and an overlay highlight like a red ellipse without changing the original logo geometry.
 * 2. When creating a UI thumbnail where the original vector icon must stay unchanged while a temporary selection ring is drawn around it for preview.
 * 3. When building a map visualization that reuses a country border path but adds a semi‑transparent overlay for a selected region without affecting the master border data.
 * 4. When producing a CAD drawing where the original component outline is cloned to add measurement annotations (ellipse) for a design review, preserving the original model.
 * 5. When developing a game asset pipeline that clones a sprite’s collision path to draw debugging guides (red ellipse) on the same canvas while keeping the original collision shape intact.
 */