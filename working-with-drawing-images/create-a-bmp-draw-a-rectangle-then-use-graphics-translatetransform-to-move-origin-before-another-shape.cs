using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Output BMP file path
            string outputPath = @"C:\temp\output.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set BMP options and bind to output file
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create image canvas
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Draw first rectangle at original origin
                Pen pen1 = new Pen(Color.Blue, 3);
                graphics.DrawRectangle(pen1, new Rectangle(50, 50, 200, 150));

                // Translate origin
                graphics.TranslateTransform(100, 100);

                // Draw second rectangle after translation
                Pen pen2 = new Pen(Color.Red, 3);
                graphics.DrawRectangle(pen2, new Rectangle(0, 0, 200, 150));

                // Save the image (output already bound)
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
 * 1. When a developer needs to generate a BMP report thumbnail with multiple positioned rectangles for a CAD preview using Aspose.Imaging for .NET.
 * 2. When creating a printable label image where the first rectangle defines the margin and TranslateTransform shifts the origin to place a barcode box relative to the margin.
 * 3. When building a UI mock‑up that visualizes component boundaries by drawing a base rectangle and then moving the coordinate system to overlay a highlighted area without recalculating absolute coordinates.
 * 4. When automating the production of game level maps that require a background grid rectangle and a translated obstacle rectangle saved as a 24‑bit BMP file.
 * 5. When developing a diagnostic tool that captures screen regions into BMP files, using TranslateTransform to align subsequent shapes with a reference point for easier comparison.
 */