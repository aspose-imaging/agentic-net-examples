using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath, new Aspose.Imaging.ImageLoadOptions.SvgLoadOptions()))
            {
                var pngOptions = new PngOptions();
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
 * 1. When a web service converts user‑uploaded SVG icons to PNG thumbnails and must handle corrupted or missing SVG files without crashing.
 * 2. When an automated build pipeline generates PNG assets from SVG design files and needs to log load failures for debugging.
 * 3. When a desktop application allows users to export vector drawings as raster PNGs and must report file‑not‑found or parsing errors.
 * 4. When a batch script processes a folder of SVG logos into PNGs for email signatures and must record any format‑specific exceptions.
 * 5. When a cloud function transforms SVG charts into PNG images for reporting and requires detailed error logging to troubleshoot malformed SVG content.
 */