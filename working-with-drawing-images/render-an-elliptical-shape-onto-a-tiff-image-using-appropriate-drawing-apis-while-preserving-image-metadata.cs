using System;
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
        // Paths for input and output TIFF files
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        // Load the existing TIFF image
        using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
        {
            // Initialize Graphics for drawing
            Graphics graphics = new Graphics(tiffImage);

            // Create a GraphicsPath and a Figure
            GraphicsPath graphicsPath = new GraphicsPath();
            Figure figure = new Figure();

            // Define the ellipse bounds
            RectangleF ellipseRect = new RectangleF(50f, 50f, 200f, 150f);

            // Add the EllipseShape to the Figure
            figure.AddShape(new EllipseShape(ellipseRect));

            // Add the Figure to the GraphicsPath
            graphicsPath.AddFigure(figure);

            // Draw the ellipse using a Pen
            Pen pen = new Pen(Color.Blue, 3);
            graphics.DrawPath(pen, graphicsPath);

            // Save the modified image, preserving existing metadata
            tiffImage.Save(outputPath);
        }
    }
}