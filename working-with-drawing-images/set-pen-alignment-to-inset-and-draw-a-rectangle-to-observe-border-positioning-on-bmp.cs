// HOW-TO: Draw Inset Aligned Rectangle on BMP Image Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = @"C:\temp\output.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP options
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create image canvas
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, 400, 300))
            {
                // Initialize graphics
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                // Create pen with Inset alignment
                Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 5);
                pen.Alignment = Aspose.Imaging.PenAlignment.Inset;

                // Draw rectangle
                graphics.DrawRectangle(pen, new Aspose.Imaging.Rectangle(50, 50, 200, 100));

                // Save image
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
 * 1. When you need to generate a BMP file with a precisely positioned border for UI mockups, you can use an inset‑aligned pen to draw rectangles that stay inside the image edges.
 * 2. When creating technical diagrams where the stroke must not exceed the defined shape bounds, setting PenAlignment to Inset ensures the line stays within the rectangle on a 24‑bit BMP.
 * 3. When testing how different pen alignments affect rendering in Aspose.Imaging, drawing an inset rectangle on a BMP provides a clear visual reference.
 * 4. When exporting thumbnail previews of scanned documents and you want a consistent inner frame without cropping, an inset‑aligned rectangle can be drawn around the content area.
 * 5. When developing a reporting tool that adds blue borders to chart images saved as BMP, using PenAlignment.Inset guarantees the border is fully visible inside the image canvas.
 */
