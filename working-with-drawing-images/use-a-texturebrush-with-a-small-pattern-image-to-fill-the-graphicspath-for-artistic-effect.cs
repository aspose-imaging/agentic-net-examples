// HOW-TO: Fill a Rectangle with a Repeating Pattern Using TextureBrush in C# (Aspose.Imaging for .NET)
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
        // Hardcoded input pattern and output image paths
        string patternPath = "pattern.png";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(patternPath))
        {
            Console.Error.WriteLine($"File not found: {patternPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        try
        {
            // Load the small pattern image to be used as a texture
            using (Image patternImage = Image.Load(patternPath))
            {
                // Create a PNG canvas bound to the output file
                Source outSource = new FileCreateSource(outputPath, false);
                PngOptions pngOptions = new PngOptions() { Source = outSource };
                using (Image canvas = Image.Create(pngOptions, 500, 500))
                {
                    // Initialize graphics for drawing
                    Graphics graphics = new Graphics(canvas);
                    graphics.Clear(Color.White);

                    // Build a graphics path (a rectangle in this case)
                    GraphicsPath path = new GraphicsPath();
                    Figure figure = new Figure();
                    figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 400f, 400f)));
                    path.AddFigure(figure);

                    // Create a texture brush from the pattern image
                    using (TextureBrush textureBrush = new TextureBrush(
                        patternImage,
                        new Rectangle(0, 0, patternImage.Width, patternImage.Height)))
                    {
                        // Fill the path with the texture brush
                        graphics.FillPath(textureBrush, path);
                    }

                    // Save the bound canvas image
                    canvas.Save();
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
 * 1. When you need to create a decorative background by tiling a small PNG pattern across a shape in a generated image.
 * 2. When you want to programmatically generate custom‑styled graphics such as logos or badges that use a texture fill instead of a solid color.
 * 3. When you are building a reporting tool that adds patterned watermarks or borders to images exported from PDFs.
 * 4. When you need to produce game assets where a repeating texture is applied to UI elements like buttons or panels.
 * 5. When you are automating the creation of marketing banners that require a consistent pattern fill inside geometric shapes.
 */
