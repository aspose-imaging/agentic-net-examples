using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a file source bound to the output path
        Source source = new FileCreateSource(outputPath, false);

        // Set up BMP options with the source
        BmpOptions options = new BmpOptions() { Source = source };

        // Define canvas size
        int width = 200;
        int height = 200;

        // Create a BMP canvas bound to the file source
        using (RasterImage canvas = (RasterImage)Image.Create(options, width, height))
        {
            // Fill the canvas with red color
            Graphics graphics = new Graphics(canvas);
            SolidBrush brush = new SolidBrush(Color.Red);
            graphics.FillRectangle(brush, canvas.Bounds);

            // Save the bound image
            canvas.Save();
        }
    }
}