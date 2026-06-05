using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (FileStream stream = new FileStream(outputPath, FileMode.Create))
            {
                var pngOptions = new PngOptions();
                pngOptions.Source = new StreamSource(stream);

                using (Image image = Image.Create(pngOptions, 500, 500))
                {
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Color.White);

                    GraphicsPath graphicsPath = new GraphicsPath();
                    Figure figure = new Figure();

                    PointF[] vertices = new PointF[]
                    {
                        new PointF(100f, 100f),
                        new PointF(200f, 80f),
                        new PointF(250f, 150f),
                        new PointF(180f, 200f),
                        new PointF(120f, 180f)
                    };

                    PolygonShape polygon = new PolygonShape(vertices, true);
                    figure.AddShape(polygon);
                    graphicsPath.AddFigure(figure);

                    graphics.DrawPath(new Pen(Color.Black, 2), graphicsPath);
                    image.Save();
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
 * 1. When a developer needs to generate a custom PNG badge with a five‑pointed polygon logo for branding or UI icons.
 * 2. When an application must programmatically draw a closed polygon overlay on a map image to highlight a region of interest.
 * 3. When a reporting tool requires embedding a simple geometric shape into a PDF‑converted PNG chart for visual emphasis.
 * 4. When an e‑learning platform creates diagrammatic illustrations, such as a pentagon representing a process step, directly in code without using external design tools.
 * 5. When a game engine generates procedural terrain textures and needs to render a polygonal mask onto a 500×500 PNG sprite at runtime.
 */