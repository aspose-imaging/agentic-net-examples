using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

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

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Create a Graphics instance for drawing
                Graphics graphics = new Graphics(image);

                // Create a GraphicsPath with a rectangle covering the whole image
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(0, 0, image.Width, image.Height)));
                path.AddFigure(figure);

                // Create a semi‑transparent red SolidBrush
                using (SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.Red))
                {
                    brush.Opacity = 0.5f; // 50% opacity
                    // Fill the path with the brush (overlay effect)
                    graphics.FillPath(brush, path);
                }

                // Save the modified image as PNG
                PngOptions pngOptions = new PngOptions();
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
 * 1. When a developer wants to add a semi‑transparent red overlay to a PNG image to highlight the entire picture, such as for a warning or emphasis in a web application.
 * 2. When creating a custom UI skin where a red tint is applied over a background image using Aspose.Imaging’s GraphicsPath and SolidBrush for consistent theming across Windows forms.
 * 3. When generating a batch of product photos that need a red translucent filter to indicate items on sale, the code can fill the whole image with a 50 % opacity red brush before saving as PNG.
 * 4. When building an automated report that marks regions of interest by overlaying a semi‑transparent red rectangle on screenshots, this snippet provides the exact C# steps with Aspose.Imaging.
 * 5. When implementing a simple image watermarking tool that applies a red translucent overlay to protect assets, the code demonstrates loading, drawing, and saving the modified image in .NET.
 */