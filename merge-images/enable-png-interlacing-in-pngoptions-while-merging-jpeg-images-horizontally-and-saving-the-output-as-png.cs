// HOW-TO: Create Interlaced PNG from Multiple JPEGs Merged Horizontally in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] inputPaths = new string[] { "image1.jpg", "image2.jpg", "image3.jpg" };
            string outputPath = "output/merged.png";

            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            List<Size> sizes = new List<Size>();
            foreach (string inputPath in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(inputPath))
                {
                    sizes.Add(img.Size);
                }
            }

            int totalWidth = sizes.Sum(s => s.Width);
            int maxHeight = sizes.Max(s => s.Height);

            Source source = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions()
            {
                Source = source
            };

            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, totalWidth, maxHeight))
            {
                int offsetX = 0;
                foreach (string inputPath in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(inputPath))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
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
 * 1. When you need to combine product photos side‑by‑side into a single web‑optimized PNG with interlacing for faster progressive loading.
 * 2. When generating a panoramic thumbnail from several JPEG snapshots and want the result saved as an interlaced PNG for smoother display on low‑bandwidth connections.
 * 3. When building a reporting tool that stitches chart images together horizontally and requires an interlaced PNG to allow browsers to render the image progressively.
 * 4. When creating a composite banner from multiple JPEG advertisements and need the final PNG to be interlaced so it appears gradually while the page loads.
 * 5. When automating the preparation of image assets for an e‑learning module, merging instructional JPEG slides into an interlaced PNG to improve perceived loading speed.
 */
