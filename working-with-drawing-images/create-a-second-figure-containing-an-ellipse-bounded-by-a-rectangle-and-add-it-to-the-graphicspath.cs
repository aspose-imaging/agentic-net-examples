using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Output file path (hardcoded)
        string outputPath = @"c:\temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up BMP options and bind the output file
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create the image canvas
        using (Image image = Image.Create(bmpOptions, 500, 500))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.Wheat);

            // Create a graphics path to hold figures
            GraphicsPath graphicspath = new GraphicsPath();

            // First figure (example rectangle)
            Figure figure1 = new Figure();
            figure1.AddShape(new RectangleShape(new RectangleF(10f, 10f, 300f, 300f)));

            // Second figure containing an ellipse bounded by a rectangle
            Figure figure2 = new Figure();
            figure2.AddShape(new EllipseShape(new RectangleF(50f, 50f, 300f, 300f)));

            // Add both figures to the graphics path
            graphicspath.AddFigures(new[] { figure1, figure2 });

            // Draw the path onto the image
            graphics.DrawPath(new Pen(Color.Black, 2), graphicspath);

            // Save the image (output is already bound to the file)
            image.Save();
        }
    }
}