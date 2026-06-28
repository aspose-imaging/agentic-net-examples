using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"c:\temp\output.bmp";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP options with the output file as source
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a new image
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics object
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.Wheat);

                // Create a graphics path
                GraphicsPath graphicspath = new GraphicsPath();

                // First figure with a rectangle and an ellipse
                Figure figure1 = new Figure();
                figure1.AddShape(new RectangleShape(new RectangleF(10f, 10f, 300f, 300f)));
                figure1.AddShape(new EllipseShape(new RectangleF(50f, 50f, 300f, 300f)));
                graphicspath.AddFigure(figure1);

                // Second figure containing only an ellipse bounded by a rectangle
                Figure figure2 = new Figure();
                figure2.AddShape(new EllipseShape(new RectangleF(150f, 150f, 200f, 200f)));
                graphicspath.AddFigure(figure2);

                // Draw the combined path
                graphics.DrawPath(new Pen(Color.Black, 2), graphicspath);

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
 * 1. When building a dynamic dashboard that needs to overlay a highlighted circular region on a BMP background, a developer can use this code to draw an ellipse bounded by a rectangle as a second figure in a GraphicsPath.
 * 2. When generating printable certificates that require a decorative oval seal positioned precisely on a 500×500 image, the code lets the developer add the seal as an ellipse shape within a separate figure.
 * 3. When creating custom map markers where each marker consists of a rectangular border and a centered circular icon, a developer can employ this approach to add the circular marker as a second figure to the path.
 * 4. When producing a batch of product thumbnails that need a consistent circular highlight around the product area, the code enables the developer to draw the highlight ellipse bounded by a rectangle on each BMP file.
 * 5. When designing a simple game UI that displays a button with a rectangular background and a separate elliptical accent, a developer can use this technique to render the accent as an additional figure in the graphics path.
 */