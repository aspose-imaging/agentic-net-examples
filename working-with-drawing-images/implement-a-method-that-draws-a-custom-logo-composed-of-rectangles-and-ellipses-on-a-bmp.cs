// HOW-TO: Create Custom BMP Logo With Rectangles And Ellipses In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded output path
        string outputPath = @"c:\temp\custom_logo.bmp";

        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set BMP options
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 400x400 BMP image
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, 400, 400))
            {
                // Initialize graphics for drawing
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

                // Clear background to white
                graphics.Clear(Aspose.Imaging.Color.White);

                // Draw a blue rectangle
                Aspose.Imaging.Pen rectPen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 3);
                graphics.DrawRectangle(rectPen, 50, 50, 300, 200);

                // Draw a red ellipse inside the rectangle
                Aspose.Imaging.Pen ellipsePen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 3);
                graphics.DrawEllipse(ellipsePen, 100, 100, 200, 150);

                // Save the image (output path already bound via FileCreateSource)
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
 * 1. When you need to generate a simple brand logo programmatically as a 24‑bit BMP file using C# and Aspose.Imaging.
 * 2. When an application must create placeholder images with geometric shapes for testing UI layouts.
 * 3. When you want to produce printable graphics, such as badges or certificates, that require precise rectangle and ellipse outlines.
 * 4. When a server‑side service generates custom icons or watermarks on BMP images without relying on external design tools.
 * 5. When you need to automate the creation of diagrammatic illustrations, like flow‑chart symbols, directly from .NET code.
 */
