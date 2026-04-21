using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"c:\temp\output.png";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up PNG options with a file create source
        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        // Create a new image canvas
        using (Image image = Image.Create(pngOptions, 500, 500))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Aspose.Imaging.Color.Wheat);

            // Create a graphics path and a figure
            GraphicsPath graphicspath = new GraphicsPath();
            Figure figure = new Figure();

            // Add initial shapes to the figure
            figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));
            figure.AddShape(new EllipseShape(new RectangleF(100f, 120f, 180f, 120f)));

            // Add the figure to the path
            graphicspath.AddFigure(figure);

            // Retrieve the bounding rectangle of the path
            RectangleF bounds = graphicspath.Bounds;

            // Align an additional rectangle shape using the retrieved bounds (offset by 10 units)
            RectangleF alignedRect = new RectangleF(bounds.X + 10f, bounds.Y + 10f, bounds.Width, bounds.Height);
            figure.AddShape(new RectangleShape(alignedRect));

            // Draw the path with a black pen
            graphics.DrawPath(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2), graphicspath);

            // Save the image (the output file is already bound to the source)
            image.Save();
        }
    }
}