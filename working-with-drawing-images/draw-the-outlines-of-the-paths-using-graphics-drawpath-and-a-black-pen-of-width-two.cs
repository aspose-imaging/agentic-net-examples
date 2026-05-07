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
        try
        {
            // Output file path (hardcoded)
            string outputPath = "output.png";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Create PNG options with a FileCreateSource bound to the output path
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Define image dimensions
            int width = 500;
            int height = 500;

            // Create the image canvas
            using (Image image = Image.Create(pngOptions, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Build a graphics path with several shapes
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();

                // Rectangle shape
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));
                // Ellipse shape
                figure.AddShape(new EllipseShape(new RectangleF(100f, 100f, 200f, 150f)));
                // Pie shape
                figure.AddShape(new PieShape(new RectangleF(new PointF(150f, 150f), new SizeF(200f, 200f)), 0f, 45f));

                // Add the figure to the path
                path.AddFigure(figure);

                // Draw the path outline with a black pen of width 2
                graphics.DrawPath(new Pen(Color.Black, 2), path);

                // Save the image (output is already bound to the FileCreateSource)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}