using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input path (not used for processing, just checked)
        string inputPath = @"c:\temp\input.bmp";
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Hardcoded output path
        string outputPath = @"c:\temp\output.bmp";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a BMP image
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        using (Image image = Image.Create(bmpOptions, 500, 500))
        {
            // Initialize graphics (no using block as Graphics is not disposable)
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.Wheat);

            // Create a GraphicsPath and add figures with shapes
            GraphicsPath graphicspath = new GraphicsPath();

            Figure figure1 = new Figure();
            figure1.AddShape(new RectangleShape(new RectangleF(50, 50, 200, 200)));
            figure1.AddShape(new EllipseShape(new RectangleF(100, 100, 150, 150)));

            Figure figure2 = new Figure();
            figure2.AddShape(new RectangleShape(new RectangleF(200, 200, 100, 100)));
            figure2.AddShape(new EllipseShape(new RectangleF(250, 250, 80, 80)));

            graphicspath.AddFigures(new[] { figure1, figure2 });

            // Draw the path
            graphics.DrawPath(new Pen(Color.Black, 2), graphicspath);

            // Iterate over each figure and log the number of shapes it contains
            foreach (Figure fig in graphicspath.Figures)
            {
                int shapeCount = fig.Shapes != null ? fig.Shapes.Length : 0;
                Console.WriteLine($"Figure contains {shapeCount} shape(s).");
            }

            // Save the image
            image.Save();
        }
    }
}