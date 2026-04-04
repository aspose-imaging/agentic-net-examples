using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output file path (hard‑coded)
        string outputPath = @"C:\temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Canvas dimensions
        int width = 500;
        int height = 500;

        // Create a file source bound to the output path
        Source source = new FileCreateSource(outputPath, false);
        // BMP options using the source
        BmpOptions bmpOptions = new BmpOptions() { Source = source };

        // Create the BMP canvas (bound image)
        using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, width, height))
        {
            // Graphics object for drawing
            Graphics graphics = new Graphics(canvas);

            // Clear background to dark gray
            graphics.Clear(Color.DarkGray);

            // Draw a bright yellow diagonal line
            Pen yellowPen = new Pen(Color.Yellow, 1);
            graphics.DrawLine(yellowPen, new Point(0, 0), new Point(width, height));

            // Save the bound image
            canvas.Save();
        }
    }
}