using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output path
            string outputPath = "output\\gradient.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create PNG options
            PngOptions pngOptions = new PngOptions();

            // Define image dimensions
            int width = 300;
            int height = 300;

            // Create a new image
            using (Image image = Image.Create(pngOptions, width, height))
            {
                // Initialize graphics for the image
                Graphics graphics = new Graphics(image);

                // Clear background
                graphics.Clear(Color.White);

                // Create a graphics path with a rectangle shape
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 200f)));
                path.AddFigure(figure);

                // Create a linear gradient brush (blue to red)
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    new PointF(50f, 50f),
                    new PointF(250f, 250f),
                    Color.Blue,
                    Color.Red))
                {
                    // Fill the path with the gradient brush
                    graphics.FillPath(brush, path);
                }

                // Save the image to the output file
                image.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to generate a PNG badge with a gradient‑filled rectangle for a web application, they can use Aspose.Imaging in C# to draw the shape with Graphics.FillPath and a LinearGradientBrush.
 * 2. When building a reporting dashboard that requires dynamic chart backgrounds, a developer can create gradient‑filled paths on the fly using Aspose.Imaging’s Graphics and LinearGradientBrush to produce PNG or JPEG assets.
 * 3. When adding a branded gradient border around a QR code, a developer can render the border as a gradient‑filled path with Aspose.Imaging and save it as a PNG file.
 * 4. When a Windows desktop application needs to create custom icons with smooth color transitions, a developer can use C# and Aspose.Imaging to fill a shape with a linear gradient via Graphics.FillPath.
 * 5. When automating the production of promotional flyers where key sections are highlighted with gradient rectangles, a developer can programmatically draw those shapes using Aspose.Imaging’s GraphicsPath and LinearGradientBrush and export them as PNG images.
 */