using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string[] inputPaths = new string[]
        {
            "image1.jpg",
            "image2.jpg",
            "image3.jpg"
        };
        string outputPath = "merged.png";

        try
        {
            List<string> validPaths = new List<string>();
            List<Size> sizes = new List<Size>();

            foreach (string path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }

                using (Image img = Image.Load(path))
                {
                    sizes.Add(new Size(img.Width, img.Height));
                }

                validPaths.Add(path);
            }

            int totalWidth = sizes.Sum(s => s.Width);
            int maxHeight = sizes.Max(s => s.Height);

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            Source source = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions() { Source = source };

            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, totalWidth, maxHeight))
            {
                int offsetX = 0;

                for (int i = 0; i < validPaths.Count; i++)
                {
                    string path = validPaths[i];

                    using (Image img = Image.Load(path))
                    {
                        img.RotateFlip(RotateFlipType.RotateNoneFlipX);
                        RasterImage raster = (RasterImage)img;

                        Rectangle destRect = new Rectangle(offsetX, 0, raster.Width, raster.Height);
                        canvas.SaveArgb32Pixels(destRect, raster.LoadArgb32Pixels(raster.Bounds));
                    }

                    offsetX += sizes[i].Width;
                }

                canvas.Save();
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
 * 1. When creating a product catalog web page, a developer can use this C# Aspose.Imaging code to horizontally flip each JPEG photo of a product, stitch them side‑by‑side, and export the combined view as a high‑quality PNG for faster browser rendering.
 * 2. When generating a before‑and‑after comparison for a photo‑editing app, the code flips the original JPEG images, aligns them in a single horizontal strip, and saves the result as a PNG to preserve lossless quality for display in the UI.
 * 3. When preparing a printable marketing banner that requires mirrored images for symmetrical design, a C# developer can apply RotateFlip on each JPEG, merge them into one horizontal layout, and output a PNG that retains exact color fidelity.
 * 4. When building an automated image‑processing pipeline that consolidates multiple user‑uploaded JPEG selfies into a single panoramic PNG thumbnail, this Aspose.Imaging snippet flips each photo, concatenates them horizontally, and creates a web‑optimized PNG file.
 * 5. When developing a digital signage system that needs to show a series of mirrored JPEG advertisements in a single slide, the code flips each image, arranges them side‑by‑side, and exports the composite as a PNG for seamless playback on the display hardware.
 */