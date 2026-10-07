// HOW-TO: Rotate PNG 90 Degrees, Blend Transparent Overlay, Save As GIF In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string overlayPath = "overlay.png";
        string outputPath = "output/output.gif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        if (!File.Exists(overlayPath))
        {
            Console.Error.WriteLine($"File not found: {overlayPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (RasterImage baseImage = (RasterImage)Image.Load(inputPath))
            {
                if (!baseImage.IsCached) baseImage.CacheData();

                baseImage.RotateFlip(RotateFlipType.Rotate90FlipNone);

                using (RasterImage overlay = (RasterImage)Image.Load(overlayPath))
                {
                    if (!overlay.IsCached) overlay.CacheData();

                    baseImage.Blend(new Point(0, 0), overlay, 128);
                }

                Source outSource = new FileCreateSource(outputPath, false);
                GifOptions gifOptions = new GifOptions() { Source = outSource };
                baseImage.Save(outputPath, gifOptions);
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
 * 1. When you need to display a rotated product image with a watermark overlay on a website and deliver it as a lightweight GIF.
 * 2. When you want to create animated GIF frames by rotating a base PNG and adding a semi‑transparent logo for branding.
 * 3. When you must convert a scanned PNG diagram to a GIF while applying a 90° rotation and a translucent mask for visual emphasis.
 * 4. When you are generating thumbnail previews that require a specific orientation and a semi‑transparent badge before saving in GIF format.
 * 5. When you need to preprocess images for email newsletters by rotating them, blending a transparent overlay, and exporting as GIF to reduce file size.
 */
