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
            // Define output path
            string outputPath = @"C:\temp\bordered_image.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Image dimensions
            int width = 500;
            int height = 400;

            // Set up BMP options with a file create source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create the image canvas
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Draw a thick black border
                Pen borderPen = new Pen(Color.Black, 10);
                graphics.DrawRectangle(borderPen, new Rectangle(0, 0, width, height));

                // Fill an inner rectangle with a light gray color
                using (SolidBrush innerBrush = new SolidBrush(Color.LightGray))
                {
                    int inset = 20;
                    graphics.FillRectangle(innerBrush, new Rectangle(inset, inset, width - 2 * inset, height - 2 * inset));
                }

                // Save the image (file is already bound via FileCreateSource)
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
 * 1. When a developer needs to generate a BMP thumbnail with a prominent black frame for a legacy Windows application UI.
 * 2. When an automated report generator must embed a bordered placeholder image in a PDF that only supports BMP graphics.
 * 3. When a game engine requires a simple BMP sprite sheet with a thick outline to indicate selectable items.
 * 4. When a batch processing tool creates printable label templates where the outer border defines the cut line and the inner gray area holds variable text.
 * 5. When a diagnostic utility produces a BMP screenshot of a device screen with a high‑contrast border to highlight the captured region in logs.
 */