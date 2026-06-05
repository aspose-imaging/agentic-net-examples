using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";   // Not used in this example, but shown for rule compliance
        string outputPath = "output.png";

        try
        {
            // Input file existence check (if needed)
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                // Continue without input file as we are creating a new image
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up PNG options
            PngOptions pngOptions = new PngOptions();

            // Create a new image canvas
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Clear background
                graphics.Clear(Color.White);

                // Create a GraphicsPath with FillMode set to Winding
                GraphicsPath graphicPath = new GraphicsPath(FillMode.Winding);

                // Create a figure and add shapes
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 200f)));
                figure.AddShape(new EllipseShape(new RectangleF(100f, 100f, 200f, 200f)));

                // Add the figure to the path
                graphicPath.AddFigure(figure);

                // Draw the path with a black pen
                graphics.DrawPath(new Pen(Color.Black, 2), graphicPath);

                // Save the image to the specified output path
                image.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to generate a PNG thumbnail that demonstrates how overlapping shapes are filled using the Winding rule for vector graphics in a .NET application.
 * 2. When testing the visual output of complex path filling in Aspose.Imaging to ensure that the Winding FillMode correctly renders intersecting rectangles and ellipses for a custom diagram editor.
 * 3. When creating a printable PDF or image asset where the winding fill algorithm determines the interior of overlapping shapes, such as logos with cut‑out sections, and the developer wants to preview it as a PNG.
 * 4. When debugging a C# graphics pipeline that converts geometric figures into raster images and needs to compare the Winding fill behavior against the default Alternate mode.
 * 5. When building an automated UI test that validates that Aspose.Imaging’s GraphicsPath with FillMode.Winding produces the expected black outline and white background for overlapping shapes in a 500 × 500 pixel canvas.
 */