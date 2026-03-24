using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.tif";
        string outputPath = @"C:\temp\output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the existing TIFF image
        using (TiffImage image = (TiffImage)Image.Load(inputPath))
        {
            // Initialize Graphics for drawing
            Graphics graphics = new Graphics(image);

            // Define the bounding rectangle for the ellipse
            RectangleF ellipseRect = new RectangleF(50f, 50f, 300f, 200f);

            // Build a GraphicsPath containing the ellipse shape
            GraphicsPath path = new GraphicsPath();
            Figure figure = new Figure();
            figure.AddShape(new EllipseShape(ellipseRect));
            path.AddFigure(figure);

            // Draw the ellipse with a red pen of width 3
            Pen pen = new Pen(Color.Red, 3);
            graphics.DrawPath(pen, path);

            // Save the modified image, preserving original metadata
            image.Save(outputPath);
        }
    }
}