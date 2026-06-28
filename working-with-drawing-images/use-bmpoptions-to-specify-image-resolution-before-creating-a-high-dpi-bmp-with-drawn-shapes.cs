using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Brushes;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Output file path (hard‑coded)
            string outputPath = @"C:\Temp\highdpi_output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure BMP creation options with high DPI (e.g., 300)
            BmpOptions createOptions = new BmpOptions
            {
                BitsPerPixel = 24,                         // 24‑bpp color
                Compression = BitmapCompression.Rgb,       // No compression
                ResolutionSettings = new ResolutionSetting(300.0, 300.0) // 300 dpi
            };

            // Create a new BMP image of 200 × 200 pixels
            using (Image image = Image.Create(createOptions, 200, 200))
            {
                // Obtain a graphics object for drawing
                Graphics graphics = new Graphics(image);

                // Draw a red rectangle
                SolidBrush redBrush = new SolidBrush(Color.Red);
                graphics.FillRectangle(redBrush, new Rectangle(10, 10, 180, 80));

                // Draw a blue ellipse
                SolidBrush blueBrush = new SolidBrush(Color.Blue);
                graphics.FillEllipse(blueBrush, new Rectangle(20, 100, 160, 80));

                // Save the image to the specified path
                image.Save(outputPath);
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
 * 1. When generating printable marketing materials such as flyers or brochures that require a 300 dpi BMP image with custom graphics drawn at runtime using BmpOptions in C#.
 * 2. When creating high‑resolution scanned document placeholders for a document management system that need exact DPI settings and programmatically drawn shapes via Aspose.Imaging.
 * 3. When producing medical imaging overlays (e.g., annotations on X‑ray BMP files) where the DPI must match the original scan for accurate measurements and the overlay is rendered with Graphics.
 * 4. When exporting CAD or engineering diagrams to BMP format for legacy systems that expect a specific bits‑per‑pixel depth and resolution while drawing shapes using BmpOptions.
 * 5. When developing a Windows desktop application that generates high‑DPI icons or UI assets on the fly, using Aspose.Imaging’s BmpOptions to set resolution and render shapes before saving the BMP file.
 */