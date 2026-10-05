// HOW-TO: Blend Semi Transparent Rectangle Over PNG Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var options = new PngOptions();
            options.Source = new FileCreateSource(outputPath, false);
            using (var image = Image.Create(options, 200, 200) as RasterImage)
            {
                int[] whitePixels = Enumerable.Repeat(Color.White.ToArgb(), 200 * 200).ToArray();
                image.SaveArgb32Pixels(new Rectangle(0, 0, 200, 200), whitePixels);

                var graphics = new Graphics(image);

                using (var brush = new SolidBrush(Color.FromArgb(128, 255, 0, 0)))
                {
                    graphics.FillRectangle(brush, new Rectangle(50, 50, 100, 100));
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
 * 1. When you need to overlay a semi‑transparent shape onto a PNG thumbnail for a web UI watermark.
 * 2. When generating dynamic report graphics that require blending colored rectangles with existing pixel data in a .NET application.
 * 3. When creating custom icons where a translucent color layer must be composited over a base image using Aspose.Imaging.
 * 4. When programmatically adding a semi‑opaque highlight to a map tile before saving it as a PNG file.
 * 5. When building a batch image‑processing tool that adds transparent overlays to photos without losing the original background.
 */
