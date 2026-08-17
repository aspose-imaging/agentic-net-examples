// HOW-TO: Create BMP With Semi Transparent Filled Rectangle In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path
            string outputPath = @"c:\temp\output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set BMP options with 32 bits per pixel to support alpha
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 32;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 200x200 image canvas
            using (Image image = Image.Create(bmpOptions, 200, 200))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Clear background to white
                graphics.Clear(Color.White);

                // Define rectangle bounds
                Rectangle rect = new Rectangle(50, 50, 100, 100);

                // Draw rectangle outline
                Pen pen = new Pen(Color.Black, 2);
                graphics.DrawRectangle(pen, rect);

                // Fill rectangle with semi‑transparent blue brush
                using (SolidBrush brush = new SolidBrush(Color.Blue))
                {
                    brush.Opacity = 0.5f; // 50% opacity
                    graphics.FillRectangle(brush, rect);
                }

                // Save the image (output is already bound to the file)
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
 * 1. When you need to generate a 32‑bit BMP badge that includes a semi‑transparent overlay for a desktop application UI.
 * 2. When you want to programmatically add a translucent colored rectangle to a bitmap for highlighting regions in a medical imaging report.
 * 3. When you are creating custom map tiles where a semi‑transparent rectangle marks an area of interest on a BMP background.
 * 4. When you need to produce a BMP watermark with adjustable opacity to protect images before publishing them online.
 * 5. When you are building a batch process that draws and fills shapes on BMP files for automated label printing with alpha‑blended graphics.
 */
