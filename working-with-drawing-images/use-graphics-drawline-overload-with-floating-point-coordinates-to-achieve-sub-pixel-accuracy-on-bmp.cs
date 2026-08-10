// HOW-TO: Draw Subpixel Accurate Line on BMP Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output BMP file path
            string outputPath = "output/output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP options with a file create source bound to the output path
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 200x200 BMP image
            using (Image image = Image.Create(bmpOptions, 200, 200))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Clear background to white
                graphics.Clear(Color.White);

                // Pen with sub‑pixel width for higher accuracy
                Pen pen = new Pen(Color.Black, 1.5f);

                // Draw a line using floating‑point coordinates (sub‑pixel precision)
                graphics.DrawLine(pen, 10.5f, 10.5f, 150.75f, 150.25f);

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
 * 1. When you need to generate a high‑resolution BMP diagram where thin lines must appear smooth and precisely positioned, such as technical schematics or UI mockups.
 * 2. When creating raster graphics for printing that require sub‑pixel line placement to avoid aliasing, like vector‑to‑bitmap conversion for brochures.
 * 3. When developing a reporting tool that overlays measurement lines on scanned BMP images and demands floating‑point accuracy for exact scale representation.
 * 4. When building a game asset pipeline that draws pixel‑perfect borders on BMP textures, ensuring consistent line thickness across different screen densities.
 * 5. When automating the production of BMP assets for scientific visualizations where line coordinates come from floating‑point data sets and must be rendered without rounding errors.
 */
