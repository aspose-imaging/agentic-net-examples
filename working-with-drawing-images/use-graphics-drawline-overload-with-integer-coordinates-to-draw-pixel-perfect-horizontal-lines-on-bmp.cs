using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output BMP file path
            string outputPath = "output/output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Image dimensions
            int width = 200;
            int height = 100;

            // BMP options for creating and saving the image
            BmpOptions bmpOptions = new BmpOptions();

            // Create a blank BMP image
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Pen for drawing horizontal lines (1 pixel wide, black)
                Pen pen = new Pen(Color.Black, 1);

                // Draw pixel‑perfect horizontal lines across the image
                for (int y = 0; y < height; y++)
                {
                    graphics.DrawLine(pen, 0, y, width - 1, y);
                }

                // Save the image to the specified path
                image.Save(outputPath, bmpOptions);
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
 * 1. When generating a simple grid background for a data‑visualization chart that will be saved as a BMP file using C# and Aspose.Imaging’s Graphics.DrawLine overload.
 * 2. When creating a monochrome barcode or line‑code image where each horizontal line must align exactly on pixel boundaries in a BMP image.
 * 3. When producing a custom BMP sprite sheet for a retro‑style video game that requires precise horizontal separators between frames drawn with integer coordinates.
 * 4. When programmatically adding underlines to scanned document thumbnails stored as BMP images to highlight text rows with pixel‑perfect lines.
 * 5. When building a diagnostic tool that renders pixel‑accurate ruler markings on a BMP canvas for hardware display calibration.
 */