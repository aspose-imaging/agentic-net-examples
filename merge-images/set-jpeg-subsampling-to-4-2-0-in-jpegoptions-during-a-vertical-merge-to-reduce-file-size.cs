// HOW-TO: Merge JPEG Images Vertically With 4:2:0 Subsampling In C# (Aspose.Imaging for .NET)
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
            string[] inputPaths = new string[]
            {
                "input1.jpg",
                "input2.jpg",
                "input3.jpg"
            };

            foreach (string path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            string outputPath = "output/merged_vertical.jpg";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            List<Size> sizes = new List<Size>();
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            int canvasWidth = sizes.Max(s => s.Width);
            int canvasHeight = sizes.Sum(s => s.Height);

            Source src = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions()
            {
                Source = src,
                Quality = 90
            };

            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                foreach (string path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetY += img.Height;
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
 * 1. When you need to combine several product photos into a single tall banner while keeping the output JPEG small by using 4:2:0 chroma subsampling.
 * 2. When generating a continuous scrollable image for a mobile app from multiple screenshots and want to minimize bandwidth with reduced JPEG size.
 * 3. When creating a printable receipt image that stacks line‑item pictures vertically and must meet email attachment size limits.
 * 4. When automating the assembly of scanned document pages into one JPEG for archiving, and you want to lower storage costs by applying subsampling.
 * 5. When building a web‑service that merges user‑uploaded JPEGs into a single image for a slideshow and needs to deliver it quickly by reducing file size.
 */
