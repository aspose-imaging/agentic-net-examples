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
            string outputPath = @"output.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create PNG options with a FileCreateSource bound to the output file
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image canvas
            using (Image image = Image.Create(pngOptions, 400, 400))
            {
                // Initialize Graphics for drawing
                Graphics graphics = new Graphics(image);

                // Create a solid brush, set color and opacity (0.5 = 50% transparent)
                SolidBrush brush = new SolidBrush();
                brush.Color = Color.Blue;
                brush.Opacity = 0.5f; // Opacity between 0 (fully visible) and 1 (fully opaque)

                // Build a graphics path with a rectangle shape
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(100f, 100f, 200f, 200f)));
                path.AddFigure(figure);

                // Fill the path using the brush with adjusted opacity
                graphics.FillPath(brush, path);

                // Save the image (output file already bound)
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
 * 1. When generating a PNG overlay with semi‑transparent shapes for a web UI, a developer can set the brush opacity before FillPath to create a 50 % transparent blue rectangle.
 * 2. When producing a printable PDF thumbnail that requires a watermark effect, adjusting the brush’s Alpha value lets the watermark be drawn with the desired translucency using Aspose.Imaging’s FillPath.
 * 3. When building a dynamic chart image where grid lines need to appear faint, a developer can use a SolidBrush with reduced opacity and FillPath to render the lines without obscuring the data.
 * 4. When creating a game sprite sheet where background elements must be partially see‑through, setting the brush opacity before filling a path ensures the sprite’s background blends correctly in the final PNG.
 * 5. When automating the generation of marketing banners that combine brand colors with a translucent overlay, adjusting the brush’s Opacity prior to FillPath produces the required semi‑transparent effect across different image formats.
 */