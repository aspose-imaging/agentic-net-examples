// HOW-TO: Draw Pixel‑Perfect Horizontal Lines on BMP Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
        string outputPath = "output/output.bmp";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            int width = 200;
            int height = 100;

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (Image canvas = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.White);

                Pen pen = new Pen(Color.Black, 1);

                for (int y = 0; y < height; y += 10)
                {
                    graphics.DrawLine(pen, 0, y, width - 1, y);
                }

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
 * 1. When you need to generate a BMP grid or ruler overlay where each line aligns exactly with pixel rows for a technical diagram.
 * 2. When creating a printable form template in C# that requires crisp horizontal separators on a bitmap background.
 * 3. When producing a simple barcode or scan line image where precise horizontal lines are essential for accurate scanning.
 * 4. When building a game UI element such as a health bar or progress meter that uses evenly spaced horizontal lines on a BMP sprite.
 * 5. When automating the creation of test images to validate image‑processing algorithms that expect exact pixel‑aligned horizontal lines.
 */
