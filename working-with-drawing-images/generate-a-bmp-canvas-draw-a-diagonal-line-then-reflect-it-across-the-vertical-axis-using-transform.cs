using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Define output path
        string outputPath = "output/output.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create file source for BMP output
        Source source = new FileCreateSource(outputPath, false);
        BmpOptions bmpOptions = new BmpOptions() { Source = source };

        // Canvas size
        int width = 400;
        int height = 400;

        // Create BMP canvas bound to the file source
        using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, width, height))
        {
            // Create graphics object for drawing
            Graphics graphics = new Graphics(canvas);

            // Draw original diagonal line (top-left to bottom-right)
            Pen pen = new Pen(Color.Blue, 2);
            graphics.DrawLine(pen, 0, 0, width, height);

            // Apply horizontal reflection (mirror across vertical axis)
            graphics.TranslateTransform(canvas.Width, 0);
            graphics.ScaleTransform(-1, 1);

            // Draw reflected diagonal line (will appear mirrored)
            graphics.DrawLine(pen, 0, 0, width, height);

            // Save the bound image
            canvas.Save();
        }
    }
}