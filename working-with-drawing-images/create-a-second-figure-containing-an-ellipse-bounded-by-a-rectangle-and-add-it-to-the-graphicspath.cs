// HOW-TO: Create BMP With Rectangle And Bounded Ellipse Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
        // Hardcoded input and output paths
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

            // Create BMP image options with a file create source
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a new image
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics object
                Graphics graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.Wheat);

                // Create a graphics path
                GraphicsPath graphicPath = new GraphicsPath();

                // First figure (example rectangle)
                Figure figure1 = new Figure();
                figure1.AddShape(new RectangleShape(new RectangleF(10f, 10f, 300f, 300f)));
                graphicPath.AddFigure(figure1);

                // Second figure containing an ellipse bounded by a rectangle
                Figure figure2 = new Figure();
                // Ellipse bounded by rectangle (50,50,300,300)
                figure2.AddShape(new EllipseShape(new RectangleF(50f, 50f, 300f, 300f)));
                graphicPath.AddFigure(figure2);

                // Draw the path with a black pen
                graphics.DrawPath(new Pen(Aspose.Imaging.Color.Black, 2), graphicPath);

                // Save the image
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
 * 1. When you need to generate a blank BMP file and programmatically draw basic shapes such as rectangles and ellipses for a diagram or placeholder image.
 * 2. When you want to combine multiple figures into a single GraphicsPath to produce a composite vector graphic in a C# application.
 * 3. When you must save the output image directly to disk with a specific size, 24‑bit color depth, and background color without using intermediate streams.
 * 4. When you are building a server‑side service that creates annotated bitmap thumbnails with geometric overlays like rectangles and bounded ellipses.
 * 5. When you need to verify an input bitmap exists, create the output directory, and draw vector shapes using Aspose.Imaging for automated image‑processing tests.
 */
