using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded output path
        string outputPath = @"c:\temp\GraphicsPathBounds.png";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up PNG options with a file create source
        var pngOptions = new Aspose.Imaging.ImageOptions.PngOptions();
        pngOptions.Source = new Aspose.Imaging.Sources.FileCreateSource(outputPath, false);

        // Create a new image canvas
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, 500, 500))
        {
            // Initialize graphics for drawing
            var graphics = new Aspose.Imaging.Graphics(image);
            graphics.Clear(Aspose.Imaging.Color.White);

            // Build a graphics path with a rectangle shape
            var path = new Aspose.Imaging.GraphicsPath();
            var figure = new Aspose.Imaging.Figure();
            figure.AddShape(new Aspose.Imaging.Shapes.RectangleShape(new Aspose.Imaging.RectangleF(100f, 80f, 200f, 150f)));
            path.AddFigure(figure);

            // Retrieve the bounding rectangle of the path
            var bounds = path.GetBounds(new Aspose.Imaging.Matrix());

            // Draw the bounding rectangle in red to visualize it
            graphics.DrawRectangle(
                new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 2),
                (int)bounds.X,
                (int)bounds.Y,
                (int)bounds.Width,
                (int)bounds.Height);

            // Save the image
            image.Save();
        }
    }
}