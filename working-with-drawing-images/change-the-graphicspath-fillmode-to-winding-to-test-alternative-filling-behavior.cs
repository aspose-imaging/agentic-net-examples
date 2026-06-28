using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\output_winding.png";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Set up PNG options with a bound file source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image canvas
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Create a GraphicsPath with FillMode set to Winding
                GraphicsPath path = new GraphicsPath(FillMode.Winding);

                // Build a figure containing overlapping shapes
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 200f)));
                figure.AddShape(new EllipseShape(new RectangleF(150f, 150f, 200f, 200f)));

                // Add the figure to the path
                path.AddFigure(figure);

                // Draw the outline of the path
                Pen pen = new Pen(Color.Black, 2);
                graphics.DrawPath(pen, path);

                // Fill the path to observe the effect of the Winding fill mode
                using (SolidBrush brush = new SolidBrush(Color.LightBlue))
                {
                    graphics.FillPath(brush, path);
                }

                // Save the image (bound to the output file)
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
 * 1. When a developer wants to generate a PNG image with overlapping rectangles and ellipses and needs to ensure the interior region is filled according to the Winding rule for accurate vector rendering.
 * 2. When creating printable graphics for reports where the fill behavior of intersecting shapes must follow the non‑zero winding number algorithm to avoid unwanted holes.
 * 3. When building a custom chart or diagram in a .NET application and the visual design requires consistent filling of complex paths across different file formats such as PNG.
 * 4. When testing the visual difference between EvenOdd and Winding fill modes in Aspose.Imaging to choose the correct mode for a logo that contains nested shapes.
 * 5. When automating image generation for a web service that outputs transparent PNG thumbnails and the developer needs to control how overlapping shapes are composited using the Winding fill mode.
 */