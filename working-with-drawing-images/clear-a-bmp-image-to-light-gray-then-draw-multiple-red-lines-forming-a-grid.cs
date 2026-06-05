using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\grid.bmp";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 200;
            int height = 200;
            int spacing = 20; // distance between grid lines

            // Create a new BMP image
            using (BmpImage bmp = new BmpImage(width, height))
            {
                // Initialize graphics object
                Graphics graphics = new Graphics(bmp);

                // Clear the image to light gray
                graphics.Clear(Color.LightGray);

                // Prepare a red pen for drawing grid lines
                Pen redPen = new Pen(Color.Red, 1);

                // Draw vertical lines
                for (int x = 0; x <= width; x += spacing)
                {
                    graphics.DrawLine(redPen, new Point(x, 0), new Point(x, height));
                }

                // Draw horizontal lines
                for (int y = 0; y <= height; y += spacing)
                {
                    graphics.DrawLine(redPen, new Point(0, y), new Point(width, y));
                }

                // Save the resulting image
                bmp.Save(outputPath);
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
 * 1. When generating a light‑gray BMP thumbnail with a red grid overlay for a CAD preview in a .NET desktop application.
 * 2. When creating a printable 200 × 200 pixel graph paper template in BMP format for a Windows Forms utility that lets users annotate images.
 * 3. When building a diagnostic tool that visualizes sensor data as a red‑lined grid on a light‑gray BMP canvas for quick alignment checks.
 * 4. When producing a simple BMP sprite sheet background with evenly spaced red lines to assist game developers in positioning assets during level design.
 * 5. When automating the generation of a BMP placeholder image with a red grid to indicate layout sections in a web‑based image editor built with C#.
 */