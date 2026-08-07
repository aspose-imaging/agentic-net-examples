using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output BMP file path
            string outputPath = @"C:\temp\highdpi_output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure BMP options with high DPI resolution
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.ResolutionSettings = new ResolutionSetting(300.0, 300.0);
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new BMP image with the specified options
            using (Image image = Image.Create(bmpOptions, 800, 600))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Clear background to white
                graphics.Clear(Color.White);

                // Draw a black rectangle
                Pen blackPen = new Pen(Color.Black, 5);
                graphics.DrawRectangle(blackPen, new Rectangle(100, 100, 600, 400));

                // Fill an ellipse with blue color
                using (SolidBrush blueBrush = new SolidBrush(Color.Blue))
                {
                    graphics.FillEllipse(blueBrush, new Rectangle(200, 150, 400, 300));
                }

                // Draw a red diagonal line
                Pen redPen = new Pen(Color.Red, 3);
                graphics.DrawLine(redPen, new Point(0, 0), new Point(image.Width, image.Height));

                // Save the image (source is already bound to the file)
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
 * 1. When a developer needs to generate a high‑DPI BMP file for printing brochures, setting ResolutionSetting to 300 dpi ensures crisp output while drawing vector shapes.
 * 2. When creating a printable diagram or technical illustration in a Windows desktop application, using BmpOptions with 24‑bit color and custom resolution lets the image retain detail on large‑format printers.
 * 3. When exporting a CAD‑style drawing from a .NET service to a BMP that must match a specific DPI for integration with legacy imaging pipelines, the code provides precise control over image size and resolution.
 * 4. When producing high‑resolution thumbnails for a document management system that require exact DPI metadata for downstream OCR processing, the BmpOptions approach guarantees consistent scaling.
 * 5. When generating a rasterized report chart in a server‑side C# process that will be embedded in a PDF with defined print quality, setting the BMP resolution before drawing shapes ensures the chart appears sharp at 300 dpi.
 */