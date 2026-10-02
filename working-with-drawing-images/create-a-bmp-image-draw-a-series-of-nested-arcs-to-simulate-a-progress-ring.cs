// HOW-TO: Create BMP Progress Ring with Nested Arcs in C# (Aspose.Imaging for .NET)
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
            string outputPath = "progress_ring.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            int width = 200;
            int height = 200;
            int centerX = width / 2;
            int centerY = height / 2;
            int baseRadius = 80;
            int rings = 5;
            int radiusStep = 12;
            int penWidth = 8;

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                for (int i = 0; i < rings; i++)
                {
                    int radius = baseRadius - i * radiusStep;
                    int diameter = radius * 2;
                    int x = centerX - radius;
                    int y = centerY - radius;

                    Pen pen = new Pen(Color.Blue, penWidth);
                    graphics.DrawArc(pen, new Rectangle(x, y, diameter, diameter), 0, 270);
                }

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
 * 1. When you need to generate a BMP file that visualizes a circular progress indicator for a desktop dashboard.
 * 2. When you want to programmatically draw multiple concentric arcs to represent different completion levels in a C# reporting tool.
 * 3. When you are building a custom UI component that requires a static progress ring image without using external graphics libraries.
 * 4. When you need to create a lightweight bitmap thumbnail that shows a progress animation for email attachments or notifications.
 * 5. When you must produce a BMP image with precise pen width and color settings for printing or legacy systems that only accept BMP format.
 */
