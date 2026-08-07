using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPngPath = "input.png";
            string overlayPath = "overlay.png";
            string outputGifPath = "Output/output.gif";

            if (!File.Exists(inputPngPath))
            {
                Console.Error.WriteLine($"File not found: {inputPngPath}");
                return;
            }
            if (!File.Exists(overlayPath))
            {
                Console.Error.WriteLine($"File not found: {overlayPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputGifPath));

            using (RasterImage baseImage = (RasterImage)Image.Load(inputPngPath))
            {
                baseImage.RotateFlip(RotateFlipType.Rotate90FlipNone);

                using (RasterImage overlayImage = (RasterImage)Image.Load(overlayPath))
                {
                    baseImage.Blend(new Point(0, 0), overlayImage, 128);
                }

                GifOptions gifOptions = new GifOptions
                {
                    Source = new FileCreateSource(outputGifPath, false)
                };
                baseImage.Save(outputGifPath, gifOptions);
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
 * 1. When creating animated web banners that require a portrait‑oriented PNG to be rotated to landscape, overlaid with a semi‑transparent logo, and delivered as a lightweight GIF for browser compatibility.
 * 2. When generating product thumbnails for an e‑commerce site where the original PNG image must be rotated 90°, combined with a translucent promotional badge, and saved as a GIF to reduce file size.
 * 3. When preparing printable QR‑code stickers that need the code image rotated, blended with a faint watermark, and exported as a GIF for use in legacy printing workflows.
 * 4. When building a mobile game asset pipeline that rotates character sprites, applies a semi‑transparent effect overlay, and outputs GIF frames for animation sequences.
 * 5. When automating the creation of email newsletters that embed rotated PNG graphics with a translucent call‑to‑action overlay, saved as GIFs to ensure consistent rendering across email clients.
 */