using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        string inputPatternPath = "pattern.png";
        string outputPath = "output.png";

        if (!File.Exists(inputPatternPath))
        {
            Console.Error.WriteLine($"File not found: {inputPatternPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Aspose.Imaging.RasterImage pattern = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPatternPath))
            {
                FileCreateSource outSource = new FileCreateSource(outputPath, false);
                PngOptions pngOptions = new PngOptions() { Source = outSource };
                using (Aspose.Imaging.RasterImage canvas = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Create(pngOptions, 800, 600))
                {
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvas);
                    graphics.Clear(Aspose.Imaging.Color.White);

                    Aspose.Imaging.GraphicsPath path = new Aspose.Imaging.GraphicsPath();
                    Aspose.Imaging.Figure figure = new Aspose.Imaging.Figure();
                    figure.AddShape(new RectangleShape(new Aspose.Imaging.RectangleF(0f, 0f, canvas.Width, canvas.Height)));
                    path.AddFigure(figure);

                    using (TextureBrush textureBrush = new TextureBrush(pattern, new Aspose.Imaging.Rectangle(0, 0, pattern.Width, pattern.Height)))
                    {
                        graphics.FillPath(textureBrush, path);
                    }

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
 * 1. When creating a custom background for a PDF report or web banner, a developer can use a PNG pattern image with a TextureBrush to fill a rectangular GraphicsPath and generate a seamless tiled texture.
 * 2. When generating printable product labels that require a decorative repeatable motif, a C# application can load a small pattern file and apply it with TextureBrush to fill the label’s shape.
 * 3. When building a game UI overlay where a panel needs a stylized fabric or wood grain look, developers can tile a texture onto a GraphicsPath using Aspose.Imaging’s TextureBrush for fast raster rendering.
 * 4. When producing marketing flyers that need a consistent patterned border around images, a developer can fill a path defined by a rectangle with a texture brush based on a PNG pattern.
 * 5. When automating the creation of custom icons or avatars that incorporate a repeating pattern as the fill, the code can load the pattern, create a texture brush, and fill the shape to output a high‑resolution PNG.
 */