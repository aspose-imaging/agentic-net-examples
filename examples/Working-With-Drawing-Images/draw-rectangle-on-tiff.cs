using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Output TIFF file path
        string outputPath = "output.tif";

        // Configure TIFF options and bind to the output file
        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
        tiffOptions.Source = new FileCreateSource(outputPath, false);

        // Create a blank TIFF image of size 500x500
        using (Image image = Image.Create(tiffOptions, 500, 500))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // Build a graphics path containing a rectangle shape
            GraphicsPath graphicsPath = new GraphicsPath();
            Figure figure = new Figure();
            // Rectangle at (50,50) with width 400 and height 300
            figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 400f, 300f)));
            graphicsPath.AddFigure(figure);

            // Draw the rectangle with a blue pen of thickness 5
            graphics.DrawPath(new Pen(Color.Blue, 5), graphicsPath);

            // Save the image (file is already bound via FileCreateSource)
            image.Save();
        }
    }
}