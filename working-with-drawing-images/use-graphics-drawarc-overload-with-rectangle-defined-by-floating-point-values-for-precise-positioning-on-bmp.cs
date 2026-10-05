// HOW-TO: Draw Precise Arc on BMP Using Graphics.DrawArc with Float Rectangle in C# (Aspose.Imaging for .NET)
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
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");
            BmpOptions options = new BmpOptions();
            options.Source = new FileCreateSource(outputPath, false);
            int width = 400;
            int height = 300;
            using (Image image = Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);
                RectangleF rect = new RectangleF(50.5f, 40.5f, 200.75f, 150.25f);
                Pen pen = new Pen(Color.Blue, 2);
                graphics.DrawArc(pen, rect, 30f, 120f);
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
 * 1. When you need to generate a bitmap diagram with a precisely positioned curved line, such as a gauge or speedometer needle, you can use this code.
 * 2. When creating custom icons or UI elements that require sub‑pixel accuracy for arcs in a BMP file, the floating‑point rectangle ensures exact placement.
 * 3. When exporting engineering schematics to BMP where arc dimensions must match real‑world measurements, the code provides pixel‑perfect rendering.
 * 4. When automating report graphics that include semi‑circular progress bars in BMP format, you can draw the arcs with the specified start and sweep angles.
 * 5. When building a server‑side image service that produces BMP thumbnails with decorative arcs, the Aspose.Imaging Graphics API lets you draw them with high precision.
 */
