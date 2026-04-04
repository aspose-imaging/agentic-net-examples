using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded output path
        string outputPath = @"c:\temp\output.png";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create PNG options
        PngOptions pngOptions = new PngOptions();

        // Create a new image canvas (500x500)
        using (Image image = Image.Create(pngOptions, 500, 500))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);

            // Clear background
            graphics.Clear(Color.White);

            // Create a graphics path
            GraphicsPath graphicsPath = new GraphicsPath();

            // Create a figure and add a polygon shape
            Figure figure = new Figure();
            PointF[] polygonPoints = new PointF[]
            {
                new PointF(100f, 100f),
                new PointF(400f, 100f),
                new PointF(250f, 400f)
            };
            PolygonShape polygon = new PolygonShape(polygonPoints, true);
            figure.AddShape(polygon);

            // Add the figure to the path
            graphicsPath.AddFigure(figure);

            // Fill the polygon using a solid brush
            using (SolidBrush solidBrush = new SolidBrush(Color.LightBlue))
            {
                graphics.FillPath(solidBrush, graphicsPath);
            }

            // Save the image to the specified path
            image.Save(outputPath, pngOptions);
        }
    }
}