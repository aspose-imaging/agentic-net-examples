using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output path
            string outputPath = @"C:\Temp\gradientPath.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create PNG options with a file create source bound to the output path
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Define image dimensions
            int width = 500;
            int height = 500;

            // Create the image canvas
            using (Image image = Image.Create(pngOptions, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Clear background
                graphics.Clear(Color.White);

                // Create a graphics path
                GraphicsPath path = new GraphicsPath();

                // Create a figure and add shapes
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 400f, 400f)));
                figure.AddShape(new EllipseShape(new RectangleF(100f, 100f, 300f, 300f)));

                // Add the figure to the path
                path.AddFigure(figure);

                // Create a solid brush (replace with a gradient brush if available)
                using (SolidBrush brush = new SolidBrush())
                {
                    brush.Color = Color.LightBlue;
                    brush.Opacity = 100;

                    // Fill the path with the brush
                    graphics.FillPath(brush, path);
                }

                // Save the image (source is already bound to outputPath)
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
 * 1. When a developer needs to generate a PNG badge with a custom‑shaped logo that is filled with a linear gradient for branding purposes.
 * 2. When an application must create dynamic report graphics, such as gradient‑filled circular progress indicators, and save them as high‑resolution PNG files.
 * 3. When a web service produces on‑the‑fly map overlays where polygons are rendered with smooth color transitions using a gradient brush.
 * 4. When a desktop tool creates printable flyers and wants to add decorative frames or watermarks with gradient‑filled rectangles and ellipses.
 * 5. When a game engine exports UI assets, like buttons or icons, by programmatically drawing shapes with gradient fills and exporting them as PNG images for later use.
 */