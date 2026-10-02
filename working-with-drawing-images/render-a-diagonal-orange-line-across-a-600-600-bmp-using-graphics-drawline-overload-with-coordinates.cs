// HOW-TO: Draw Diagonal Orange Line on 600x600 BMP Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.bmp";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            var bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24
            };

            using (var image = Image.Create(bmpOptions, 600, 600))
            {
                var graphics = new Graphics(image);
                var pen = new Pen(Color.Orange);
                graphics.DrawLine(pen, 0, 0, 600, 600);
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
 * 1. When you need to programmatically add a simple diagonal watermark to a BMP file for branding or identification purposes.
 * 2. When generating test images that contain a known geometric shape to validate image‑processing algorithms in C#.
 * 3. When creating placeholder graphics for UI mockups where a colored line demonstrates layout dimensions.
 * 4. When automating the production of batch‑processed BMP assets that require a consistent orange guide line across each image.
 * 5. When teaching beginners how to use Aspose.Imaging’s Graphics.DrawLine method to draw basic shapes on raster images.
 */
