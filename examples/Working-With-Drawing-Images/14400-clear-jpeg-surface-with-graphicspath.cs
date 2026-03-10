using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Input and output JPEG file paths
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        // Load the JPEG image
        using (JpegImage image = (JpegImage)Image.Load(inputPath))
        {
            // Create a Graphics object for drawing
            Graphics graphics = new Graphics(image);

            // Create a GraphicsPath that covers the entire image
            GraphicsPath path = new GraphicsPath();
            Figure figure = new Figure();
            // Rectangle covering the whole canvas
            figure.AddShape(new RectangleShape(new RectangleF(0f, 0f, image.Width, image.Height)));
            path.AddFigure(figure);

            // Fill the path with a solid color (clearing the surface)
            using (SolidBrush brush = new SolidBrush(Color.Wheat))
            {
                graphics.FillPath(brush, path);
            }

            // Save the modified image
            image.Save(outputPath);
        }
    }
}