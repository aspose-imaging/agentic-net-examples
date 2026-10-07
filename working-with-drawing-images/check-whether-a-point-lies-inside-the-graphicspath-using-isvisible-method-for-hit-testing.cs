// HOW-TO: How To Test If A Point Is Inside A GraphicsPath In C# (Aspose.Imaging for .NET)
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
            string outputPath = "output.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);
            int width = 200;
            int height = 200;

            using (Image image = Image.Create(pngOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                RectangleF rect = new RectangleF(30, 30, 140, 140);
                RectangleShape rectangleShape = new RectangleShape(rect);

                Figure figure = new Figure();
                figure.AddShape(rectangleShape);

                GraphicsPath path = new GraphicsPath();
                path.AddFigure(figure);

                Pen pen = new Pen(Color.Blue, 2);
                graphics.DrawPath(pen, path);

                Point testPoint = new Point(50, 50);
                bool isVisible = path.IsVisible(testPoint);
                Console.WriteLine($"Point ({testPoint.X}, {testPoint.Y}) is inside the path: {isVisible}");

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
 * 1. Use this code to perform hit‑testing on drawn shapes when building a custom image annotation tool that needs to know if a mouse click falls inside a rectangle.
 * 2. Apply the technique to validate user selections in a graphics editor that saves the canvas as a PNG file.
 * 3. Implement point‑inside‑shape detection for interactive game maps rendered with Aspose.Imaging, ensuring clicks trigger actions only within defined zones.
 * 4. Use the IsVisible check to create server‑side image processing that verifies whether a given coordinate lies within a generated diagram before adding labels.
 * 5. Employ this approach in a document‑generation workflow to confirm that dynamically placed elements do not overlap restricted areas on a PDF‑converted PNG page.
 */
