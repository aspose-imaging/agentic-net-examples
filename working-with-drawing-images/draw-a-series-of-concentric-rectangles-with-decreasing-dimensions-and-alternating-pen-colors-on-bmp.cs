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
            // Output file path
            string outputPath = Path.Combine("output", "concentric_rectangles.bmp");

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set BMP options with a file source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 500x500 BMP image
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                int canvasSize = 500;   // Width and height of the canvas
                int rectCount = 6;      // Number of concentric rectangles
                int step = 20;          // Gap between rectangles

                // Draw rectangles with alternating colors
                for (int i = 0; i < rectCount; i++)
                {
                    int offset = i * step;
                    int size = canvasSize - 2 * offset;
                    Aspose.Imaging.Rectangle rect = new Aspose.Imaging.Rectangle(offset, offset, size, size);

                    Aspose.Imaging.Color penColor = (i % 2 == 0) ? Aspose.Imaging.Color.Red : Aspose.Imaging.Color.Blue;
                    Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(penColor, 3f);

                    graphics.DrawRectangle(pen, rect);
                }

                // Save the bound image
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
 * 1. When a developer needs to generate a BMP thumbnail that visualizes nested layout boundaries for a UI mock‑up, they can use this code to draw concentric rectangles with alternating red and blue pens.
 * 2. When creating test images for automated image‑processing pipelines that require known geometric patterns in a 24‑bit BMP file, this snippet quickly produces a series of decreasing rectangles.
 * 3. When producing printable calibration sheets that show step‑by‑step scaling for printers or scanners, the code can render concentric rectangles on a BMP canvas to serve as reference marks.
 * 4. When building a diagnostic tool that highlights region‑of‑interest layers in medical or satellite imagery, developers can overlay alternating colored rectangles on a BMP image to illustrate each layer.
 * 5. When teaching beginners how to use Aspose.Imaging’s Graphics API in C# to manipulate colors, pens, and shapes, this example demonstrates drawing multiple rectangles with different pen colors and saving the result as a BMP file.
 */