// HOW-TO: Rotate a Rectangle Path 45 Degrees and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 400;
            int height = 400;
            var pngOptions = new PngOptions();

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, width, height))
            {
                var graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                var path = new Aspose.Imaging.GraphicsPath();
                var figure = new Aspose.Imaging.Figure();

                var rect = new Aspose.Imaging.RectangleF(100, 100, 200, 200);
                var rectangleShape = new RectangleShape(rect);
                figure.AddShape(rectangleShape);

                path.AddFigure(figure);

                graphics.RotateTransform(45f);

                var pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black);
                graphics.DrawPath(pen, path);

                image.Save(outputPath);
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
 * 1. When you need to generate a PNG thumbnail with a rotated square for a UI icon.
 * 2. When creating a dynamic diagram where rectangles must be displayed at a 45‑degree angle using Aspose.Imaging in a C# web service.
 * 3. When preprocessing scanned documents to overlay rotated watermark shapes before saving them as PNG files.
 * 4. When building a game asset pipeline that requires programmatically rotating shape paths to align with design specifications.
 * 5. When automating report graphics that include rotated geometric figures for better visual emphasis in .NET applications.
 */
