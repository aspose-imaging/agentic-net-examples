// HOW-TO: Create BMP Image with Navy Background and White Diagonal Cross in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            int width = 200;
            int height = 200;

            BmpOptions options = new BmpOptions();
            options.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.Navy);

                Pen pen = new Pen(Color.White, 1);
                graphics.DrawLine(pen, new Point(0, 0), new Point(width - 1, height - 1));
                graphics.DrawLine(pen, new Point(0, height - 1), new Point(width - 1, 0));

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
 * 1. When you need to generate a simple BMP flag or emblem with a navy field and a white X for a desktop application.
 * 2. When creating placeholder images for UI testing that require a specific size, background color, and diagonal cross pattern.
 * 3. When programmatically producing icons for games or tools that use a navy background with a white cross to indicate a “cancel” or “reset” symbol.
 * 4. When automating the batch creation of watermark overlays in BMP format that consist of a colored background and intersecting lines.
 * 5. When demonstrating basic drawing operations with Aspose.Imaging, such as clearing a canvas and drawing lines, for educational tutorials or documentation.
 */
