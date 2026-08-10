// HOW-TO: How to Test If a Point Is Inside a GraphicsPath in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input image path (must exist)
            string inputPath = @"C:\temp\input.png";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Output image path
            string outputPath = @"C:\temp\output.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the input image
            using (Image image = Image.Load(inputPath))
            {
                // Create a GraphicsPath with a rectangle shape
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 200f)));
                path.AddFigure(figure);

                // Test a point for visibility inside the path
                float testX = 100f;
                float testY = 100f;
                bool isInside = path.IsVisible(testX, testY);
                Console.WriteLine($"Point ({testX}, {testY}) inside path: {isInside}");

                // Draw the path onto the image for visual verification
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);
                graphics.DrawPath(new Pen(Color.Black, 2), path);

                // Save the resulting image
                PngOptions options = new PngOptions();
                image.Save(outputPath, options);
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
 * 1. When building a custom image editor you can use this code to determine whether a mouse click falls inside a drawn rectangle shape for selection or resizing.
 * 2. When implementing hit‑testing for interactive graphics in a C# WinForms or WPF application, the IsVisible method lets you verify if a user‑selected point lies within any GraphicsPath region.
 * 3. When generating dynamic reports that overlay shapes on PNG files, you can check point containment before adding annotations to ensure they appear inside the intended area.
 * 4. When creating a game or simulation that uses vector shapes for collision detection, this snippet shows how to test if a sprite’s coordinates intersect a rectangular path.
 * 5. When validating user‑drawn regions on a scanned document, the code can confirm whether a given coordinate is inside the predefined rectangle before processing the selection.
 */
