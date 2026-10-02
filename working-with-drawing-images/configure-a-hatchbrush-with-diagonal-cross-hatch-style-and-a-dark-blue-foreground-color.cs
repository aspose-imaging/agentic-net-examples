// HOW-TO: Create 200x200 BMP Image Filled with Dark Blue Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            BmpOptions options = new BmpOptions();
            options.BitsPerPixel = 24;

            using (Image image = Image.Create(options, 200, 200))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                using (SolidBrush solidBrush = new SolidBrush(Color.DarkBlue))
                {
                    graphics.FillRectangle(solidBrush, 0, 0, 200, 200);
                }

                image.Save(outputPath);
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
 * 1. When you need to generate a solid‑color BMP placeholder image for a UI mockup or testing layout rendering.
 * 2. When creating a simple background layer for a game sprite sheet where the base color must be dark blue.
 * 3. When programmatically producing a monochrome thumbnail for a document management system that requires BMP format.
 * 4. When automating the creation of a colored canvas to overlay vector graphics or text in later processing steps.
 * 5. When a batch process must convert a set of images to a uniform 24‑bit BMP with a consistent dark‑blue background for legacy hardware compatibility.
 */
