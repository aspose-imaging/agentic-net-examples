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
        try
        {
            // Define output path
            string outputPath = "output/output.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create PNG image options with a file create source
            var pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image canvas
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics object
                var graphics = new Aspose.Imaging.Graphics(image);

                // Clear the canvas
                graphics.Clear(Aspose.Imaging.Color.White);

                // Create a graphics path
                var graphicsPath = new Aspose.Imaging.GraphicsPath();

                // Create a figure and add a rectangle shape
                var figure = new Aspose.Imaging.Figure();
                figure.AddShape(new RectangleShape(new Aspose.Imaging.RectangleF(50f, 50f, 400f, 300f)));

                // Add the figure to the path
                graphicsPath.AddFigure(figure);

                // Create a linear gradient brush
                var gradientBrush = new LinearGradientBrush(
                    new Aspose.Imaging.PointF(0f, 0f),
                    new Aspose.Imaging.PointF(500f, 0f),
                    Aspose.Imaging.Color.Red,
                    Aspose.Imaging.Color.Blue);

                // Fill the rectangle path with the gradient brush
                graphics.FillPath(gradientBrush, graphicsPath);

                // Save the image (output path already bound to the source)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}