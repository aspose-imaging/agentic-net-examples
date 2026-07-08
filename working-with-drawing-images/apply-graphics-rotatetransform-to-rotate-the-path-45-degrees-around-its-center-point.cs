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

            var pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(150, 150, 200, 200)));
                path.AddFigure(figure);

                float angle = 45f;
                graphics.RotateTransform(angle);

                graphics.DrawPath(new Pen(Color.Black, 2), path);
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
 * 1. When generating a thumbnail PNG that shows a rotated logo for a branding preview, a developer can use RotateTransform to turn the rectangular shape 45 degrees around its center.
 * 2. When creating a diagram that requires a diamond‑shaped marker, a developer can rotate a square path 45 degrees to produce the diamond in a PNG image.
 * 3. When building a custom QR code overlay where the background pattern must be tilted, a developer can apply RotateTransform to rotate the pattern path before drawing it.
 * 4. When designing a UI mock‑up that demonstrates a rotated button icon, a developer can rotate the rectangular shape around its center to visualize the effect.
 * 5. When producing a printable report that includes a rotated watermark, a developer can rotate the path 45 degrees to position the watermark correctly on the PNG canvas.
 */