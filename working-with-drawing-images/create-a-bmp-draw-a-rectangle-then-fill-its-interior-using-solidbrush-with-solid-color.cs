// HOW-TO: Create BMP Image With Filled Rectangle Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output/output.bmp";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions options = new BmpOptions();
            options.Source = new FileCreateSource(outputPath, false);

            int width = 200;
            int height = 200;

            using (Image image = Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                int rectX = 50;
                int rectY = 50;
                int rectWidth = 100;
                int rectHeight = 100;
                Rectangle rect = new Rectangle(rectX, rectY, rectWidth, rectHeight);

                Pen pen = new Pen(Color.Black, 2);
                graphics.DrawRectangle(pen, rect);

                using (SolidBrush brush = new SolidBrush(Color.LightBlue))
                {
                    graphics.FillRectangle(brush, rect);
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
 * 1. When you need to generate a BMP file that contains a colored rectangle for a simple report thumbnail.
 * 2. When you want to programmatically highlight a specific area on a bitmap by drawing and filling a rectangle in a C# application.
 * 3. When you are creating test images with a known shape and solid color to validate image‑processing algorithms.
 * 4. When you must produce a BMP annotation that marks a region of interest with a solid fill for medical or engineering diagrams.
 * 5. When you are automating the creation of placeholder graphics for a game map where a filled rectangle defines a zone boundary.
 */
