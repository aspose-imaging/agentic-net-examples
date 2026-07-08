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
        // Hardcoded output path
        string outputPath = @"c:\temp\output.png";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Set up PNG options with a file source
            var pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create image canvas
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.Wheat);

                // Create a graphics path and a figure
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();

                // Add a rectangle shape to the figure (x, y, width, height)
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));

                // Add figure to the path and draw it
                path.AddFigure(figure);
                graphics.DrawPath(new Pen(Color.Black, 2), path);

                // Save the image (output file is already bound to the source)
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
 * 1. When generating a PNG report thumbnail that highlights a specific region, a developer can use Figure.AddShape with a RectangleShape to draw a black‑bordered rectangle over the area of interest.
 * 2. When creating a custom watermark overlay for product images, the code can add a rectangle shape to a Figure to define the watermark’s bounding box before rendering it onto the 500×500 canvas.
 * 3. When building a simple diagram editor that lets users select and outline objects, the rectangle shape added via Figure.AddShape provides the visual selection rectangle on the image.
 * 4. When automating the production of printable labels that require a bordered field for a QR code, developers can use the rectangle shape to reserve and outline the exact coordinates on a PNG file.
 * 5. When developing a testing utility that verifies image processing pipelines by drawing known geometric shapes, adding a rectangle shape to a Figure ensures a predictable shape is rendered for comparison.
 */