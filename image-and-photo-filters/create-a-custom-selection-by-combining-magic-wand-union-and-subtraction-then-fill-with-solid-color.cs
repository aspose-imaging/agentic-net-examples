// HOW-TO: Create Custom Magic Wand Selection with Union and Subtraction in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;
using Aspose.Imaging.Brushes;

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

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                MagicWandTool.Select(image, new MagicWandSettings(100, 100))
                    .Union(new MagicWandSettings(200, 200))
                    .Subtract(new MagicWandSettings(150, 150) { Threshold = 30 })
                    .Apply();

                Graphics graphics = new Graphics(image);
                using (SolidBrush brush = new SolidBrush(Color.Red))
                {
                    graphics.FillRectangle(brush, new RectangleF(0, 0, image.Width, image.Height));
                }

                image.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
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
 * 1. When you need to programmatically isolate complex regions in a PNG image by merging and removing areas using Aspose.Imaging's Magic Wand tool.
 * 2. When you want to generate a mask that combines multiple color‑based selections and then apply a uniform solid‑color overlay for branding or highlighting.
 * 3. When an automated image‑processing pipeline must remove background sections with a specific tolerance and fill the remaining canvas with a solid color.
 * 4. When creating custom graphics for UI assets where you need to select irregular shapes, subtract unwanted parts, and repaint the whole image in C#.
 * 5. When converting scanned documents to PNG while applying a red fill to the selected content to emphasize regions for review.
 */
