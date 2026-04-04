using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Define output path
        string outputPath = @"c:\temp\output.bmp";

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

            // Create a graphics path and add figures
            GraphicsPath graphicspath = new GraphicsPath();

            // First figure with two shapes
            Figure figure1 = new Figure();
            figure1.AddShape(new RectangleShape(new RectangleF(50, 50, 300, 300)));
            figure1.AddShape(new EllipseShape(new RectangleF(100, 100, 200, 200)));
            graphicspath.AddFigure(figure1);

            // Second figure with one shape
            Figure figure2 = new Figure();
            figure2.AddShape(new RectangleShape(new RectangleF(150, 150, 100, 100)));
            graphicspath.AddFigure(figure2);

            // Draw the path
            graphics.DrawPath(new Pen(Color.Black, 2), graphicspath);

            // Iterate over each figure and log the number of shapes it contains
            int figureIndex = 0;
            foreach (Figure fig in graphicspath.Figures)
            {
                int shapeCount = fig.Shapes.Count();
                Console.WriteLine($"Figure {figureIndex}: contains {shapeCount} shape(s).");
                figureIndex++;
            }

            // Save the image (already bound to outputPath)
            image.Save();
        }
    }
}