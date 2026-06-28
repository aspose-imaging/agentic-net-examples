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
        string outputPath = @"c:\temp\output.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Set BMP options
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create image canvas
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Draw first rectangle
                Pen pen1 = new Pen(Color.Blue, 3);
                graphics.DrawRectangle(pen1, 50, 50, 200, 100);

                // Translate origin
                graphics.TranslateTransform(100, 100);

                // Draw second rectangle after translation
                Pen pen2 = new Pen(Color.Red, 3);
                graphics.DrawRectangle(pen2, 0, 0, 150, 80);

                // Save image
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to generate a 24‑bit BMP image with a blue border rectangle and then overlay a red rectangle offset by 100 px using Graphics.TranslateTransform to highlight a specific area.
 * 2. When creating a printable label in C# where the first rectangle defines the label margin and the translated origin positions a second rectangle for a barcode or QR‑code region without recomputing absolute coordinates.
 * 3. When building a simple UI mock‑up that draws multiple shapes on a bitmap and uses TranslateTransform to shift the origin, making it easier to place subsequent elements relative to the first shape.
 * 4. When implementing a custom watermarking routine that draws a base rectangle on a BMP canvas and then translates the drawing surface to add a secondary rectangle as a dynamic logo placeholder.
 * 5. When developing a diagnostic tool that visualizes coordinate transformations by drawing an initial rectangle and then moving the origin to demonstrate how TranslateTransform affects later drawing commands in Aspose.Imaging for .NET.
 */