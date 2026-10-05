// HOW-TO: How to Fill a Path with Solid Color in PNG Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output\\gradient_path.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define image size
            int width = 500;
            int height = 500;

            // Create PNG options with FileCreateSource bound to output path
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create the image canvas
            using (Image image = Image.Create(pngOptions, width, height))
            {
                // Initialize graphics
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Create a graphics path
                Aspose.Imaging.GraphicsPath path = new Aspose.Imaging.GraphicsPath();

                // Create a figure and add a rectangle shape
                Figure figure = new Figure();
                RectangleShape rectShape = new RectangleShape(new RectangleF(50, 50, 400, 400));
                figure.AddShape(rectShape);

                // Add the figure to the path
                path.AddFigure(figure);

                // Use a solid brush (gradient not supported for FillPath)
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(255, 255, 0, 0))) // Red color
                {
                    // Fill the path
                    graphics.FillPath(brush, path);
                }

                // Save the image (bound to the file)
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
 * 1. When you need to generate a PNG badge with a solid‑colored rectangle background programmatically in C#.
 * 2. When creating a custom thumbnail that requires drawing a filled shape onto an image canvas using Aspose.Imaging.
 * 3. When automating the production of printable labels that contain a solid‑filled rectangular area for branding.
 * 4. When building a server‑side service that renders simple graphics, such as a colored frame, into PNG files without external dependencies.
 * 5. When testing graphics pipelines by drawing a known solid shape to verify that FillPath and brush handling work correctly.
 */
