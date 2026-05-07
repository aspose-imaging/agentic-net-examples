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
        try
        {
            // Hardcoded paths
            string inputPath = "input.bmp";
            string outputPath = "output.bmp";

            // Input file existence check
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a BMP image
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Create a GraphicsPath and add figures
                GraphicsPath graphicspath = new GraphicsPath();

                // First figure with two shapes
                Figure figure1 = new Figure();
                figure1.AddShape(new RectangleShape(new RectangleF(10, 10, 100, 100)));
                figure1.AddShape(new EllipseShape(new RectangleF(150, 150, 200, 200)));

                // Second figure with one shape
                Figure figure2 = new Figure();
                figure2.AddShape(new RectangleShape(new RectangleF(300, 300, 50, 50)));

                // Add figures to the path
                graphicspath.AddFigures(new[] { figure1, figure2 });

                // Iterate over each figure and log the number of shapes it contains
                foreach (var fig in graphicspath.Figures)
                {
                    int shapeCount = fig.Shapes.Count();
                    Console.WriteLine($"Figure contains {shapeCount} shape(s).");
                }

                // Optional drawing to visualize the path
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.Wheat);
                graphics.DrawPath(new Pen(Color.Black, 2), graphicspath);

                // Save the image
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}