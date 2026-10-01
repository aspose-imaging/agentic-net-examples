// HOW-TO: Convert PNG to SVG with 16‑Color Palette in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string tempPath = "temp/temp_palette.png";
            string outputPath = "output/output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(tempPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                PngOptions pngOptions = new PngOptions
                {
                    ColorType = PngColorType.IndexedColor,
                    Palette = ColorPaletteHelper.GetCloseTransparentImagePalette(raster, 16),
                    PngCompressionLevel = PngCompressionLevel.ZipLevel6
                };
                raster.Save(tempPath, pngOptions);
            }

            using (Image img = Image.Load(tempPath))
            {
                SvgOptions svgOptions = new SvgOptions();
                img.Save(outputPath, svgOptions);
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
 * 1. When you need to embed a PNG graphic in a web page as a lightweight SVG with a limited 16‑color palette to reduce file size.
 * 2. When preparing icons for mobile or embedded devices that only support a small number of colors and require vector scalability.
 * 3. When converting legacy PNG assets to SVG for printing on low‑resolution printers while preserving exact color mapping.
 * 4. When generating SVG assets for a game UI where a fixed palette ensures consistent appearance across different platforms.
 * 5. When automating a batch process that transforms user‑uploaded PNG images into SVG files with a reduced palette for faster rendering in browsers.
 */
