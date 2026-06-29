using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\temp\input.png";
            string outputPath = @"C:\temp\output.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Create a Graphics object for drawing
                Graphics graphics = new Graphics(image);

                // Define a floating‑point rectangle (x, y, width, height)
                RectangleF rect = new RectangleF(50f, 50f, 200f, 150f);

                // Draw the rectangle with a red pen of width 3
                graphics.DrawRectangle(new Pen(Color.Red, 3), rect);

                // Save the modified image to the output path
                image.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to highlight a detected object with a sub‑pixel accurate red border on a PNG image using Aspose.Imaging’s Graphics.DrawRectangle overload with a RectangleF structure.
 * 2. When a developer wants to add a scalable annotation box to a high‑resolution JPEG photo in a C# image‑editing tool, ensuring the rectangle’s position and size are defined with floating‑point precision.
 * 3. When a developer is creating a thumbnail preview of a BMP file and must draw a precise red rectangle to indicate a region of interest for a UI overlay.
 * 4. When a developer builds an automated report that marks specific coordinates on a TIFF map image, using a floating‑point rectangle to align with geographic data.
 * 5. When a developer implements a batch process that adds a red rectangular watermark to a series of PNG assets, relying on RectangleF for exact placement across varying image dimensions.
 */