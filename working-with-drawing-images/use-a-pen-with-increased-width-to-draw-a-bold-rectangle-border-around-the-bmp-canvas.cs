using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output BMP file path
            string outputPath = @"C:\temp\output.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a file source bound to the output path
            Source source = new FileCreateSource(outputPath, false);

            // Set BMP options with the source
            BmpOptions options = new BmpOptions() { Source = source };

            // Canvas dimensions
            int width = 800;
            int height = 600;

            // Create BMP canvas
            using (RasterImage canvas = (RasterImage)Image.Create(options, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(canvas);

                // Optional: clear background
                graphics.Clear(Color.White);

                // Pen with increased width for bold border
                Pen pen = new Pen(Color.Black, 10);

                // Draw rectangle border around the entire canvas
                graphics.DrawRectangle(pen, 0, 0, width, height);

                // Save the bound image
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
 * 1. When generating printable reports in C# that must include a thick black frame around a BMP diagram to comply with corporate branding guidelines, developers can use Aspose.Imaging to draw a bold rectangle border.
 * 2. When creating thumbnail previews for a document management system, a developer may add a high‑contrast 10‑pixel wide rectangle around the BMP canvas to clearly delineate image boundaries.
 * 3. When preprocessing scanned documents for OCR, adding a bold black border to the BMP image helps improve alignment detection and edge recognition during image processing.
 * 4. When building a Windows desktop application that programmatically enhances BMP assets before saving them to a shared folder, a developer can use the Graphics and Pen classes to apply a uniform bold rectangle outline.
 * 5. When automating batch conversion of raw graphics to BMP files, developers often need to ensure each output includes a consistent bold rectangle border using Aspose.Imaging’s RasterImage and drawing APIs.
 */