// HOW-TO: Blend PNG Overlay onto Background with Full Opacity in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

namespace AlphaBlendExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string backgroundPath = "background.png";
                string overlayPath = "overlay.png";
                string outputPath = "output.png";

                if (!File.Exists(backgroundPath))
                {
                    Console.Error.WriteLine($"File not found: {backgroundPath}");
                    return;
                }
                if (!File.Exists(overlayPath))
                {
                    Console.Error.WriteLine($"File not found: {overlayPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

                using (RasterImage background = (RasterImage)Image.Load(backgroundPath))
                using (RasterImage overlay = (RasterImage)Image.Load(overlayPath))
                {
                    int x = (background.Width - overlay.Width) / 2;
                    int y = (background.Height - overlay.Height) / 2;
                    var point = new Point(x, y);
                    var rect = new Rectangle(0, 0, overlay.Width, overlay.Height);
                    background.Blend(point, overlay, rect, 255);

                    var options = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        CompressionLevel = 9
                    };
                    background.Save(outputPath, options);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to combine a logo PNG over a photo without losing its alpha channel.
 * 2. When you want to programmatically place a watermark PNG at the center of an image in a .NET application.
 * 3. When you must generate composite PNGs for web assets while preserving transparency and applying maximum compression.
 * 4. When you are building an automated batch process that merges UI icons onto screenshots for documentation.
 * 5. When you need to ensure that a fully opaque overlay does not introduce unintended transparency in the final PNG file.
 */
