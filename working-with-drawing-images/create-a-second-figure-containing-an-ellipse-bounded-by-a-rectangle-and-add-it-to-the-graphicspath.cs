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
        // Hardcoded input and output paths
        string inputPath = "input.bmp"; // Not used in this example
        string outputPath = "output.bmp";

        // Input path validation (if any input is used)
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP options with a bound file source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create the image canvas
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.Wheat);

                // Create a graphics path to hold figures
                GraphicsPath graphicspath = new GraphicsPath();

                // First figure (example rectangle)
                Figure figure1 = new Figure();
                figure1.AddShape(new RectangleShape(new RectangleF(10f, 10f, 300f, 300f)));
                graphicspath.AddFigure(figure1);

                // Second figure containing an ellipse bounded by a rectangle
                Figure figure2 = new Figure();
                figure2.AddShape(new EllipseShape(new RectangleF(50f, 50f, 300f, 300f)));
                graphicspath.AddFigure(figure2);

                // Render the path onto the image
                graphics.DrawPath(new Pen(Color.Black, 2), graphicspath);

                // Save the image (output is already bound via FileCreateSource)
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
 * 1. When a developer needs to generate a BMP report thumbnail that highlights a circular region inside a rectangular boundary for a medical imaging dashboard.
 * 2. When an automated document‑generation system must overlay an ellipse inside a rectangle onto a 500×500 bitmap to indicate a selection area in a PDF‑to‑image conversion workflow.
 * 3. When a game‑engine tool requires drawing a stylized button shape—an ellipse bounded by a rectangle—directly onto a bitmap using Aspose.Imaging for .NET.
 * 4. When a data‑visualization library wants to create a custom legend icon that consists of an ellipse inside a rectangle on a BMP canvas for export to legacy Windows applications.
 * 5. When a batch‑processing script needs to add a diagnostic overlay (ellipse within a rectangle) to a set of BMP screenshots for quality‑control inspection in a manufacturing line.
 */