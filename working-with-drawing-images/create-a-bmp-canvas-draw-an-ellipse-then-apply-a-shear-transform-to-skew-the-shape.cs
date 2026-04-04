using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Output file path (relative)
        string outputPath = "output/output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a file source for the BMP image
        Source source = new FileCreateSource(outputPath, false);

        // Set BMP options (24 bits per pixel)
        BmpOptions bmpOptions = new BmpOptions()
        {
            Source = source,
            BitsPerPixel = 24
        };

        // Create the BMP canvas (500x500)
        using (Image canvas = Image.Create(bmpOptions, 500, 500))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(canvas);

            // Clear background
            graphics.Clear(Color.Wheat);

            // Draw a normal ellipse
            Pen normalPen = new Pen(Color.Black, 2);
            graphics.DrawEllipse(normalPen, new RectangleF(100, 100, 300, 200));

            // Apply a shear (skew) transform: horizontal shear factor 0.5
            Matrix shearMatrix = new Matrix(1, 0.5f, 0, 1, 0, 0);
            graphics.MultiplyTransform(shearMatrix);

            // Draw the same ellipse after shear (appears skewed)
            Pen skewedPen = new Pen(Color.Red, 2);
            graphics.DrawEllipse(skewedPen, new RectangleF(100, 100, 300, 200));

            // Save the bound image (no path needed because source is bound)
            canvas.Save();
        }
    }
}