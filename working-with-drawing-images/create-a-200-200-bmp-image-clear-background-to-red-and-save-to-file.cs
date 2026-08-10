// HOW-TO: Create 200x200 Red BMP Image and Save to File in C# (Aspose.Imaging for .NET)
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
            // Output file path
            string outputPath = "output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Create a source bound to the output file
            Source source = new FileCreateSource(outputPath, false);

            // Set up BMP options with the source
            BmpOptions options = new BmpOptions() { Source = source };

            // Create a 200x200 BMP canvas
            using (RasterImage canvas = (RasterImage)Image.Create(options, 200, 200))
            {
                // Clear the canvas to red
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.Red);

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
 * 1. When you need to generate a solid‑color placeholder BMP for a UI component or testing pipeline in a C# application.
 * 2. When an automated report generator must embed a red square thumbnail as a visual marker in a Windows‑compatible bitmap format.
 * 3. When a game development tool requires creating a 200 × 200 red texture on the fly before applying it to a sprite sheet.
 * 4. When a batch image processing script has to produce a red background canvas for later compositing with other layers using Aspose.Imaging.
 * 5. When a legacy system expects a BMP file of a specific size and color, and you need to programmatically create and save it from .NET code.
 */
