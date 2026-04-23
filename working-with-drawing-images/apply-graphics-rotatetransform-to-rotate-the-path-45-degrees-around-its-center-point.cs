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
        // Output file path
        string outputPath = "Output\\rotated_path.png";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up PNG options with a file create source
        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        // Create a 500x500 image canvas
        using (Image image = Image.Create(pngOptions, 500, 500))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // Build a graphics path with a rectangle and an ellipse
            GraphicsPath path = new GraphicsPath();
            Figure figure = new Figure();
            figure.AddShape(new RectangleShape(new RectangleF(100f, 100f, 200f, 200f)));
            figure.AddShape(new EllipseShape(new RectangleF(150f, 150f, 200f, 200f)));
            path.AddFigure(figure);

            // Determine the center of the path's bounds
            var bounds = path.Bounds;
            float centerX = bounds.X + bounds.Width / 2f;
            float centerY = bounds.Y + bounds.Height / 2f;

            // Rotate the path 45 degrees around its center
            graphics.TranslateTransform(-centerX, -centerY);
            graphics.RotateTransform(45);
            graphics.TranslateTransform(centerX, centerY);

            // Draw the rotated path
            graphics.DrawPath(new Pen(Color.Black, 2), path);

            // Save the image (output file is already bound)
            image.Save();
        }
    }
}