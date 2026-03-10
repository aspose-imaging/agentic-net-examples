using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.FileFormats.Tiff.PathResources;

class Program
{
    static void Main()
    {
        // Define output directory (adjust as needed)
        string outputPath = @"c:\temp\output.png";

        // Create a new PNG image with desired dimensions
        using (PngImage pngImage = new PngImage(200, 200))
        {
            // Initialize Graphics object for drawing on the PNG image
            Graphics graphics = new Graphics(pngImage);

            // Create an empty GraphicsPath instance
            GraphicsPath graphicsPath = new GraphicsPath();

            // Build a simple figure (a rectangle) and add it to the path
            Figure figure = new Figure();
            figure.AddShape(new RectangleShape(new RectangleF(20f, 20f, 160f, 160f)));
            graphicsPath.AddFigure(figure);

            // Draw the path onto the image using a blue pen
            Pen pen = new Pen(Color.Blue, 4);
            graphics.DrawPath(pen, graphicsPath);

            // Save the modified PNG image to disk
            pngImage.Save(outputPath);
        }
    }
}