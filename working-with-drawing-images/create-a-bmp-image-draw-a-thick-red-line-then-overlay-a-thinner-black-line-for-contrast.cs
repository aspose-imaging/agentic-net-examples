// HOW-TO: Create BMP with Thick Red Line and Thin Black Outline in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Set up BMP options with a file source bound to the output path
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath);

            // Create a new image canvas (200x200 pixels)
            using (Image image = Image.Create(bmpOptions, 200, 200))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Draw a thick red line
                Pen redPen = new Pen(Color.Red, 10);
                graphics.DrawLine(redPen, new Point(20, 20), new Point(180, 180));

                // Overlay a thinner black line for contrast
                Pen blackPen = new Pen(Color.Black, 2);
                graphics.DrawLine(blackPen, new Point(20, 20), new Point(180, 180));

                // Save the image (output path already bound)
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
 * 1. When you need to generate a BMP diagram that highlights a path with a bold red line and a subtle black edge for better visibility in a Windows desktop application.
 * 2. When creating custom icons or UI elements where a thick colored stroke must be outlined with a thinner contrasting line to improve legibility on varied backgrounds.
 * 3. When producing test images for computer‑vision algorithms that require distinct colored lines with contrasting borders to evaluate edge detection performance.
 * 4. When automating the generation of printable schematics in C# where the primary line is emphasized in red and a thin black outline ensures clarity after printing.
 * 5. When building a reporting tool that programmatically draws highlighted trends on a bitmap chart, using a thick red line for the trend and a thin black line for contrast.
 */
