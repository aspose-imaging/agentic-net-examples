// HOW-TO: Draw Pixel‑Perfect Horizontal Lines on a BMP Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded output path for BMP image
            string outputPath = @"C:\Temp\horizontal_lines.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create BMP options and bind to output file
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            int width = 200;
            int height = 100;

            // Create image canvas
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics for drawing
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

                // Clear background to white
                graphics.Clear(Aspose.Imaging.Color.White);

                // Pen for drawing horizontal lines (1 pixel wide, black)
                Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 1);

                // Draw pixel‑perfect horizontal lines at every 10 pixels
                for (int y = 0; y < height; y += 10)
                {
                    graphics.DrawLine(pen, 0, y, width - 1, y);
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
 * 1. When you need to generate a BMP chart background with evenly spaced grid lines for a reporting tool.
 * 2. When creating a printable form template where precise one‑pixel horizontal separators are required.
 * 3. When producing a simple barcode or ruler image that relies on exact horizontal line placement.
 * 4. When automating the creation of UI mock‑ups that show row dividers in a bitmap snapshot.
 * 5. When building a game level map overlay that needs crisp horizontal lines without anti‑aliasing artifacts.
 */
