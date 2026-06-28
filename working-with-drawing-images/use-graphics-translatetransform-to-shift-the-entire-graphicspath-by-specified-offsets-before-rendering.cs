using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                Graphics graphics = new Graphics(image);

                float offsetX = 50f;
                float offsetY = 30f;

                graphics.TranslateTransform(offsetX, offsetY);

                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(10f, 10f, 200f, 150f)));
                path.AddFigure(figure);

                graphics.DrawPath(new Pen(Color.Blue, 2), path);

                image.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to add a watermark or logo to an existing PNG image and wants to position it at a specific offset from the original content, they can use Graphics.TranslateTransform to shift the drawing path before rendering.
 * 2. When creating a thumbnail generator that adds a decorative border around JPEG or PNG photos, TranslateTransform can move the rectangle shape so the border aligns correctly with the image edges.
 * 3. When building a batch image annotation tool that places measurement boxes at consistent distances from the top‑left corner of each raster image, the code translates the GraphicsPath to the required X and Y offsets before drawing.
 * 4. When implementing a custom UI overlay for scanned documents where a blue rectangle highlights a region of interest, developers can offset the rectangle using TranslateTransform to match the document’s margin settings.
 * 5. When developing a report‑generation system that merges multiple raster images into a single PNG and needs to shift each graphic element to avoid overlap, TranslateTransform provides the precise X/Y shift before drawing the path.
 */