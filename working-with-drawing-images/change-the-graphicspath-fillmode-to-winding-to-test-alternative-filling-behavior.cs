using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Define output path
        string outputPath = @"c:\temp\output.png";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create PNG options with a file create source
        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        // Create a new image canvas
        using (Image image = Image.Create(pngOptions, 500, 500))
        {
            // Initialize graphics
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.Wheat);

            // Create a GraphicsPath with FillMode.Winding
            GraphicsPath graphicspath = new GraphicsPath(FillMode.Winding);

            // Create a figure and add shapes
            Figure figure = new Figure();
            figure.AddShape(new RectangleShape(new RectangleF(10f, 10f, 300f, 300f)));
            figure.AddShape(new EllipseShape(new RectangleF(50f, 50f, 300f, 300f)));
            figure.AddShape(new PieShape(new RectangleF(new PointF(250f, 250f), new SizeF(200f, 200f)), 0f, 45f));

            // Add figure to the path
            graphicspath.AddFigure(figure);

            // Draw the path outline
            graphics.DrawPath(new Pen(Color.Black, 2), graphicspath);

            // Fill the path to demonstrate winding fill mode
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(128, Color.Red)))
            {
                graphics.FillPath(brush, graphicspath);
            }

            // Save the image (output path already bound)
            image.Save();
        }
    }
}