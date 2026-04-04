using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Output BMP file path
        string outputPath = @"C:\temp\gauge.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a file source bound to the output path
        Source source = new FileCreateSource(outputPath, false);

        // BMP options with the source
        BmpOptions bmpOptions = new BmpOptions() { Source = source };

        // Canvas size (width x height)
        int width = 400;
        int height = 200; // Semi‑circular gauge will be drawn within this area

        // Create the BMP canvas (bound image)
        using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, width, height))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(canvas);

            // Clear background to white
            graphics.Clear(Color.White);

            // Outer semi‑circular arc (black, thick)
            Pen outerPen = new Pen(Color.Black, 4);
            graphics.DrawArc(outerPen, new Rectangle(0, 0, width, height * 2), 180, 180);

            // Inner semi‑circular arc (red, thinner)
            Pen innerPen = new Pen(Color.Red, 2);
            graphics.DrawArc(innerPen, new Rectangle(20, 20, width - 40, (height * 2) - 40), 180, 180);

            // Marker arc to indicate a value (blue, medium)
            Pen markerPen = new Pen(Color.Blue, 2);
            graphics.DrawArc(markerPen, new Rectangle(100, 20, width - 200, (height * 2) - 40), 180, 30);

            // Save the bound image to the specified BMP file
            canvas.Save();
        }
    }
}