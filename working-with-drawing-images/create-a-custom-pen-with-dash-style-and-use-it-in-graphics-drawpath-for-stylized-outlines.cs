// HOW-TO: Draw Dashed Rectangle and Ellipse with Custom Pen in C# (Aspose.Imaging for .NET)
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
            // Output file path (hard‑coded)
            string outputPath = "output/output.png";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set PNG options and bind the output file
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 500×500 image
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Create a custom pen with dash style
                Pen pen = new Pen(Color.Blue, 5f);
                pen.DashStyle = DashStyle.Dash; // dashed line

                // Build a graphics path containing a rectangle and an ellipse
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 400f, 400f)));
                figure.AddShape(new EllipseShape(new RectangleF(100f, 100f, 300f, 200f)));
                path.AddFigure(figure);

                // Draw the path using the custom pen
                graphics.DrawPath(pen, path);

                // Save the image (output file already bound via FileCreateSource)
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
 * 1. When you need to generate a PNG image that highlights shapes with a dashed outline for a technical report using Aspose.Imaging in C#.
 * 2. When you want to programmatically add stylized, dashed borders around UI elements in a .NET application with a custom Pen and Graphics.DrawPath.
 * 3. When creating custom icons that combine rectangles and ellipses with a dashed stroke for a branding guide using C# and Aspose.Imaging.
 * 4. When automating the production of printable diagrams where the dash pattern distinguishes different layers, saved as PNG via Aspose.Imaging.
 * 5. When building a server‑side image service that returns PNG images with highlighted regions drawn with a custom dashed pen in C#.
 */
