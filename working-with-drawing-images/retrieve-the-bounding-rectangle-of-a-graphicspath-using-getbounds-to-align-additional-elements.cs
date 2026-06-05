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
            // Output file path
            string outputPath = @"c:\temp\output.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP options with file source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create image canvas
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.Wheat);

                // Build a graphics path with a rectangle shape
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(100f, 100f, 200f, 150f)));
                path.AddFigure(figure);

                // Retrieve bounding rectangle of the path
                RectangleF bounds = path.GetBounds(new Matrix());

                // Draw the bounding rectangle
                graphics.DrawRectangle(new Pen(Color.Red, 2),
                    (int)bounds.X, (int)bounds.Y,
                    (int)bounds.Width, (int)bounds.Height);

                // Draw the original path
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
 * 1. When creating a 500 × 500 BMP image and need to draw a red bounding rectangle around a custom GraphicsPath to visually highlight the shape’s limits.
 * 2. When placing text annotations or icons next to a vector rectangle in an Aspose.Imaging canvas by using the RectangleF returned from GraphicsPath.GetBounds.
 * 3. When determining the exact occupied area of a GraphicsPath so you can crop, pad, or resize the image before saving it as a 24‑bit BMP file.
 * 4. When aligning additional drawing elements such as watermarks, shadows, or highlights relative to the bounding box of a user‑defined shape using C# matrix transformations.
 * 5. When debugging complex vector drawings in .NET by rendering the calculated bounds with a red Pen to verify alignment and layout.
 */