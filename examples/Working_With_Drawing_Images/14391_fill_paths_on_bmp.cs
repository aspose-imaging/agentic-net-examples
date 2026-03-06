using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Output BMP file path
        string outputPath = "output.bmp";

        // Canvas size
        int width = 400;
        int height = 300;

        // Create BMP options with a file source
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create the image canvas
        using (Image image = Image.Create(bmpOptions, width, height))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // Define a closed figure with a rectangle shape
            Figure figure = new Figure();
            figure.IsClosed = true;
            figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 300f, 200f)));

            // Build a graphics path from the figure
            GraphicsPath path = new GraphicsPath();
            path.AddFigure(figure);

            // Pen for outline and brush for fill
            Pen pen = new Pen(Color.Green, 2);
            using (SolidBrush brush = new SolidBrush(Color.Yellow))
            {
                // Fill the path
                graphics.FillPath(pen, brush, path);
            }

            // Save the image (file is already bound to the source)
            image.Save();
        }
    }
}