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
        // Hardcoded output path
        string outputPath = @"C:\temp\output.bmp";

        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP options with a file create source bound to the output path
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image canvas (500x500)
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Clear background to white
                graphics.Clear(Color.White);

                // Define rectangle bounds
                Rectangle rect = new Rectangle(100, 100, 300, 200);

                // Draw rectangle outline
                graphics.DrawRectangle(new Pen(Color.Black, 2), rect);

                // Fill rectangle with semi‑transparent blue brush
                using (SolidBrush brush = new SolidBrush(Color.Blue))
                {
                    brush.Opacity = 0.5f; // 0 = fully visible, 1 = fully opaque (semi‑transparent)
                    graphics.FillRectangle(brush, rect);
                }

                // Save the image (output path already bound via FileCreateSource)
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
 * 1. When a developer needs to create a BMP thumbnail for a legacy Windows application and highlight a region with a semi‑transparent overlay.
 * 2. When generating printable forms in C# where a rectangle marks a user‑selected area on a BMP background with an alpha‑blended color.
 * 3. When producing diagnostic screenshots for a medical imaging system that require a clear rectangle annotation with adjustable opacity.
 * 4. When building a game asset pipeline that programmatically draws UI panels onto BMP textures and uses semi‑transparent fills for visual effects.
 * 5. When automating the creation of BMP‑based certificates that include a semi‑transparent colored border to emphasize the signature field.
 */