using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"input.png";
            string outputPath = @"output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
            {
                PngOptions pngOptions = new PngOptions();
                pngOptions.Source = new FileCreateSource(outputPath, false);

                using (Image canvas = Image.Create(pngOptions, sourceImage.Width, sourceImage.Height))
                {
                    Graphics graphics = new Graphics(canvas);
                    graphics.Clear(Color.White);

                    GraphicsPath path = new GraphicsPath();
                    Figure figure = new Figure();
                    figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 200f)));
                    path.AddFigure(figure);

                    graphics.TranslateTransform(100f, 50f);
                    graphics.DrawPath(new Pen(Color.Blue, 3), path);

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
 * 1. When a developer needs to place a rectangular watermark at a specific offset on a PNG image by translating the GraphicsPath before rendering with Aspose.Imaging for .NET.
 * 2. When a developer wants to reposition a logo or badge on a raster canvas by applying Graphics.TranslateTransform to shift the shape’s coordinates prior to drawing.
 * 3. When a developer generates a PNG report page and must align diagram elements with custom margins by translating the entire GraphicsPath.
 * 4. When a developer creates a thumbnail preview and uses a translation transform to center a rectangle shape relative to the image dimensions before saving.
 * 5. When a developer simulates drag‑and‑drop positioning of UI components by shifting a GraphicsPath with specified X/Y offsets and exporting the result as a PNG file.
 */