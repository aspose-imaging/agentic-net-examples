using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\input.png";
        string outputPath = @"c:\temp\output\polygon.png";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create PNG options with a FileCreateSource bound to the output path
        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        // Create a new image canvas (500x500)
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, 500, 500))
        {
            // Initialize graphics for drawing
            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
            graphics.Clear(Aspose.Imaging.Color.White);

            // Create a GraphicsPath
            Aspose.Imaging.GraphicsPath graphicsPath = new Aspose.Imaging.GraphicsPath();

            // Create a Figure and add a polygon shape
            Aspose.Imaging.Figure figure = new Aspose.Imaging.Figure();
            Aspose.Imaging.PointF[] polygonPoints = new Aspose.Imaging.PointF[]
            {
                new Aspose.Imaging.PointF(100f, 100f),
                new Aspose.Imaging.PointF(400f, 100f),
                new Aspose.Imaging.PointF(350f, 300f),
                new Aspose.Imaging.PointF(150f, 300f)
            };
            figure.AddShape(new PolygonShape(polygonPoints, true));

            // Add the figure to the graphics path
            graphicsPath.AddFigure(figure);

            // Fill the polygon path with a solid brush
            using (SolidBrush solidBrush = new SolidBrush(Aspose.Imaging.Color.Blue))
            {
                graphics.FillPath(solidBrush, graphicsPath);
            }

            // Save the image (output path already bound to the source)
            image.Save();
        }
    }
}