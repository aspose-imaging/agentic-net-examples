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
            // Output file path (hardcoded)
            string outputPath = "output.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Create image bound to the output file
            var source = new FileCreateSource(outputPath, false);
            var pngOptions = new PngOptions { Source = source };

            using (Image image = Image.Create(pngOptions, 200, 200))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Build a simple rectangular path
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 100f, 100f)));
                path.AddFigure(figure);

                // Draw the path
                graphics.DrawPath(new Pen(Color.Black, 2), path);

                // Test a point for containment
                float testX = 75f;
                float testY = 75f;
                bool isInside = path.IsVisible(testX, testY);
                Console.WriteLine($"Point ({testX}, {testY}) inside path: {isInside}");

                // Save the image (already bound to output file)
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
 * 1. When building an interactive image editor that lets users click on drawn shapes to select them, you can use IsVisible to determine if the mouse click point lies inside a rectangular GraphicsPath before highlighting the shape.
 * 2. When generating a PNG report with clickable regions, IsVisible helps verify that a given coordinate falls within a defined annotation area so you can attach a hyperlink correctly.
 * 3. When implementing custom collision detection in a game that renders sprites onto a bitmap, you can use IsVisible on a GraphicsPath representing a sprite’s bounding box to test whether a projectile’s position hits the sprite.
 * 4. When creating a map overlay where users can tap on zones drawn as paths, IsVisible enables hit‑testing to trigger tooltips or data pop‑ups for the selected region.
 * 5. When performing automated UI testing of a drawing application, you can programmatically confirm that a shape was rendered at the expected location by checking if a test point is visible inside the shape’s GraphicsPath.
 */