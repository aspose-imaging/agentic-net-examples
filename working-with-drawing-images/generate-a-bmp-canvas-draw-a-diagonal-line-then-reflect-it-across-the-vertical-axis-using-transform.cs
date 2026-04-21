using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Output file path
        string outputPath = "Output\\diagonal_reflected.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create BMP canvas
        Source source = new FileCreateSource(outputPath, false);
        BmpOptions options = new BmpOptions() { Source = source };
        int width = 200;
        int height = 200;

        using (RasterImage canvas = (RasterImage)Image.Create(options, width, height))
        {
            // Initialize graphics
            Graphics graphics = new Graphics(canvas);
            graphics.Clear(Color.White);

            // Pen for drawing
            Pen pen = new Pen(Color.Black, 2);

            // Draw original diagonal line
            graphics.DrawLine(pen, 0, 0, width, height);

            // Apply vertical axis reflection transform
            // Matrix(a, b, c, d, e, f) corresponds to:
            // [ a  c  e ]
            // [ b  d  f ]
            // [ 0  0  1 ]
            // For horizontal reflection: a = -1, d = 1, e = width
            graphics.MultiplyTransform(new Matrix(-1, 0, 0, 1, width, 0));

            // Draw reflected diagonal line
            graphics.DrawLine(pen, 0, 0, width, height);

            // Save the image (bound to the source)
            canvas.Save();
        }
    }
}