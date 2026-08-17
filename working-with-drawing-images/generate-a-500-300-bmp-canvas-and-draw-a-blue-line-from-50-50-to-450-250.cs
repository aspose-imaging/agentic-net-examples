// HOW-TO: Create 500x300 BMP Image With Blue Diagonal Line In C# (Aspose.Imaging for .NET)
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
            string outputPath = "output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Create a file source for the BMP image
            Source source = new FileCreateSource(outputPath, false);
            BmpOptions options = new BmpOptions() { Source = source };

            // Create a 500x300 BMP canvas
            using (RasterImage canvas = (RasterImage)Image.Create(options, 500, 300))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(canvas);

                // Draw a blue line from (50,50) to (450,250)
                Pen pen = new Pen(Color.Blue, 1);
                graphics.DrawLine(pen, 50, 50, 450, 250);

                // Save the image
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
 * 1. When you need to generate a simple BMP placeholder image with a custom line for UI mockups.
 * 2. When you want to programmatically draw a guide or annotation on a bitmap for engineering diagrams.
 * 3. When creating test images for image‑processing algorithms that require a known line pattern.
 * 4. When exporting a line drawing from a C# application to a BMP file for legacy systems that only support BMP.
 * 5. When automating the production of graphics for reports where a blue line indicates a trend or direction.
 */
