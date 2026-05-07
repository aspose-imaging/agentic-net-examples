using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path (hard‑coded)
            string outputPath = @"c:\temp\output.png";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create PNG options with a file source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a blank image canvas
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // ----- Original GraphicsPath -----
                GraphicsPath originalPath = new GraphicsPath();
                Figure originalFigure = new Figure();
                // Add a rectangle shape to the original figure
                originalFigure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 200f)));
                originalPath.AddFigure(originalFigure);

                // Draw the original path (black pen)
                graphics.DrawPath(new Pen(Color.Black, 2), originalPath);

                // ----- Clone and modify -----
                GraphicsPath clonedPath = originalPath.DeepClone();

                // Add an additional ellipse shape to the cloned path
                Figure extraFigure = new Figure();
                extraFigure.AddShape(new EllipseShape(new RectangleF(150f, 150f, 100f, 100f)));
                clonedPath.AddFigure(extraFigure);

                // Draw the cloned (and modified) path (red pen)
                graphics.DrawPath(new Pen(Color.Red, 2), clonedPath);

                // Save the image (the file is already bound to the source)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}