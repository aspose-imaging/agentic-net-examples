using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output BMP file path
            string outputPath = "output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Set BMP options and bind to the output file
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 500x500 BMP image
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Define a pen for the arc
                Pen pen = new Pen(Color.Blue, 2);

                // Define the rectangle with floating‑point values
                RectangleF rect = new RectangleF(50.5f, 50.5f, 200.5f, 150.5f);

                // Draw an arc (0° to 180°) within the rectangle
                graphics.DrawArc(pen, rect, 0f, 180f);

                // Save the image (file is already bound via FileCreateSource)
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
 * 1. When a developer needs to generate a high‑resolution BMP report that includes precisely positioned semi‑circular gauges, they can use Graphics.DrawArc with a RectangleF to place the arc at sub‑pixel coordinates.
 * 2. When creating custom icons for a Windows desktop application where the arc must align with other vector elements on a 24‑bit BMP canvas, the floating‑point rectangle ensures accurate placement.
 * 3. When producing scientific visualizations such as a polar plot saved as a BMP file, the code lets you draw arcs with exact start and sweep angles using Aspose.Imaging’s Graphics object.
 * 4. When automating the generation of printable engineering diagrams that require smooth arcs on a 500×500 BMP sheet, using RectangleF with DrawArc provides pixel‑perfect control over the curve’s location.
 * 5. When building a batch process that adds decorative blue arcs to scanned BMP images for branding purposes, the floating‑point rectangle allows fine‑tuned positioning without raster distortion.
 */