using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output BMP file path
            string outputPath = @"C:\temp\output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure BMP options with desired compression
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Compression = BitmapCompression.Rgb; // Set compression level
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new BMP image canvas
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Draw shapes on the canvas
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Draw a blue rectangle
                graphics.DrawRectangle(new Pen(Color.Blue, 5), new Rectangle(50, 50, 400, 400));

                // Draw a red ellipse inside the rectangle
                graphics.DrawEllipse(new Pen(Color.Red, 3), new Rectangle(100, 100, 300, 200));

                // Draw a green line
                graphics.DrawLine(new Pen(Color.Green, 2), new Point(50, 250), new Point(450, 250));

                // Save the image (bound to the file via FileCreateSource)
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
 * 1. When generating custom report graphics in a C# desktop application that must be saved as a compressed BMP file for legacy Windows printing systems.
 * 2. When creating thumbnails with drawn annotations (rectangles, ellipses, lines) for a medical imaging viewer that requires BMP format with specific compression to reduce file size.
 * 3. When exporting diagrammatic schematics from an engineering tool to BMP while controlling compression to meet storage constraints in an embedded device.
 * 4. When producing batch‑processed BMP assets for a game that uses simple vector shapes and needs consistent compression across all images for faster loading.
 * 5. When implementing an automated document conversion service that adds watermarks to scanned BMP images and sets the compression level to balance quality and bandwidth.
 */