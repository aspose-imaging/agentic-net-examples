using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Define output path
        string outputPath = @"C:\Temp\GraphicsPathClone.png";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up PNG options with a file create source
        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        // Create a new image canvas
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, 500, 500))
        {
            // Initialize graphics for drawing
            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
            graphics.Clear(Aspose.Imaging.Color.White);

            // Create the original GraphicsPath with a rectangle figure
            Aspose.Imaging.GraphicsPath originalPath = new Aspose.Imaging.GraphicsPath();
            Aspose.Imaging.Figure rectFigure = new Aspose.Imaging.Figure();
            rectFigure.AddShape(new Aspose.Imaging.Shapes.RectangleShape(
                new Aspose.Imaging.RectangleF(50f, 50f, 200f, 200f)));
            originalPath.AddFigure(rectFigure);

            // Clone the original path
            Aspose.Imaging.GraphicsPath clonedPath = originalPath.DeepClone();

            // Modify the cloned path by adding an ellipse figure
            Aspose.Imaging.Figure ellipseFigure = new Aspose.Imaging.Figure();
            ellipseFigure.AddShape(new Aspose.Imaging.Shapes.EllipseShape(
                new Aspose.Imaging.RectangleF(150f, 150f, 200f, 200f)));
            clonedPath.AddFigure(ellipseFigure);

            // Draw the original path in black
            graphics.DrawPath(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2), originalPath);

            // Draw the cloned (modified) path in red
            graphics.DrawPath(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 2), clonedPath);

            // Save the image
            image.Save();
        }
    }
}