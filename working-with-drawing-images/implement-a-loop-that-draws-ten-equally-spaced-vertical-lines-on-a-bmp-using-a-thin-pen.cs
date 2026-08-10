// HOW-TO: Create BMP With Ten Evenly Spaced Vertical Lines In C# (Aspose.Imaging for .NET)
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
            string outputPath = @"C:\temp\vertical_lines.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // BMP options
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Image dimensions
            int width = 500;
            int height = 500;

            // Create the image bound to the output file
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Pen for thin vertical lines
                Pen pen = new Pen(Color.Black, 1f);

                // Draw ten equally spaced vertical lines
                int lineCount = 10;
                for (int i = 1; i <= lineCount; i++)
                {
                    int x = i * width / (lineCount + 1);
                    graphics.DrawLine(pen, x, 0, x, height);
                }

                // Save the image (file is already bound)
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
 * 1. When generating a printable grid overlay for engineering drawings you need a BMP with evenly spaced vertical reference lines using C#.
 * 2. When creating a simple barcode-like pattern for testing image scanners, you can draw thin vertical lines on a BMP with Aspose.Imaging.
 * 3. When producing a background template for a UI layout that requires fixed vertical separators, this code programmatically creates the BMP file.
 * 4. When automating the production of calibration charts for camera alignment, you can generate a BMP with ten vertical lines at precise intervals.
 * 5. When building a teaching example that demonstrates basic drawing operations such as pens and lines in Aspose.Imaging for .NET.
 */
