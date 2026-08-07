using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = @"C:\temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Create a source bound to the output file
            Source source = new FileCreateSource(outputPath, false);

            // Set BMP options with 24 bits per pixel
            BmpOptions options = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = source
            };

            // Create the image with the specified options and size
            using (Image image = Image.Create(options, 500, 500))
            {
                // Initialize graphics and clear the canvas
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

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
 * 1. When a developer needs to generate a blank 24‑bit BMP canvas for drawing vector graphics such as logos or diagrams in a C# desktop application, they can use Image.Create with BmpOptions.
 * 2. When an automated reporting tool must create high‑resolution bitmap images on the fly to embed charts into PDF documents, the code provides a reliable way to produce a 500 × 500 24‑bpp BMP file.
 * 3. When a batch image‑processing pipeline requires a temporary white background image to composite scanned documents before applying OCR, Image.Create with a FileCreateSource ensures the file is created directly on disk.
 * 4. When a game development utility needs to export level‑design thumbnails as BMP files with exact pixel depth for compatibility with legacy engines, this snippet creates the required 24‑bit image programmatically.
 * 5. When a web service generates custom QR‑code overlays and must save them as BMP files with a known color depth for downstream Windows applications, the code demonstrates how to create and save the image in C#.
 */