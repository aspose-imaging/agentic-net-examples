// HOW-TO: Draw Path Outline With Black Pen On PNG Image In C# (Aspose.Imaging for .NET)
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
            // Define output path
            string outputPath = @"C:\temp\output.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up PNG options with a file create source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image canvas
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Build a graphics path with some shapes
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 200f)));
                figure.AddShape(new EllipseShape(new RectangleF(100f, 100f, 200f, 200f)));
                path.AddFigure(figure);

                // Draw the path outline using a contrasting black pen
                graphics.DrawPath(new Pen(Color.Black, 3), path);

                // Save the image (output file is already bound via FileCreateSource)
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
 * 1. When you need to generate a PNG file that highlights combined shapes with a contrasting black outline for UI icons or thumbnails.
 * 2. When creating printable diagrams where overlapping rectangles and ellipses must be clearly distinguished by a bold stroke.
 * 3. When automating the production of vector‑like graphics for reports that require a crisp outline around custom paths.
 * 4. When building a web service that returns dynamically drawn shapes as PNG images with a visible black border for better visibility.
 * 5. When developing a testing tool that visualizes geometric calculations by drawing shapes and outlining them for debugging purposes.
 */
