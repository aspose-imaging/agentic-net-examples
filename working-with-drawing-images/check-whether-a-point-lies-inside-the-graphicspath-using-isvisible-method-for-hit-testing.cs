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
            // Hardcoded output path
            string outputPath = "output.png";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up PNG options with a file source bound to the output path
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 200x200 image canvas
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, 200, 200))
            {
                // Initialize graphics for drawing
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                // Build a graphics path containing a rectangle shape
                Aspose.Imaging.GraphicsPath path = new Aspose.Imaging.GraphicsPath();
                Aspose.Imaging.Figure figure = new Aspose.Imaging.Figure();
                figure.AddShape(new RectangleShape(new Aspose.Imaging.RectangleF(50f, 50f, 100f, 100f)));
                path.AddFigure(figure);

                // Render the path onto the image
                graphics.DrawPath(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2), path);

                // Hit‑testing: check points inside and outside the path
                bool inside = path.IsVisible(75f, 75f);   // Expected: true
                bool outside = path.IsVisible(10f, 10f); // Expected: false

                Console.WriteLine($"Point (75,75) inside path: {inside}");
                Console.WriteLine($"Point (10,10) inside path: {outside}");

                // Save the image (already bound to the output file)
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
 * 1. When building an interactive diagram editor where users click on shapes drawn on a PNG canvas, a developer can use IsVisible on a GraphicsPath to determine if the click occurred inside a rectangle.
 * 2. When implementing custom image map generation for web pages, a developer can test points against a GraphicsPath to decide which region of a PNG should be linked.
 * 3. When creating a game UI overlay that highlights selectable areas on a 200x200 sprite, a developer can use IsVisible to perform hit‑testing for mouse or touch input.
 * 4. When validating user‑drawn annotations on a scanned document, a developer can check if the annotation point lies within a predefined rectangular boundary using IsVisible.
 * 5. When developing a CAD‑like measurement tool that snaps to predefined zones on a PNG blueprint, a developer can employ IsVisible to confirm whether the cursor is inside the target zone.
 */