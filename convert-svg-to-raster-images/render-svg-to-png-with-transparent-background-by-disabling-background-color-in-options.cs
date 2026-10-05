// HOW-TO: Convert SVG to PNG with Transparent Background Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                PngOptions pngOptions = new PngOptions();
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
 * 1. When you need to generate web‑ready PNG icons from scalable SVG graphics while preserving transparency for overlay on different backgrounds.
 * 2. When an e‑commerce platform must convert product vector illustrations into PNG thumbnails that can be displayed over varied UI themes without a solid background.
 * 3. When a reporting tool creates charts as SVG and you need to embed them in PDF or Word documents that require PNG images with transparent backgrounds.
 * 4. When a mobile app builds custom stickers from SVG assets and must export them as PNG files that blend seamlessly with user photos.
 * 5. When an automated build pipeline processes design assets, converting SVG logos to transparent PNGs for use in email signatures and marketing materials.
 */
