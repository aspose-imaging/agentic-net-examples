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
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                MagicWandTool
                    .Select(image, new MagicWandSettings(120, 100) { Threshold = 150 })
                    .Union(new MagicWandSettings(300, 200))
                    .Subtract(new MagicWandSettings(250, 150) { Threshold = 80 })
                    .Apply();

                Graphics graphics = new Graphics(image);
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(128, 255, 0, 0)))
                {
                    graphics.FillRectangle(brush, new Rectangle(0, 0, image.Width, image.Height));
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
 * 1. When a developer needs to programmatically isolate a complex region in a PNG image—combining multiple Magic Wand selections with union and subtraction—and then apply a semi‑transparent red overlay for highlighting or watermarking.
 * 2. When an automated image‑processing pipeline must remove a specific foreground object from a photograph and fill the resulting area with a solid color while preserving the PNG alpha channel using Aspose.Imaging for .NET.
 * 3. When creating custom masks for batch editing of scanned documents, such as selecting multiple text blocks, excluding a logo, and filling the selected area with a colored background to improve readability.
 * 4. When building a C# application that dynamically generates visual cues on map tiles by selecting irregular terrain features with Magic Wand tools, subtracting roads, and overlaying a translucent color to indicate zones.
 * 5. When implementing a photo‑editing feature that lets users programmatically replace skin tones in portrait PNGs by selecting skin regions, excluding eyes with subtraction, and applying a solid brush with adjustable opacity.
 */