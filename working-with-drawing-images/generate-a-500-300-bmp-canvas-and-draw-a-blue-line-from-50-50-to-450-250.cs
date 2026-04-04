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
        string outputPath = "output/output.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a source bound to the output file
        FileCreateSource source = new FileCreateSource(outputPath, false);

        // Set BMP options with the source
        BmpOptions bmpOptions = new BmpOptions() { Source = source };

        // Create a 500x300 BMP canvas
        using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, 500, 300))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(canvas);

            // Draw a blue line from (50,50) to (450,250)
            graphics.DrawLine(new Pen(Color.Blue, 1), 50, 50, 450, 250);

            // Save the bound image
            canvas.Save();
        }
    }
}