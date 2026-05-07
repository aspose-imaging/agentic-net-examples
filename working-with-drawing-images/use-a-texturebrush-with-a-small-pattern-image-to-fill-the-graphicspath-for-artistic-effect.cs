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
        try
        {
            // Hardcoded input pattern image and output image paths
            string patternPath = "pattern.png";
            string outputPath = "output.png";

            // Verify pattern image exists
            if (!File.Exists(patternPath))
            {
                Console.Error.WriteLine($"File not found: {patternPath}");
                return;
            }

            // Load the small pattern image
            using (Image patternImage = Image.Load(patternPath))
            {
                // Create a blank canvas image (PNG)
                int canvasWidth = 800;
                int canvasHeight = 600;
                PngOptions pngOptions = new PngOptions();

                using (Image canvas = Image.Create(pngOptions, canvasWidth, canvasHeight))
                {
                    // Initialize graphics for the canvas
                    Graphics graphics = new Graphics(canvas);
                    graphics.Clear(Color.White);

                    // Create a TextureBrush using the pattern image
                    using (TextureBrush textureBrush = new TextureBrush(
                        patternImage,
                        new Rectangle(0, 0, patternImage.Width, patternImage.Height)))
                    {
                        // Build a GraphicsPath with a single rectangular figure
                        GraphicsPath path = new GraphicsPath();
                        Figure figure = new Figure();
                        figure.AddShape(new RectangleShape(new RectangleF(100f, 100f, 600f, 400f)));
                        path.AddFigure(figure);

                        // Fill the path with the texture brush
                        graphics.FillPath(textureBrush, path);

                        // Optional: draw the outline of the path
                        Pen outlinePen = new Pen(Color.Black, 2);
                        graphics.DrawPath(outlinePen, path);
                    }

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the resulting image
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