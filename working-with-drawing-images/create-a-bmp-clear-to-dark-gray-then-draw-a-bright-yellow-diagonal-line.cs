using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path (hard‑coded)
            string outputPath = "output/output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP options with a bound file source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            int width = 200;
            int height = 200;

            // Create the BMP canvas (bound to the output file)
            using (BmpImage canvas = (BmpImage)Image.Create(bmpOptions, width, height))
            {
                // Obtain a graphics object for drawing
                Graphics graphics = new Graphics(canvas);

                // Clear the canvas to dark gray
                graphics.Clear(Color.DarkGray);

                // Draw a bright yellow diagonal line
                Pen pen = new Pen(Color.Yellow, 2);
                graphics.DrawLine(pen, new Point(0, 0), new Point(width - 1, height - 1));

                // Save the bound image
                canvas.Save();
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
 * 1. Developers generate a simple BMP placeholder image with a dark gray background and a bright yellow diagonal line for UI mockups.
 * 2. Engineers create a diagnostic test image to verify BMP file creation, color clearing, and line drawing operations in a C# imaging pipeline.
 * 3. Designers produce a low‑resolution watermark template in BMP format where the diagonal yellow line serves as a visual guide for later overlay.
 * 4. Developers automate the generation of thumbnail icons for a file‑explorer application that require a consistent dark gray background and a highlighted diagonal marker.
 * 5. Game developers prepare a BMP asset for a loading screen where the bright yellow diagonal line indicates progress direction during development testing.
 */