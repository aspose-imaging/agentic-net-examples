// HOW-TO: Merge Multiple JPEG Images Horizontally Using FileStream In C# (Aspose.Imaging for .NET)
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
            string[] inputPaths = new string[] { "image1.jpg", "image2.jpg", "image3.jpg" };
            string outputPath = "merged.jpg";

            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            List<Size> sizes = new List<Size>();
            foreach (string inputPath in inputPaths)
            {
                using (FileStream fs = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
                {
                    using (RasterImage img = (RasterImage)Image.Load(fs))
                    {
                        sizes.Add(new Size(img.Width, img.Height));
                    }
                }
            }

            int totalWidth = sizes.Sum(s => s.Width);
            int maxHeight = sizes.Max(s => s.Height);

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            Source src = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = src, Quality = 100 };

            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, totalWidth, maxHeight))
            {
                int offsetX = 0;
                foreach (string inputPath in inputPaths)
                {
                    using (FileStream fs = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
                    {
                        using (RasterImage img = (RasterImage)Image.Load(fs))
                        {
                            Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                            canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                            offsetX += img.Width;
                        }
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
 * 1. When you need to create a single panoramic JPEG from several individual photos in a .NET batch job.
 * 2. When an e‑commerce platform must combine product thumbnail images side‑by‑side for a catalog preview.
 * 3. When a reporting tool generates a combined image of multiple charts saved as JPEGs for a PDF export.
 * 4. When a digital signage system stitches advertisement banners horizontally before displaying them on a screen.
 * 5. When a migration script consolidates scanned document pages stored as separate JPEG files into one wide image for archival.
 */
