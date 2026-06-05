using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputPath = @"c:\temp\input.bmp";
        string outputPath = @"c:\temp\output.bmp";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP options for creating a new image
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a new 500x500 image
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics object
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.Wheat);

                // Create a graphics path and a figure
                GraphicsPath graphicsPath = new GraphicsPath();
                Figure figure = new Figure();

                // Add a rectangle shape to the figure (x=10, y=10, width=300, height=300)
                figure.AddShape(new RectangleShape(new RectangleF(10f, 10f, 300f, 300f)));

                // Add the figure to the graphics path
                graphicsPath.AddFigure(figure);

                // Draw the path with a black pen of thickness 2
                graphics.DrawPath(new Pen(Color.Black, 2), graphicsPath);

                // Save the image to the output path
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
 * 1. When a developer needs to generate a 500×500 BMP thumbnail with a clearly defined rectangular region for a reporting dashboard, this code creates the image and draws the rectangle using Figure.AddShape.
 * 2. When a developer wants to programmatically add a border rectangle to a blank canvas to produce a printable label template in C#, the example shows how to use GraphicsPath and RectangleShape.
 * 3. When a developer must overlay a selectable rectangular area on a scanned bitmap image for a document‑annotation tool, the code demonstrates creating the rectangle shape and drawing it with a black pen.
 * 4. When a developer is building a custom watermark that consists of a simple rectangle on a BMP image, this snippet illustrates how to add the rectangle to a Figure and render it with Aspose.Imaging.
 * 5. When a developer needs to create a BMP placeholder image with a defined rectangle for unit‑test validation of graphics rendering pipelines, the example provides the exact steps to create, draw, and save the image.
 */