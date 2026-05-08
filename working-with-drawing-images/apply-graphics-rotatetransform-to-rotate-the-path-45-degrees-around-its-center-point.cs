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
            // Output file path (hardcoded)
            string outputPath = "output.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Create PNG options with a file source bound to the output path
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 500x500 image
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize Graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Rotate the graphics 45 degrees (around origin)
                graphics.RotateTransform(45f, MatrixOrder.Prepend);

                // Build a simple path (a rectangle)
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(100f, 100f, 200f, 200f)));
                path.AddFigure(figure);

                // Draw the path with a black pen
                Pen pen = new Pen(Color.Black, 2);
                graphics.DrawPath(pen, path);

                // Save the image (already bound to the output file)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}