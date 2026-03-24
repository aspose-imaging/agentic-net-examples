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
        // Hardcoded output path
        string outputPath = @"C:\temp\ellipse.tif";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure TIFF options
        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
        tiffOptions.Source = new FileCreateSource(outputPath, false);

        // Create a new TIFF image (500x500)
        using (Image image = Image.Create(tiffOptions, 500, 500))
        {
            // Initialize Graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // Build a GraphicsPath containing an ellipse
            GraphicsPath graphicsPath = new GraphicsPath();
            Figure figure = new Figure();

            // Define the ellipse bounds
            RectangleF ellipseRect = new RectangleF(50f, 50f, 400f, 300f);
            EllipseShape ellipse = new EllipseShape(ellipseRect);

            // Add the ellipse shape to the figure
            figure.AddShape(ellipse);

            // Add the figure to the path
            graphicsPath.AddFigure(figure);

            // Draw the path with a black pen of width 2
            graphics.DrawPath(new Pen(Color.Black, 2), graphicsPath);

            // Save the image (output is already bound to the file)
            image.Save();
        }
    }
}