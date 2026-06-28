using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Output BMP file path
            string outputPath = @"c:\temp\output_inset.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure BMP options
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a 200x200 BMP image
            using (Image image = Image.Create(bmpOptions, 200, 200))
            {
                // Initialize graphics object
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Create a pen with inset alignment
                Pen pen = new Pen(Color.Black, 10);
                pen.Alignment = PenAlignment.Inset;

                // Draw a rectangle to observe border positioning
                graphics.DrawRectangle(pen, 20, 20, 160, 160);

                // Save the image
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
 * 1. When a developer needs to generate a printable BMP report with a black border that stays completely inside the page margins, they can use PenAlignment.Inset to keep the rectangle’s stroke within the defined area.
 * 2. When creating UI mock‑ups for a Windows desktop application, a programmer can draw inset‑aligned rectangles on a 24‑bit BMP to simulate button outlines that remain inside the control’s bounds.
 * 3. When preparing assets for a legacy embedded system that only supports BMP files, using an inset pen guarantees that the border thickness is accounted for within the image dimensions, preventing clipping on low‑resolution displays.
 * 4. When automating the production of certification seals where the outer ring must be fully contained within a fixed 200 × 200 BMP canvas, PenAlignment.Inset ensures the ring’s 10‑pixel stroke stays inside the seal’s perimeter.
 * 5. When testing image‑processing pipelines that crop or resize BMP images, drawing an inset‑aligned rectangle provides a reliable visual reference that remains unchanged after subsequent transformations.
 */