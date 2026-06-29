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
            // Hardcoded output path
            string outputPath = @"c:\temp\output.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP options with a file create source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create image canvas (500x500)
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.Wheat);

                // Create a graphics path
                GraphicsPath graphicspath = new GraphicsPath();

                // Create a figure and add shapes
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(10f, 10f, 300f, 300f)));
                figure.AddShape(new EllipseShape(new RectangleF(50f, 50f, 300f, 300f)));
                figure.AddShape(new PieShape(new RectangleF(new PointF(250f, 250f), new SizeF(200f, 200f)), 0f, 45f));

                // Add the completed figure to the graphics path
                graphicspath.AddFigure(figure);

                // Draw the path onto the image
                graphics.DrawPath(new Pen(Color.Black, 2), graphicspath);

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
 * 1. When a developer needs to generate a 24‑bit BMP thumbnail that combines a rectangle, ellipse, and pie slice into a single vector path for consistent rendering.
 * 2. When an application must programmatically create a composite logo on a 500×500 canvas and save it as a BMP file for legacy Windows printing.
 * 3. When a CAD‑like tool requires merging multiple primitive shapes into one GraphicsPath to apply a single pen stroke before exporting the drawing as a bitmap.
 * 4. When a server‑side service generates custom watermarks composed of geometric figures and needs to add the whole figure to a path before drawing it onto an image.
 * 5. When an IoT device creates status icons by layering shapes into a Figure, adding it to a GraphicsPath, and saving the result as a BMP for low‑memory display.
 */