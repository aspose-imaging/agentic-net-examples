// HOW-TO: Merge Multiple JPEG Images Horizontally Into a PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] inputPaths = new string[] { "image1.jpg", "image2.jpg", "image3.jpg" };
            string outputPath = "merged.png";

            foreach (var path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
            foreach (var path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(new Aspose.Imaging.Size(img.Width, img.Height));
                }
            }

            int totalWidth = sizes.Sum(s => s.Width);
            int maxHeight = sizes.Max(s => s.Height);

            Source outSource = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions() { Source = outSource };
            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, totalWidth, maxHeight))
            {
                int offsetX = 0;
                foreach (var path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
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
 * 1. When you need to combine several high‑resolution JPEG photos into a single panoramic PNG for web galleries without loading the entire images into memory.
 * 2. When an e‑commerce platform must create a side‑by‑side product comparison image from multiple JPEG thumbnails and output a PNG for consistent background.
 * 3. When a reporting tool generates a composite image of chart screenshots stored as JPEGs and saves the merged result as a lossless PNG for PDF embedding.
 * 4. When a mobile app server stitches user‑uploaded JPEG screenshots into a single banner PNG while controlling memory consumption using Aspose.Imaging.
 * 5. When an automated batch process creates a horizontal strip of JPEG frames for video sprite sheets and exports it as a PNG for CSS sprite usage.
 */
