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
            // Hardcoded input pattern image and output image paths
            string patternPath = "pattern/pattern.png";
            string outputPath = "output/output.png";

            // Verify input file exists
            if (!File.Exists(patternPath))
            {
                Console.Error.WriteLine($"File not found: {patternPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the small pattern image to be used as a texture
            using (RasterImage patternImage = (RasterImage)Image.Load(patternPath))
            {
                // Create a PNG canvas bound to the output file
                Source outSource = new FileCreateSource(outputPath, false);
                PngOptions pngOptions = new PngOptions() { Source = outSource };
                using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, 500, 500))
                {
                    // Initialize graphics for drawing
                    Graphics graphics = new Graphics(canvas);
                    graphics.Clear(Color.White);

                    // Build a rectangular GraphicsPath
                    GraphicsPath path = new GraphicsPath();
                    Figure figure = new Figure();
                    figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 400f, 400f)));
                    path.AddFigure(figure);

                    // Create a TextureBrush using the pattern image
                    using (TextureBrush textureBrush = new TextureBrush(patternImage, new Rectangle(0, 0, patternImage.Width, patternImage.Height)))
                    {
                        // Fill the path with the texture brush
                        graphics.FillPath(textureBrush, path);
                    }

                    // Save the bound canvas (no path needed)
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
 * 1. When a developer wants to generate a PNG thumbnail with a custom patterned background by filling a rectangular GraphicsPath using a TextureBrush created from a small PNG pattern image.
 * 2. When an application needs to render scalable vector‑like shapes (e.g., rectangles) with a repeating texture for UI elements, leveraging Aspose.Imaging’s Graphics and TextureBrush classes in C#.
 * 3. When a reporting tool must embed a decorative tiled watermark inside a chart area, using a raster pattern image as a texture to fill the GraphicsPath before saving the result as a PNG file.
 * 4. When a game‑oriented editor requires procedural generation of patterned tiles for level maps, employing a TextureBrush to repeat a small pattern across a larger canvas created with RasterImage.
 * 5. When a web service produces custom‑styled QR codes or badges that need a patterned fill instead of a solid color, the code demonstrates how to apply a TextureBrush to a shape and export the final image as PNG.
 */