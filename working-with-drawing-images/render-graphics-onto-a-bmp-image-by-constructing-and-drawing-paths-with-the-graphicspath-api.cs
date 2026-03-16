using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Output file path and canvas size
        string outputPath = @"c:\temp\output.bmp";
        int width = 500;
        int height = 500;

        // Configure BMP options (24 bits per pixel) and set the file source
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create the image canvas bound to the output file
        using (Image image = Image.Create(bmpOptions, width, height))
        {
            // Initialize graphics for drawing on the image
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.Wheat); // Fill background

            // Create a graphics path to hold multiple figures
            GraphicsPath path = new GraphicsPath();

            // First figure with rectangle, ellipse, and pie shapes
            Figure figure1 = new Figure();
            figure1.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));
            figure1.AddShape(new EllipseShape(new RectangleF(100f, 200f, 250f, 150f)));
            figure1.AddShape(new PieShape(new RectangleF(150f, 100f, 200f, 200f), 0f, 120f));

            // Second figure with another ellipse and rectangle
            Figure figure2 = new Figure();
            figure2.AddShape(new EllipseShape(new RectangleF(300f, 300f, 150f, 100f)));
            figure2.AddShape(new RectangleShape(new RectangleF(20f, 350f, 100f, 80f)));

            // Add both figures to the path
            path.AddFigures(new[] { figure1, figure2 });

            // Draw the combined path using a black pen
            Pen pen = new Pen(Color.Black, 2);
            graphics.DrawPath(pen, path);

            // Save the image (file is already bound to the source)
            image.Save();
        }
    }
}