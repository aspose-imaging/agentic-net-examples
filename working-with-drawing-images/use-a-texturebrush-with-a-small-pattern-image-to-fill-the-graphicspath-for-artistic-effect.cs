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
        string patternPath = "pattern.png";
        string outputPath = "output.png";

        try
        {
            // Verify pattern image exists
            if (!File.Exists(patternPath))
            {
                Console.Error.WriteLine($"File not found: {patternPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the small pattern image to be used as a texture
            using (Image patternImage = Image.Load(patternPath))
            {
                // Define canvas size
                int canvasWidth = 500;
                int canvasHeight = 500;

                // Create a new PNG image canvas
                PngOptions pngOptions = new PngOptions();
                using (Image canvas = Image.Create(pngOptions, canvasWidth, canvasHeight))
                {
                    // Initialize graphics for drawing
                    Graphics graphics = new Graphics(canvas);
                    graphics.Clear(Color.White);

                    // Build a graphics path (a single rectangle covering the canvas)
                    GraphicsPath path = new GraphicsPath();
                    Figure figure = new Figure();
                    figure.AddShape(new RectangleShape(new RectangleF(0f, 0f, canvasWidth, canvasHeight)));
                    path.AddFigure(figure);

                    // Create a texture brush using the pattern image
                    // The destination rectangle defines the size of each tile
                    using (TextureBrush textureBrush = new TextureBrush(patternImage, new Rectangle(0, 0, 50, 50)))
                    {
                        // Fill the path with the texture brush
                        graphics.FillPath(textureBrush, path);
                    }

                    // Save the resulting image to the output file
                    canvas.Save(outputPath, pngOptions);
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
 * 1. When a developer wants to generate a printable PNG poster with a repeated decorative pattern background, they can load a small pattern.png and use a TextureBrush to fill a rectangle GraphicsPath.
 * 2. When creating custom UI skins for a Windows Forms application, a developer can tile a tiny PNG texture across a control’s background by applying a TextureBrush to a GraphicsPath.
 * 3. When producing branded marketing assets that require a company logo or watermark repeated across a large canvas, the code can tile the logo image using a TextureBrush in Aspose.Imaging.
 * 4. When generating procedural game art such as tiled floor or wall textures for a 2‑D game, a developer can fill a GraphicsPath with a repeating pattern image to create seamless backgrounds.
 * 5. When automating the creation of patterned PDF page backgrounds or email newsletters, a developer can use the TextureBrush to fill a rectangular path and then export the result as a high‑resolution PNG.
 */