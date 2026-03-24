using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\output.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up BMP options with a file create source
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create a new image canvas
        using (Image image = Image.Create(bmpOptions, 500, 500))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.Wheat);

            // Create a GraphicsPath to hold figures
            GraphicsPath graphicsPath = new GraphicsPath();

            // First figure with a rectangle shape
            Figure figure1 = new Figure();
            figure1.AddShape(new RectangleShape(new RectangleF(10f, 10f, 200f, 150f)));

            // Second figure with an ellipse shape
            Figure figure2 = new Figure();
            figure2.AddShape(new EllipseShape(new RectangleF(250f, 250f, 100f, 100f)));

            // Attach multiple figures to the path
            Figure[] figures = new[] { figure1, figure2 };
            graphicsPath.AddFigures(figures);

            // Draw the path onto the image
            graphics.DrawPath(new Pen(Color.Black, 2), graphicsPath);

            // Save the image (output is already bound to the source)
            image.Save();
        }
    }
}