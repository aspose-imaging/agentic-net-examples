using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input/output paths
        string outputPath = "output\\output.bmp";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // BMP save options
            BmpOptions bmpOptions = new BmpOptions();

            // Canvas size
            int width = 200;
            int height = 100;

            // Create a new BMP image
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics for the image
                Graphics graphics = new Graphics(image);

                // Clear background to white
                graphics.Clear(Color.White);

                // Pen for drawing (black, 1 pixel width)
                Pen pen = new Pen(Color.Black, 1);

                // Draw horizontal lines every 10 pixels
                for (int y = 0; y < height; y += 10)
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
 * 1. When a developer needs to generate a printable BMP form template with pixel‑perfect horizontal grid lines using Graphics.DrawLine and integer coordinates.
 * 2. When creating a simple ruler or barcode overlay where exact horizontal lines are drawn on a BMP image for precise measurement.
 * 3. When designing a game UI background that requires evenly spaced horizontal separators rendered on a BMP canvas with C# Graphics and Pen objects.
 * 4. When exporting a data table to BMP and adding row dividers as crisp horizontal lines to ensure proper alignment in the final image.
 * 5. When building a diagnostic visualization tool that marks sensor thresholds as horizontal lines on a BMP file for quick visual analysis.
 */