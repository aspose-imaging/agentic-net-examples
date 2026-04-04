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
        // Output file path (hard‑coded)
        string outputPath = @"C:\temp\output_winding.png";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up PNG options with a FileCreateSource bound to the output file
        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        // Create a new image canvas
        using (Image image = Image.Create(pngOptions, 500, 500))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // Create a GraphicsPath with FillMode set to Winding
            GraphicsPath path = new GraphicsPath(FillMode.Winding);

            // Build a figure containing a rectangle and an overlapping ellipse
            Figure figure = new Figure();
            figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 200f)));
            figure.AddShape(new EllipseShape(new RectangleF(150f, 150f, 200f, 200f)));

            // Add the figure to the path
            path.AddFigure(figure);

            // Draw the path using a blue pen
            graphics.DrawPath(new Pen(Color.Blue, 2), path);

            // Save the image (output file is already bound to the source)
            image.Save();
        }
    }
}