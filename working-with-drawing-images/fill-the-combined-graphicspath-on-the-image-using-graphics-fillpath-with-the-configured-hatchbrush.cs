using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path
            string outputPath = "output.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Set up PNG options with a file create source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image canvas
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // First figure with a rectangle shape
                Figure figure1 = new Figure();
                figure1.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 200f)));

                // Second figure with an ellipse shape
                Figure figure2 = new Figure();
                figure2.AddShape(new EllipseShape(new RectangleF(150f, 150f, 200f, 200f)));

                // Combine figures into a single graphics path
                GraphicsPath combinedPath = new GraphicsPath();
                combinedPath.AddFigures(new[] { figure1, figure2 });

                // Configure a hatch brush
                using (HatchBrush hatchBrush = new HatchBrush())
                {
                    hatchBrush.ForegroundColor = Color.Blue;
                    hatchBrush.BackgroundColor = Color.Yellow;
                    hatchBrush.HatchStyle = HatchStyle.Horizontal;

                    // Fill the combined path with the hatch brush
                    graphics.FillPath(hatchBrush, combinedPath);
                }

                // Save the image (file is already bound to the output path)
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
 * 1. When a developer wants to generate a PNG badge that combines a rectangular logo and an elliptical background with a blue‑on‑yellow hatch pattern for branding assets.
 * 2. When creating printable shipping labels in C# where overlapping shapes need to be filled with a hatch brush to indicate hazardous material zones.
 * 3. When building a web service that returns dynamically generated PNG icons with combined geometric shapes for UI elements, using Aspose.Imaging’s GraphicsPath and FillPath.
 * 4. When producing technical diagrams in a desktop application where a rectangle and an ellipse must be merged and filled with a horizontal hatch to highlight a specific region.
 * 5. When automating the creation of patterned background textures for game assets, combining multiple shapes into a single path and filling them with a configurable HatchBrush in .NET.
 */