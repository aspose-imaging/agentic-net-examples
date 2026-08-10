// HOW-TO: Create BMP Image With Outlined Line Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path (hardcoded)
            string outputPath = "output/output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a file source bound to the output path
            Source source = new FileCreateSource(outputPath, false);

            // BMP options with the bound source
            BmpOptions bmpOptions = new BmpOptions() { Source = source };

            // Create a BMP canvas of size 200x200
            using (BmpImage canvas = (BmpImage)Image.Create(bmpOptions, 200, 200))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(canvas);

                // Draw a thick black line
                Pen blackPen = new Pen(Color.Black, 10);
                graphics.DrawLine(blackPen, 20, 20, 180, 180);

                // Overlay a thinner white line for outline effect
                Pen whitePen = new Pen(Color.White, 2);
                graphics.DrawLine(whitePen, 20, 20, 180, 180);

                // Save the bound image
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
 * 1. When you need to programmatically generate a BMP diagram that includes a thick black line with a white outline for UI icons or simple graphics.
 * 2. When you want to add a contrasting white border to a black line in a bitmap to improve visibility on dark or colored backgrounds.
 * 3. When creating test images for computer‑vision or OCR systems that require a clear black stroke surrounded by a thin white edge.
 * 4. When producing custom graphics for embedded devices that only support BMP files and need a highlighted line for status indicators.
 * 5. When automating the creation of printable schematics where a white outline emphasizes the primary black line for better print clarity.
 */
