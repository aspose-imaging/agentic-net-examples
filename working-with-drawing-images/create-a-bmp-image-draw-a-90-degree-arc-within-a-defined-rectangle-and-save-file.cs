// HOW-TO: Create BMP Image with 90 Degree Arc Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "arc_output.bmp";

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            int width = 200;
            int height = 200;

            BmpOptions bmpOptions = new BmpOptions();

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                Aspose.Imaging.Rectangle rect = new Aspose.Imaging.Rectangle(20, 20, 160, 160);
                Pen pen = new Pen(Aspose.Imaging.Color.Blue, 3);

                graphics.DrawArc(pen, rect, 0, 90);

                image.Save(outputPath, bmpOptions);
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
 * 1. When you need to generate a BMP thumbnail that includes a quarter‑circle indicator for progress or status in a Windows desktop application.
 * 2. When you want to programmatically draw a 90° blue arc inside a defined rectangle for custom chart markers or gauges in a reporting tool.
 * 3. When you must create a simple bitmap file with vector‑based graphics, such as a logo or badge, without using external design software.
 * 4. When you are building automated tests that verify drawing APIs by creating a BMP file with a known arc shape for pixel‑by‑pixel comparison.
 * 5. When you need to produce a BMP asset containing a precise arc for use in game UI elements or embedded devices that only support BMP format.
 */
