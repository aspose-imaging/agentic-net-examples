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
            // Define output path
            string outputPath = "output.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Set up PNG options with a file source bound to the output path
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image canvas
            using (Image image = Image.Create(pngOptions, 400, 400))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Build a graphics path containing a rectangle shape
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 300f, 300f)));
                path.AddFigure(figure);

                // Create a solid brush, set its opacity, and fill the path
                using (SolidBrush brush = new SolidBrush(Color.Blue))
                {
                    brush.Opacity = 0.5f; // 50% opacity
                    graphics.FillPath(brush, path);
                }

                // Optionally draw the outline of the path
                graphics.DrawPath(new Pen(Color.Black, 2), path);

                // Save the image (output path already bound)
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
 * 1. When creating a semi‑transparent overlay on a PNG canvas to highlight a region without obscuring the background, a developer can set the SolidBrush opacity before calling FillPath.
 * 2. When generating watermarked images where the watermark text or shape must appear faintly over the original picture, adjusting the brush’s Alpha value prior to FillPath provides the required translucency.
 * 3. When designing UI mock‑ups that need a colored rectangle with 50 % opacity to simulate disabled controls, the code demonstrates how to set brush.Opacity and fill a GraphicsPath.
 * 4. When producing layered graphics for reports, such as a blue shading behind a chart area that should blend with underlying grid lines, setting the brush opacity before FillPath achieves the blend effect.
 * 5. When exporting vector‑style shapes to a PNG file and needing the fill color to be partially transparent for later compositing in image editors, the example shows how to configure the SolidBrush opacity and fill the path.
 */