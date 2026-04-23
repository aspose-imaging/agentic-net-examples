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
        string outputPath = @"C:\temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a source bound to the output file
        Source source = new FileCreateSource(outputPath, false);

        // BMP options with the bound source
        BmpOptions options = new BmpOptions() { Source = source };

        // Create a 500x300 BMP canvas
        using (RasterImage canvas = (RasterImage)Image.Create(options, 500, 300))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(canvas);

            // Blue pen with default width
            Pen pen = new Pen(Color.Blue, 1);

            // Draw line from (50,50) to (450,250)
            graphics.DrawLine(pen, 50, 50, 450, 250);

            // Save the bound image
            canvas.Save();
        }
    }
}