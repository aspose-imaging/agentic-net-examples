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
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                Graphics graphics = new Graphics(image);

                // First figure with rectangle and ellipse
                Figure figure1 = new Figure();
                figure1.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 200f)));
                figure1.AddShape(new EllipseShape(new RectangleF(100f, 100f, 150f, 150f)));

                // Second figure with a pie shape
                Figure figure2 = new Figure();
                figure2.AddShape(new PieShape(new RectangleF(150f, 150f, 200f, 200f), 0f, 90f));

                // Combine figures into a single GraphicsPath
                GraphicsPath combinedPath = new GraphicsPath();
                combinedPath.AddFigures(new[] { figure1, figure2 });

                // Configure HatchBrush
                using (HatchBrush hatchBrush = new HatchBrush())
                {
                    hatchBrush.BackgroundColor = Color.White;
                    hatchBrush.ForegroundColor = Color.Blue;
                    // Optional: set hatch style if needed
                    // hatchBrush.HatchStyle = Aspose.Imaging.Brushes.HatchStyle.Cross;

                    // Fill the combined path
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
 * 1. When a developer wants to overlay a patterned watermark composed of multiple shapes (rectangle, ellipse, pie) onto a PNG or JPEG image for branding purposes.
 * 2. When generating custom map annotations where combined geometric regions need to be filled with a hatch pattern to distinguish zones on a raster map.
 * 3. When creating printable reports that require shaded diagram elements, such as highlighted sections in engineering schematics, using a HatchBrush on a combined GraphicsPath.
 * 4. When building a UI that dynamically renders complex icons with cross‑hatched fills, allowing the shapes to be defined programmatically and saved as PNG for web use.
 * 5. When automating the preparation of marketing assets that need a blue‑on‑white hatch fill applied to multiple overlapping shapes to achieve a consistent visual style across images.
 */