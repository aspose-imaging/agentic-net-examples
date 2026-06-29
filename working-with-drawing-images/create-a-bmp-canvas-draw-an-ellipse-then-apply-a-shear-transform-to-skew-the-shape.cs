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
            string outputPath = "output/output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create BMP options with file source
            Source source = new FileCreateSource(outputPath, false);
            BmpOptions bmpOptions = new BmpOptions() { Source = source, BitsPerPixel = 24 };

            // Create BMP canvas
            using (Image canvas = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.Wheat);

                // Apply shear transform (shear X by 0.5)
                Matrix shear = new Matrix(1, 0, 0.5f, 1, 0, 0);
                graphics.MultiplyTransform(shear);

                // Create path with an ellipse shape
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(100, 100, 300, 200)));
                path.AddFigure(figure);

                // Draw the transformed ellipse
                graphics.DrawPath(new Pen(Color.Black, 2), path);

                // Save the image (bound to source)
                canvas.Save();
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
 * 1. When a developer needs to generate a 24‑bit BMP image with a custom‑skewed ellipse for a printable report or legacy system that only accepts BMP files.
 * 2. When creating a placeholder graphic for a UI mock‑up where the ellipse must be sheared to illustrate perspective distortion.
 * 3. When preprocessing graphics for a game asset pipeline that requires BMP textures with transformed shapes for retro‑style sprites.
 * 4. When automating the production of diagram elements, such as a slanted oval badge, that will be embedded in a Word document via BMP.
 * 5. When testing the accuracy of Aspose.Imaging’s shear matrix and drawing APIs by programmatically applying a 0.5 X‑axis shear to an ellipse and saving the result.
 */