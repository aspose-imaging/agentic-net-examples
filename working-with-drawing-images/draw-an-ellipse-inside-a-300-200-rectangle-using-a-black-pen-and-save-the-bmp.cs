using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hard‑coded output path
        string outputPath = @"c:\temp\ellipse.bmp";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP options (24‑bit colour) and assign the output source
            var bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a new image (size large enough to contain the rectangle)
            using (Image image = Image.Create(bmpOptions, 400, 300))
            {
                // Initialize graphics for drawing
                var graphics = new Graphics(image);

                // Optional: clear background to white
                graphics.Clear(Color.White);

                // Define a black pen (2‑pixel width)
                var pen = new Pen(Color.Black, 2);

                // Draw an ellipse inside a 300 × 200 rectangle at position (50,50)
                graphics.DrawEllipse(pen, new Rectangle(50, 50, 300, 200));

                // Save the image to the specified path
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
 * 1. When generating a printable report that requires a simple black‑outlined ellipse inside a defined 300 × 200 rectangle and the output must be a 24‑bit BMP for compatibility with legacy imaging systems.
 * 2. When creating a placeholder graphic for a UI mockup where an ellipse represents a button or icon within a specific rectangle and the design assets are stored as BMP files.
 * 3. When automating the production of test images for computer‑vision algorithms that need a known geometric shape drawn with a black pen on a white background in BMP format.
 * 4. When exporting diagram elements from a C# application to a BMP image for inclusion in documentation, and the element is an ellipse constrained to a 300 × 200 rectangle.
 * 5. When building a batch process that adds a black‑outlined ellipse to existing images by creating a new 400 × 300 BMP canvas, drawing the shape inside a 300 × 200 rectangle, and saving it to a file system path.
 */