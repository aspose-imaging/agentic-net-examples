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
            // Hardcoded output path
            string outputPath = @"C:\temp\vertical_lines.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int imageWidth = 500;
            int imageHeight = 500;
            int lineCount = 10;
            int spacing = imageWidth / (lineCount + 1);

            // Set BMP creation options
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create the BMP image
            using (Image image = Image.Create(bmpOptions, imageWidth, imageHeight))
            {
                // Initialize graphics object
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White); // optional background

                // Thin black pen
                Pen pen = new Pen(Color.Black, 1);

                // Draw ten equally spaced vertical lines
                for (int i = 1; i <= lineCount; i++)
                {
                    int x = i * spacing;
                    graphics.DrawLine(pen, x, 0, x, imageHeight);
                }

                // Save the image
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
 * 1. When generating a printable grid overlay for a 500 × 500 pixel BMP template in a C# desktop application, a developer can use this code to draw ten equally spaced vertical lines with a thin black pen.
 * 2. When creating a simple barcode‑like reference image for testing image‑processing algorithms, the loop produces evenly spaced vertical strokes on a 24‑bit BMP using Aspose.Imaging.
 * 3. When preparing a background for a UI mockup that requires evenly spaced separators, the code draws vertical lines on a BMP file that can be loaded later in a .NET form.
 * 4. When automating the production of calibration charts for a scanner, a developer can employ this snippet to render ten vertical markers on a BMP image with precise spacing.
 * 5. When building a teaching example that demonstrates the use of Graphics, Pen, and DrawLine methods in Aspose.Imaging for .NET, the loop provides a clear visual of ten vertical lines on a white BMP canvas.
 */