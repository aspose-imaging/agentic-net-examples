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
        try
        {
            string outputPath = "output.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                RectangleF rect = new RectangleF(150f, 150f, 200f, 200f);
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(rect));
                GraphicsPath path = new GraphicsPath();
                path.AddFigure(figure);

                Pen pen = new Pen(Color.Black, 2);
                graphics.DrawPath(pen, path);

                image.Save();
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
 * 1. When a developer needs to generate a PNG badge with a logo that is rotated 45 degrees using Graphics.RotateTransform to create a tilted square for branding.
 * 2. When creating a technical illustration where a rectangular annotation must be rotated 45 degrees around its center with Graphics.RotateTransform to match a slanted axis.
 * 3. When producing a game UI asset such as a compass needle that requires a 45‑degree rotation of a rectangle via Graphics.RotateTransform and saving the result as a transparent PNG.
 * 4. When automating printable label preparation where a rectangle is rotated 45 degrees around its center using Graphics.RotateTransform to fit a diagonal layout on the sheet.
 * 5. When building a data‑visualization report that overlays a rotated rectangle on a chart, applying Graphics.RotateTransform to the GraphicsPath and exporting the image as a high‑resolution PNG.
 */