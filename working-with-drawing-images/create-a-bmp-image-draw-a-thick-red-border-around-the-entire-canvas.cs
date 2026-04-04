using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up BMP creation options with a file source
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        int width = 500;
        int height = 500;

        // Create a bound BMP canvas
        using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, width, height))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(canvas);

            // Define a thick red pen
            Pen redPen = new Pen(Color.Red, 10);

            // Draw a red border around the entire canvas
            graphics.DrawRectangle(redPen, 0, 0, canvas.Width, canvas.Height);

            // Save the bound image to the specified file
            canvas.Save();
        }
    }
}