using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output/output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                Graphics graphics = new Graphics(image);

                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(100f, 100f, 200f, 200f)));
                path.AddFigure(figure);

                graphics.RotateTransform(45f);

                graphics.DrawPath(new Pen(Color.Black, 2), path);

                PngOptions pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to rotate a rectangular logo by 45 degrees in a PNG file for a branding overlay using Aspose.Imaging’s Graphics.RotateTransform in C#.
 * 2. When a developer wants to generate a rotated thumbnail of a scanned document to match a specific page layout, applying a 45‑degree rotation to the image path before saving as PNG.
 * 3. When a developer must create a rotated UI icon (e.g., a compass needle) by drawing a rectangle shape, rotating it around its center, and exporting the result with Aspose.Imaging for .NET.
 * 4. When a developer is preparing product images for a catalog and needs to align product boxes at a 45‑degree angle to showcase perspective, using GraphicsPath and RotateTransform.
 * 5. When a developer is building an automated batch process that corrects the orientation of batch‑processed PNG graphics by rotating each image’s path 45 degrees around its center point.
 */