using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
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

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the input image
            using (Image image = Image.Load(inputPath))
            {
                // Create a Graphics instance for drawing
                Graphics graphics = new Graphics(image);

                // Create a GraphicsPath
                GraphicsPath graphicspath = new GraphicsPath();

                // Create a Figure and add shapes to it
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(10f, 10f, 300f, 300f)));
                figure.AddShape(new EllipseShape(new RectangleF(50f, 50f, 300f, 300f)));
                figure.AddShape(new PieShape(
                    new RectangleF(new PointF(250f, 250f), new SizeF(200f, 200f)),
                    0f, 45f));

                // Add the completed Figure to the GraphicsPath
                graphicspath.AddFigure(figure);

                // Draw the path onto the image
                graphics.DrawPath(new Pen(Color.Black, 2), graphicspath);

                // Save the modified image as PNG
                PngOptions pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}