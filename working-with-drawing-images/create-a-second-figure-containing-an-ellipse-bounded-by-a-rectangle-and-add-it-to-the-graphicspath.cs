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
            string outputPath = @"c:\temp\output.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP options
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create image canvas
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.Wheat);

                // Create a graphics path
                GraphicsPath graphicspath = new GraphicsPath();

                // First figure (optional example)
                Figure figure1 = new Figure();
                figure1.AddShape(new RectangleShape(new RectangleF(10f, 10f, 300f, 300f)));
                graphicspath.AddFigure(figure1);

                // Second figure containing an ellipse bounded by a rectangle
                Figure figure2 = new Figure();
                // Ellipse bounded by the specified rectangle
                figure2.AddShape(new EllipseShape(new RectangleF(100f, 100f, 200f, 150f)));
                graphicspath.AddFigure(figure2);

                // Draw the path
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