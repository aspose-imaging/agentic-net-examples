// HOW-TO: How to Reset Clipping Region After Drawing with Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.bmp";
            string outputPath = "output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                Graphics graphics = new Graphics(image);

                // Set clipping region
                graphics.Clip = new Region(new Rectangle(50, 50, 100, 100));

                // Draw within clipped area
                Pen pen = new Pen(Color.Blue, 3);
                graphics.DrawRectangle(pen, new Rectangle(0, 0, 200, 200));

                // Reset clipping region
                graphics.Clip = null;

                // Draw after resetting clip
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(128, Color.Red)))
                {
                    graphics.FillRectangle(brush, new Rectangle(150, 150, 100, 100));
                }

                // Save the modified image
                BmpOptions saveOptions = new BmpOptions();
                image.Save(outputPath, saveOptions);
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
 * 1. When you need to draw a shape only inside a specific area of a BMP and then continue drawing on the full image without the previous clip constraints.
 * 2. When you want to apply a semi‑transparent overlay after limiting earlier drawing operations to a rectangular region.
 * 3. When generating a composite bitmap where the first layer is confined to a mask and subsequent layers require the original canvas size.
 * 4. When creating a template that draws a border inside a defined region and then adds background shading across the entire image.
 * 5. When processing scanned images and need to annotate a focused region first, then add watermarks that cover the whole picture.
 */
