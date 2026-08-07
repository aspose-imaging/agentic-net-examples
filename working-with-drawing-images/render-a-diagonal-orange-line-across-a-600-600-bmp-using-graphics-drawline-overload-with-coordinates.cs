using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string outputPath = @"C:\temp\diagonal.bmp";

        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a 600x600 24‑bpp BMP image with 96 DPI
            using (BmpImage bmp = new BmpImage(
                width: 600,
                height: 600,
                bitsPerPixel: 24,
                palette: null,
                compression: BitmapCompression.Rgb,
                horizontalResolution: 96.0,
                verticalResolution: 96.0))
            {
                // Initialize graphics object for drawing
                Graphics graphics = new Graphics(bmp);

                // Draw a diagonal orange line from top‑left to bottom‑right
                graphics.DrawLine(
                    pen: new Pen(Color.Orange, 1),
                    x1: 0,
                    y1: 0,
                    x2: 600,
                    y2: 600);

                // Save the image to the specified path
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
 * 1. When a developer needs to generate a simple 600 × 600 BMP placeholder image with a diagonal orange line for testing image‑processing pipelines that accept BMP files.
 * 2. When creating a custom watermark or branding element that consists of a diagonal line on a 600 × 600 BMP used in desktop or web applications.
 * 3. When producing a diagnostic visual aid that highlights coordinate axes by drawing a diagonal orange line across a BMP image to debug graphics rendering code.
 * 4. When generating sample graphics for documentation or tutorials that demonstrate Aspose.Imaging’s Graphics.DrawLine overload with explicit C# coordinate parameters.
 * 5. When building a batch process that programmatically creates BMP icons with a diagonal orange line to indicate a “disabled” or “inactive” UI state.
 */