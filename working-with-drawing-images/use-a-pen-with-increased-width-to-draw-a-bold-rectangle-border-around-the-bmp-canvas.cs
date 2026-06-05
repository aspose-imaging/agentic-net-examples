using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded paths
        string outputPath = @"C:\temp\output.bmp";

        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a file source bound to the output path
            Source source = new FileCreateSource(outputPath, false);

            // BMP options with the source
            BmpOptions bmpOptions = new BmpOptions() { Source = source };

            // Canvas size
            int width = 800;
            int height = 600;

            // Create BMP canvas bound to the file source
            using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(canvas);

                // Optional: clear background to white
                graphics.Clear(Color.White);

                // Pen with increased width for a bold border
                Pen pen = new Pen(Color.Black, 10);

                // Draw rectangle border covering the entire canvas
                graphics.DrawRectangle(pen, new Rectangle(0, 0, width, height));

                // Save the bound image (no need to pass options again)
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
 * 1. When a developer needs to generate a BMP file with a thick black frame to highlight the edges of a scanned document for printing or archival purposes.
 * 2. When creating a placeholder image in a C# application where a bold rectangle border indicates the required dimensions for user‑uploaded photos.
 * 3. When producing a watermark‑style border around a generated chart or diagram in BMP format to comply with corporate branding guidelines.
 * 4. When building a batch‑processing tool that adds a high‑visibility border to BMP screenshots before they are sent to a quality‑control system.
 * 5. When designing a simple UI mockup in .NET where a thick rectangle drawn with Aspose.Imaging’s Pen class outlines the layout area of a future UI component.
 */