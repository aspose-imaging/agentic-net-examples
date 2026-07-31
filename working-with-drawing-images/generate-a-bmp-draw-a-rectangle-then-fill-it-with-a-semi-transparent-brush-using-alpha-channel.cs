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
        try
        {
            // Output file path (hard‑coded)
            string outputPath = @"C:\Temp\output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set BMP options and bind the output file
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 500x500 BMP image
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Optional: clear background to white
                graphics.Clear(Color.White);

                // Define rectangle area
                Rectangle rect = new Rectangle(100, 100, 300, 200);

                // Draw rectangle outline
                Pen pen = new Pen(Color.Black, 2);
                graphics.DrawRectangle(pen, rect);

                // Fill rectangle with a semi‑transparent blue brush
                using (SolidBrush brush = new SolidBrush())
                {
                    brush.Color = Color.Blue;
                    brush.Opacity = 0.5f; // 50 % opacity
                    graphics.FillRectangle(brush, rect);
                }

                // Save the image (output file already bound)
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
 * 1. When a developer needs to create a BMP thumbnail for a Windows desktop application and highlight a region with a semi‑transparent overlay.
 * 2. When generating a printable bitmap report where a colored rectangle indicates a grade band with 50 % opacity.
 * 3. When building a game asset pipeline that requires BMP sprites with translucent selection boxes for UI elements.
 * 4. When producing a diagnostic BMP image for medical imaging software that marks an area of interest using a semi‑transparent brush.
 * 5. When automating the creation of BMP watermarks for scanned documents by drawing a rectangle with a translucent color to protect copyrighted sections.
 */