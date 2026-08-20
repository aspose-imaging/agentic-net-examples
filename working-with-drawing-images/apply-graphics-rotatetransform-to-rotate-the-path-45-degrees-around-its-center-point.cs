// HOW-TO: Rotate a GraphicsPath 45 Degrees Around Center in C# with Aspose.Imaging (Aspose.Imaging for .NET)
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
            string outputPath = "output.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Set up PNG options with a file source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image canvas
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.Wheat);

                // Build a graphics path with a rectangle and an ellipse
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(100f, 100f, 300f, 300f)));
                figure.AddShape(new EllipseShape(new RectangleF(150f, 150f, 200f, 200f)));
                path.AddFigure(figure);

                // Rotate the path 45 degrees around the image center
                float centerX = image.Width / 2f;
                float centerY = image.Height / 2f;
                graphics.TranslateTransform(centerX, centerY);
                graphics.RotateTransform(45);
                graphics.TranslateTransform(-centerX, -centerY);

                // Draw the rotated path
                graphics.DrawPath(new Pen(Color.Black, 2), path);

                // Save the image (source is already bound to the file)
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
 * 1. When you need to generate a PNG thumbnail that shows a rectangle and ellipse rotated for a dynamic UI icon.
 * 2. When creating a custom watermark that must be tilted at a 45-degree angle around the image center.
 * 3. When producing printable diagrams where shapes must be rotated to align with design specifications.
 * 4. When developing a game asset pipeline that requires pre-rotated vector shapes saved as PNG files.
 * 5. When automating report graphics that need a consistent 45-degree rotation of composite shapes for visual emphasis.
 */
