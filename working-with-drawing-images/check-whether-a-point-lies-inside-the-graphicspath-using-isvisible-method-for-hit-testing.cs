using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.png";
            string outputPath = @"C:\temp\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Create graphics object for drawing
                Graphics graphics = new Graphics(image);

                // Create a new GraphicsPath and add a rectangle shape
                GraphicsPath graphicsPath = new GraphicsPath();
                Figure figure = new Figure();
                RectangleF rect = new RectangleF(50f, 50f, 200f, 200f);
                figure.AddShape(new RectangleShape(rect));
                graphicsPath.AddFigure(figure);

                // Test a point using IsVisible
                float testX = 100f;
                float testY = 100f;
                bool isInside = graphicsPath.IsVisible(testX, testY);
                Console.WriteLine($"Point ({testX}, {testY}) inside path: {isInside}");

                // Draw the path so the output image shows the shape
                graphics.DrawPath(new Pen(Color.Black, 2), graphicsPath);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the modified image
                image.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}