using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string outputPath = @"C:\temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Set up BMP options with a file source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            int width = 500;
            int height = 500;

            // Create the image canvas
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Thin black pen
                Pen pen = new Pen(Color.Black, 1);

                // Draw ten equally spaced vertical lines
                int lineCount = 10;
                int spacing = width / (lineCount + 1);
                for (int i = 1; i <= lineCount; i++)
                {
                    int x = i * spacing;
                    graphics.DrawLine(pen, x, 0, x, height);
                }

                // Save the image (file is already bound to the source)
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
 * 1. When a developer needs to generate a simple BMP template with evenly spaced vertical guide lines for a UI layout mock‑up using Aspose.Imaging for .NET.
 * 2. When creating a printable barcode or ruler image where ten vertical markers must be drawn at regular intervals on a 24‑bit BMP file.
 * 3. When producing a test pattern image to verify image processing pipelines, such as edge detection, by drawing thin black lines on a white background in C#.
 * 4. When automating the generation of column separators for a spreadsheet export that is saved as a BMP image using Aspose.Imaging’s Graphics API.
 * 5. When building a lightweight diagram or chart that requires equally spaced vertical lines as a background grid in a BMP image created programmatically.
 */