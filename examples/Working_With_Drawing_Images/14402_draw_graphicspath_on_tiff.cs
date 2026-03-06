using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output TIFF file path
        string outputPath = "output.tif";

        // Configure TIFF options and bind the output file
        var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
        tiffOptions.Source = new FileCreateSource(outputPath, false);

        // Create a new TIFF image canvas
        using (Image image = Image.Create(tiffOptions, 500, 500))
        {
            // Initialize graphics for drawing
            var graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // Create a GraphicsPath and a Figure
            var graphicsPath = new GraphicsPath();
            var figure = new Figure();

            // Add shapes to the figure
            figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 400f, 400f)));
            figure.AddShape(new EllipseShape(new RectangleF(100f, 100f, 300f, 300f)));

            // Add the figure to the graphics path
            graphicsPath.AddFigure(figure);

            // Draw the path onto the image
            graphics.DrawPath(new Pen(Color.Blue, 5), graphicsPath);

            // Save the image (file is already bound to the source)
            image.Save();
        }
    }
}