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
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.png";

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
                // Initialize graphics for the image
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Create a combined GraphicsPath
                GraphicsPath combinedPath = new GraphicsPath();

                // First figure: rectangle
                Figure rectFigure = new Figure();
                rectFigure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));
                combinedPath.AddFigure(rectFigure);

                // Second figure: ellipse
                Figure ellipseFigure = new Figure();
                ellipseFigure.AddShape(new EllipseShape(new RectangleF(150f, 120f, 200f, 150f)));
                combinedPath.AddFigure(ellipseFigure);

                // Configure HatchBrush
                using (HatchBrush hatchBrush = new HatchBrush())
                {
                    hatchBrush.BackgroundColor = Color.LightGray;
                    hatchBrush.ForegroundColor = Color.Blue;

                    // Fill the combined path with the hatch brush
                    graphics.FillPath(hatchBrush, combinedPath);
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
 * 1. When a developer wants to generate a PNG badge that combines a rectangular background and an elliptical logo, filled with a blue‑on‑light‑gray hatch pattern using Aspose.Imaging’s GraphicsPath and HatchBrush.
 * 2. When creating printable PDF or image reports where overlapping shapes (e.g., a highlighted area and a call‑out ellipse) need a consistent textured fill to improve visual distinction.
 * 3. When building a custom map overlay in a C# application that shades intersecting zones with a hatch brush to indicate restricted regions on a raster image.
 * 4. When designing a UI asset such as a button or icon where a rectangle and an ellipse are merged into a single path and filled with a patterned brush for a retro or technical aesthetic.
 * 5. When automating the generation of promotional flyers that require layered geometric shapes filled with a specific color hatch to meet branding guidelines, saving the result as a high‑resolution PNG.
 */