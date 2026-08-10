// HOW-TO: Draw a Floating Point Rectangle on PNG Canvas Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
            // Define output path
            string outputPath = @"C:\temp\output.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up PNG options with a file create source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image canvas
            using (Image image = Image.Create(pngOptions, 400, 300))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Define pen and floating-point rectangle
                Pen pen = new Pen(Color.Blue, 2);
                RectangleF rectF = new RectangleF(50.5f, 30.5f, 200.2f, 150.8f);

                // Draw rectangle using RectangleF overload
                graphics.DrawRectangle(pen, rectF);

                // Save the image (output is already bound to the file)
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
 * 1. When you need to generate a PNG image with precisely positioned vector shapes, such as a rectangle defined by sub‑pixel coordinates, for high‑resolution reports or UI mockups.
 * 2. When creating dynamic graphics for a web service that overlays bounding boxes on photos, using floating‑point values to align with scaled image dimensions.
 * 3. When building a CAD‑like preview where rectangle dimensions must reflect real‑world measurements, requiring the RectangleF overload to preserve decimal accuracy.
 * 4. When automating the production of printable assets that require exact margin calculations, drawing rectangles with fractional pixel offsets to avoid visual artifacts.
 * 5. When developing a diagnostic tool that marks regions of interest on screenshots, using a blue pen and floating‑point rectangle to highlight areas without losing precision.
 */
