using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output path (hard‑coded)
            string outputPath = @"c:\temp\translated_output.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a file source bound to the output file
            Source fileSource = new FileCreateSource(outputPath, false);

            // BMP options with the bound source
            BmpOptions bmpOptions = new BmpOptions() { Source = fileSource };

            // Create a BMP canvas of 400x300 pixels
            using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, 400, 300))
            {
                // Initialize Graphics for the canvas
                Graphics graphics = new Graphics(canvas);

                // Shift the drawing origin by (50,30)
                graphics.TranslateTransform(50, 30);

                // Draw a rectangle at the new origin (will appear at (50,30) in the image)
                graphics.DrawRectangle(new Pen(Color.Blue, 2), new Rectangle(0, 0, 100, 50));

                // Draw an ellipse relative to the translated origin
                graphics.DrawEllipse(new Pen(Color.Red, 2), new Rectangle(120, 20, 80, 60));

                // Save the bound image (writes to outputPath)
                canvas.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}