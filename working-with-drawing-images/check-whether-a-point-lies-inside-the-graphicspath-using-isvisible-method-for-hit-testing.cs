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
            string outputPath = @"C:\temp\output.png";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up PNG options with a file create source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a blank image canvas
            using (Image image = Image.Create(pngOptions, 400, 400))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Build a graphics path containing a rectangle shape
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 200f)));
                path.AddFigure(figure);

                // Draw the path for visual reference
                Pen pen = new Pen(Color.Black, 2);
                graphics.DrawPath(pen, path);

                // Test a point that lies inside the rectangle
                float insideX = 100f;
                float insideY = 100f;
                bool isInside = path.IsVisible(insideX, insideY);
                Console.WriteLine($"Point ({insideX}, {insideY}) inside path: {isInside}");

                // Test a point that lies outside the rectangle
                float outsideX = 10f;
                float outsideY = 10f;
                bool isOutside = path.IsVisible(outsideX, outsideY);
                Console.WriteLine($"Point ({outsideX}, {outsideY}) inside path: {isOutside}");

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
 * 1. When building an interactive PNG map where clicking on a drawn rectangle should trigger an action, a developer can use IsVisible to determine if the mouse coordinates fall inside the GraphicsPath.
 * 2. When creating a custom diagram editor that lets users select and move shapes, IsVisible helps to perform hit testing on the rectangle shape stored in a GraphicsPath to know which object was clicked.
 * 3. When implementing a PDF‑to‑image conversion tool that overlays clickable hotspots on the generated PNG, IsVisible can verify whether a user‑supplied point lies within a defined hotspot region.
 * 4. When developing a game UI that displays button‑like regions drawn with Aspose.Imaging shapes, IsVisible enables the engine to detect clicks inside those button areas for event handling.
 * 5. When adding annotation features to a medical image viewer, IsVisible can be used to check if a cursor position is inside a rectangular annotation drawn on a PNG canvas before allowing edits.
 */