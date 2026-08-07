using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] inputPaths = new[] { "input1.jpg", "input2.jpg", "input3.jpg" };

            foreach (var inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            List<Size> sizes = new List<Size>();
            foreach (var path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            int newWidth = sizes.Sum(s => s.Width);
            int newHeight = sizes.Max(s => s.Height);

            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string baseName = Path.GetFileNameWithoutExtension(inputPaths[0]);
            string outputPath = Path.Combine("Output", $"{baseName}_{timestamp}.jpg");

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            Source source = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = source, Quality = 90 };

            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, newWidth, newHeight))
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
 * 1. When a developer needs to combine multiple product photos into a single panoramic JPEG for an e‑commerce catalog and keep each version uniquely identified by a timestamped filename.
 * 2. When an automated reporting tool must stitch together daily screenshot images into one JPEG report and store it with a time‑stamped name to avoid overwriting previous reports.
 * 3. When a photo‑management application wants to merge user‑selected images into a collage and generate an output file whose name includes the current date and time for easy sorting.
 * 4. When a batch‑processing script processes scanned document pages, merges them horizontally into a single JPEG, and saves the result with a timestamp to track processing order.
 * 5. When a content‑delivery pipeline creates a composite banner image from several source JPEGs and needs a unique, time‑based filename for cache‑busting on web servers.
 */