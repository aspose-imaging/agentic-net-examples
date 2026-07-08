using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPngPath = "input.png";
            string overlayPath = "overlay.png";
            string outputGifPath = "output.gif";

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

            using (Aspose.Imaging.RasterImage baseImage = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPngPath))
            {
                baseImage.Rotate(90f, true, Aspose.Imaging.Color.White);

                using (Aspose.Imaging.RasterImage overlayImage = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(overlayPath))
                {
                    baseImage.Blend(new Aspose.Imaging.Point(0, 0), overlayImage, 128);
                }

                GifOptions gifOptions = new GifOptions();
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
 * 1. When creating animated web banners that need a rotated base image with a semi‑transparent logo overlay before converting to GIF for browser compatibility.
 * 2. When generating product thumbnails where the original PNG must be rotated to portrait orientation, blended with a watermark overlay at 50 % opacity, and saved as a lightweight GIF for e‑commerce listings.
 * 3. When preparing social‑media share images that require a 90‑degree rotation of a screenshot PNG, adding a translucent call‑to‑action overlay, and exporting to GIF to meet platform size limits.
 * 4. When building a desktop reporting tool that rotates scanned PNG diagrams, applies a semi‑transparent grid overlay for visual reference, and stores the result as a GIF for inclusion in PDF reports.
 * 5. When developing a game asset pipeline that reorients character sprites (PNG), blends a semi‑transparent effect layer, and outputs GIF frames for animation sequences.
 */