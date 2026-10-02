// HOW-TO: Merge Multiple JPEG Images Horizontally Into a PNG With C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
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

            foreach (var inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
            foreach (var inputPath in inputPaths)
            {
                using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
                {
                    sizes.Add(new Aspose.Imaging.Size(img.Width, img.Height));
                }
            }

            int newWidth = sizes.Sum(s => s.Width);
            int newHeight = sizes.Max(s => s.Height);

            var source = new FileCreateSource(outputPath, false);
            PngOptions options = new PngOptions() { Source = source };
            using (Aspose.Imaging.RasterImage canvas = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Create(options, newWidth, newHeight))
            {
                int offsetX = 0;
                foreach (var inputPath in inputPaths)
                {
                    using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
                    {
                        var bounds = new Aspose.Imaging.Rectangle(offsetX, 0, img.Width, img.Height);
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
 * 1. When you need to create a single panoramic thumbnail from several JPEG product photos for an e‑commerce catalog and store it as a PNG.
 * 2. When you want to combine scanned JPEG receipts side by side into one PNG file for easier archival and printing.
 * 3. When a web application must display a series of JPEG screenshots as one continuous image without losing transparency, saving the result as PNG.
 * 4. When generating a composite banner from multiple JPEG advertisements to embed in a PNG email newsletter.
 * 5. When automating the preparation of side‑by‑side before‑and‑after JPEG comparisons and exporting them as a lossless PNG for documentation.
 */
