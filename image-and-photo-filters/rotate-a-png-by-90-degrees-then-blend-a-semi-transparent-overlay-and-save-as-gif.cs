// HOW-TO: Rotate PNG 90 Degrees, Add Transparent Overlay, Save as GIF in C# (Aspose.Imaging for .NET)
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
        string inputPath = "input.png";
        string outputPath = "output/output.gif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage baseImage = (RasterImage)Image.Load(inputPath))
            {
                if (!baseImage.IsCached)
                    baseImage.CacheData();

                baseImage.Rotate(90f, true, Color.White);

                Source overlaySource = new FileCreateSource("overlay_temp.png", false);
                PngOptions overlayOptions = new PngOptions() { Source = overlaySource };
                using (RasterImage overlayImage = (RasterImage)Image.Create(overlayOptions, baseImage.Width, baseImage.Height))
                {
                    Graphics graphics = new Graphics(overlayImage);
                    graphics.Clear(Color.FromArgb(128, 255, 0, 0));

                    baseImage.Blend(new Point(0, 0), overlayImage, 128);
                }

                GifOptions gifOptions = new GifOptions() { Source = new FileCreateSource(outputPath, false) };
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
 * 1. When you need to rotate a product photo, apply a semi‑transparent color tint, and output it as a GIF for faster web delivery.
 * 2. When generating a series of rotated icons with a consistent overlay for a mobile app’s splash screen in C#.
 * 3. When converting scanned PNG documents that must be displayed in landscape orientation with a watermark overlay and saved as GIF for email attachments.
 * 4. When creating animated GIF frames that require each frame to be rotated and blended with a translucent overlay before assembling the animation.
 * 5. When a legacy system only accepts GIF images, and you must preprocess PNG assets by rotating them and adding a transparent overlay using Aspose.Imaging in .NET.
 */
