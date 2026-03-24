using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a BMP image of size 400x400
        BmpOptions bmpOptions = new BmpOptions();
        using (Image image = Image.Create(bmpOptions, 400, 400))
        {
            // Initialize graphics for the image
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // Build a GraphicsPath with a rectangle and an ellipse
            GraphicsPath path = new GraphicsPath();
            Figure figure = new Figure();

            // Rectangle shape
            figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 300f, 200f)));
            // Ellipse shape
            figure.AddShape(new EllipseShape(new RectangleF(100f, 150f, 200f, 150f)));

            // Add the figure to the path
            path.AddFigure(figure);

            // Draw the path with a black pen
            Pen pen = new Pen(Color.Black, 3);
            graphics.DrawPath(pen, path);

            // Fill the same path with a semi‑transparent light blue brush
            SolidBrush brush = new SolidBrush(Color.FromArgb(128, Color.LightBlue));
            graphics.FillPath(brush, path);

            // Save the resulting BMP image
            image.Save(outputPath);
        }
    }
}