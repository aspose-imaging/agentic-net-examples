// HOW-TO: Merge Multiple JPEG Images Horizontally into One JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputPath = "Output/merged.jpg";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var imageFiles = Directory.GetFiles(inputDirectory, "*.jpg")
                .Concat(Directory.GetFiles(inputDirectory, "*.jpeg"))
                .ToArray();

            if (imageFiles.Length == 0)
            {
                Console.Error.WriteLine("No JPEG files found in the input directory.");
                return;
            }

            var sizes = new List<Aspose.Imaging.Size>();

            foreach (var filePath in imageFiles)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(filePath))
                {
                    sizes.Add(new Aspose.Imaging.Size(img.Width, img.Height));
                }
            }

            int totalWidth = sizes.Sum(s => s.Width);
            int maxHeight = sizes.Max(s => s.Height);

            var source = new FileCreateSource(outputPath, false);
            var options = new JpegOptions() { Source = source, Quality = 100 };

            using (JpegImage canvas = (JpegImage)Aspose.Imaging.Image.Create(options, totalWidth, maxHeight))
            {
                int offsetX = 0;
                foreach (var filePath in imageFiles)
                {
                    using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(filePath))
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
 * 1. When you need to create a side‑by‑side photo collage from a set of JPEG pictures for a marketing email.
 * 2. When generating a single wide banner by stitching product photos stored in a folder for an e‑commerce site.
 * 3. When automating the preparation of before‑and‑after comparison images by placing two JPEGs next to each other.
 * 4. When consolidating scanned document pages saved as JPEGs into one continuous image for archival or printing.
 * 5. When building a thumbnail strip of multiple JPEG thumbnails to display in a gallery view within a desktop application.
 */
