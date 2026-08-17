// HOW-TO: Create PNG Image With Anti-Aliased Graphics Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\output.png";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up PNG options with a stream source
            PngOptions pngOptions = new PngOptions();
            using (FileStream stream = new FileStream(outputPath, FileMode.Create))
            {
                pngOptions.Source = new StreamSource(stream);

                // Create a new 500x500 image
                using (Image image = Image.Create(pngOptions, 500, 500))
                {
                    // Initialize Graphics from the created image
                    Graphics graphics = new Graphics(image);

                    // Enable anti-aliasing for smoother edges
                    graphics.SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias;

                    // Clear the background
                    graphics.Clear(Color.Wheat);

                    // Build a simple rectangle path
                    GraphicsPath path = new GraphicsPath();
                    Figure figure = new Figure();
                    figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 400f, 400f)));
                    path.AddFigure(figure);

                    // Draw the path with a black pen
                    graphics.DrawPath(new Pen(Color.Black, 2), path);

                    // Save the image to the specified output path
                    image.Save(outputPath);
                }
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
 * 1. When you need to generate a high‑quality PNG thumbnail with smooth vector edges for a web dashboard using C#.
 * 2. When you want to programmatically draw anti‑aliased shapes, such as rectangles, onto a blank image for dynamic report graphics.
 * 3. When you must create a PNG file with a custom background color and precise dimensions without using GDI+.
 * 4. When you are building an automated image‑processing pipeline that requires consistent smoothing settings across all generated graphics.
 * 5. When you need to save a drawing to a stream‑based PNG output while ensuring the edges are rendered without jagged artifacts.
 */
