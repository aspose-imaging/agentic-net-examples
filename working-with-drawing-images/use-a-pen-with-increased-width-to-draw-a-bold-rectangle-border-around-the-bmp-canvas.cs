using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.bmp";
        string outputPath = @"C:\temp\output.bmp";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the BMP image from the input path
            using (Image image = Image.Load(inputPath))
            {
                // Create a Graphics object for drawing on the image
                Graphics graphics = new Graphics(image);

                // Define a pen with increased width for a bold border
                Pen boldPen = new Pen(Color.Red, 5); // 5-pixel-wide red pen

                // Draw a rectangle that matches the image borders
                graphics.DrawRectangle(boldPen, 0, 0, image.Width, image.Height);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the modified image to the output path
                image.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            // Output any unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to add a bold red border to a BMP image using a 5‑pixel‑wide Pen and Graphics.DrawRectangle for highlighting or branding before publishing it online.
 * 2. When an application must generate printable BMP files with a thick rectangle frame to indicate page margins by drawing a rectangle that matches the image dimensions.
 * 3. When a batch‑processing tool has to mark scanned BMP documents with a visible border for quality‑control review by drawing a rectangle with an increased pen width.
 * 4. When a C# program creates thumbnail previews of BMP assets and wants to emphasize the edges with a 5‑pixel‑wide Pen drawn via Graphics.DrawRectangle.
 * 5. When a legacy system requires BMP images with a colored border to comply with a specific file‑format specification for downstream processing, using Aspose.Imaging to draw the rectangle.
 */