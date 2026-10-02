// HOW-TO: How To Set Pen Alignment Inset And Draw Rectangle On BMP In C# (Aspose.Imaging for .NET)
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
            var bmpOptions = new BmpOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };
            using (var image = Image.Create(bmpOptions, 300, 250))
            {
                var graphics = new Graphics(image);
                graphics.Clear(Color.White);
                var pen = new Pen(Color.Black, 5);
                pen.Alignment = PenAlignment.Inset;
                graphics.DrawRectangle(pen, new Rectangle(50, 50, 200, 150));
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
 * 1. When you need to generate a BMP image with a black rectangle whose border stays inside the shape for precise UI mockups.
 * 2. When creating printable graphics where the pen stroke must not extend beyond the rectangle edges to avoid clipping.
 * 3. When testing how different PenAlignment settings affect rectangle rendering using Aspose.Imaging in C#.
 * 4. When programmatically drawing outlines for image annotations that must remain within the target area.
 * 5. When automating the creation of simple black‑on‑white diagrams for documentation or reports.
 */
