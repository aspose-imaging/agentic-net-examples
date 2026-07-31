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
            // Output BMP file path (hard‑coded)
            string outputPath = @"C:\temp\concentric_rectangles.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure BMP options
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a 500×500 BMP image
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White); // White background

                // Colors to alternate between
                Color[] colors = { Color.Red, Color.Blue };
                int penWidth = 5;
                int rectCount = 5;          // Number of concentric rectangles
                int offsetStep = 20;        // Gap between rectangles

                // Draw each rectangle
                for (int i = 0; i < rectCount; i++)
                {
                    int offset = i * offsetStep;
                    int size = 500 - 2 * offset;
                    Rectangle rect = new Rectangle(offset, offset, size, size);
                    Pen pen = new Pen(colors[i % colors.Length], penWidth);
                    graphics.DrawRectangle(pen, rect);
                }

                // Save the image (writes to the path supplied in FileCreateSource)
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
 * 1. When a developer needs to generate a 24‑bit BMP thumbnail that visualizes nested boundaries, such as a UI layout preview, they can use this code to draw concentric rectangles with alternating colors.
 * 2. When creating test images for automated image‑processing pipelines that require known geometric patterns in a BMP file, this example provides a quick way to produce such patterns.
 * 3. When building a reporting tool that embeds simple schematic diagrams (e.g., floor‑plan sections) directly into BMP files, the code can be used to render layered rectangles with configurable pen width and colors.
 * 4. When preparing sample data for computer‑vision algorithms that detect edges or shapes, developers can generate a series of concentric rectangles in a BMP image to evaluate detection accuracy.
 * 5. When a developer wants to programmatically produce a printable BMP badge or label with decorative borders, the code demonstrates how to draw multiple rectangles with alternating pen colors using Aspose.Imaging for .NET.
 */