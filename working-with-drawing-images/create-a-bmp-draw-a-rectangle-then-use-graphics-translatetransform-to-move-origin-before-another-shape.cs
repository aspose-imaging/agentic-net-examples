using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output BMP file path (hard‑coded)
            string outputPath = @"c:\temp\output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a file source bound to the output path
            Source source = new FileCreateSource(outputPath, false);

            // Set BMP options with the source
            BmpOptions bmpOptions = new BmpOptions() { Source = source };

            // Create a BMP canvas of size 400x300
            using (Image image = Image.Create(bmpOptions, 400, 300))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Optional: clear background to white
                graphics.Clear(Color.White);

                // Draw first rectangle (blue)
                Pen pen1 = new Pen(Color.Blue, 3);
                graphics.DrawRectangle(pen1, new Rectangle(50, 50, 200, 100));

                // Translate the origin by (100,150)
                graphics.TranslateTransform(100, 150);

                // Draw second rectangle (red) after translation
                Pen pen2 = new Pen(Color.Red, 3);
                graphics.DrawRectangle(pen2, new Rectangle(0, 0, 100, 50));

                // Save the bound image (output file is already bound via source)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}