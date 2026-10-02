// HOW-TO: Merge Multiple JPEG Images Vertically With Quality 85 In C# (Aspose.Imaging for .NET)
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

            foreach (var path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            List<int> widths = new List<int>();
            List<int> heights = new List<int>();

            foreach (var path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    widths.Add(img.Width);
                    heights.Add(img.Height);
                }
            }

            int canvasWidth = widths.Max();
            int canvasHeight = heights.Sum();

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            Source source = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = source, Quality = 85 };

            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                foreach (var path in inputPaths)
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
 * 1. When you need to combine several product photos into a single tall JPEG for a catalog while keeping a specific compression quality of 85.
 * 2. When generating a continuous scrollable banner from multiple advertisement images and want the final JPEG to have consistent quality for web delivery.
 * 3. When creating a printable receipt that stacks scanned pages vertically and requires a controlled JPEG quality to balance file size and readability.
 * 4. When assembling a series of screenshots into one image for bug reports, ensuring the output JPEG uses a defined quality level to avoid loss of detail.
 * 5. When preprocessing images for a machine‑learning pipeline that expects a single JPEG input with a known quality setting, merging the source images vertically before inference.
 */
