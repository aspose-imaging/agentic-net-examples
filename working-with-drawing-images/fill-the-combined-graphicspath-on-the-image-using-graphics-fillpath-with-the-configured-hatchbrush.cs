// HOW-TO: Fill Combined Rectangle and Ellipse with Hatch Brush in C# (Aspose.Imaging for .NET)
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
        // Hardcoded paths
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.png";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Initialize graphics for the image
                Graphics graphics = new Graphics(image);

                // Create a graphics path and a figure
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();

                // Add shapes to the figure
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 200f)));
                figure.AddShape(new EllipseShape(new RectangleF(100f, 100f, 200f, 200f)));

                // Add the figure to the path
                path.AddFigure(figure);

                // Configure a HatchBrush
                using (HatchBrush hatchBrush = new HatchBrush())
                {
                    hatchBrush.BackgroundColor = Color.Wheat;
                    hatchBrush.ForegroundColor = Color.Red;
                    hatchBrush.HatchStyle = HatchStyle.Horizontal; // Example hatch style
                    hatchBrush.Opacity = 0.5f; // 50% opacity

                    // Fill the combined path with the hatch brush
                    graphics.FillPath(hatchBrush, path);
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
 * 1. When you need to overlay a semi‑transparent red hatch pattern on specific shapes such as a rectangle and an ellipse inside a PNG image using Aspose.Imaging for .NET.
 * 2. When generating custom graphics for reports or UI elements where combined vector shapes must be filled with a patterned brush before saving as PNG.
 * 3. When creating watermark or decorative effects on existing images by programmatically filling complex paths with configurable hatch styles and opacity.
 * 4. When automating batch processing of images to apply consistent hatch‑filled shapes for branding or visual guidelines across multiple PNG files.
 * 5. When building a graphics editor feature that lets users draw multiple shapes and fill them with a selectable hatch brush, then export the result as a PNG.
 */
