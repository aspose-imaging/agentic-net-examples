using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Output file path
        string outputPath = "output.jp2";

        // Canvas size
        int width = 500;
        int height = 500;

        // Set up JPEG2000 options with a file create source
        Jpeg2000Options jp2Options = new Jpeg2000Options();
        jp2Options.Source = new FileCreateSource(outputPath, false);

        // Create a JPEG2000 image canvas
        using (Jpeg2000Image image = new Jpeg2000Image(width, height, jp2Options))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);

            // Create a solid brush for clearing (filling) the surface
            using (SolidBrush brush = new SolidBrush())
            {
                brush.Color = Color.Wheat;
                brush.Opacity = 100;

                // Build a GraphicsPath that covers the entire canvas
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(0f, 0f, width, height)));
                path.AddFigure(figure);

                // Fill the path to clear the surface with the brush color
                graphics.FillPath(brush, path);
            }

            // Save the image (file is already bound via FileCreateSource)
            image.Save();
        }
    }
}