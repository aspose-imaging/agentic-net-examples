// HOW-TO: Create PNG with Filled Blue Rectangle and Thick Black Border in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.png";
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir ?? ".");

            var pngOptions = new PngOptions();

            using (Image image = Image.Create(pngOptions, 200, 200))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                var pen = new Pen(Aspose.Imaging.Color.Black, 5);

                using (var brush = new SolidBrush(Aspose.Imaging.Color.Blue))
                {
                    graphics.FillRectangle(brush, 50, 50, 100, 100);
                    graphics.DrawRectangle(pen, 50, 50, 100, 100);
                }

                image.Save(outputPath, pngOptions);
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
 * 1. When you need to generate a PNG badge or icon that contains a solid blue square with a prominent black outline for a web dashboard.
 * 2. When creating placeholder images for UI mockups where a colored rectangle highlights an area of interest in a C# application.
 * 3. When producing simple printable labels or stickers that require a blue background shape framed by a thick black border using Aspose.Imaging.
 * 4. When generating chart background elements, such as a highlighted region, by drawing a filled rectangle with a contrasting outline in a PNG file.
 * 5. When automating the creation of thumbnail graphics for documentation that need a consistent blue rectangle with a bold black frame.
 */
