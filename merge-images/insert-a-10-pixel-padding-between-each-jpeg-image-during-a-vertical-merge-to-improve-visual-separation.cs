// HOW-TO: Merge Multiple JPEGs Vertically with 10 Pixel Padding in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
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
            // Hardcoded input and output paths
            string[] inputPaths = new string[]
            {
                "image1.jpg",
                "image2.jpg",
                "image3.jpg"
            };
            string outputPath = "merged.jpg";

            // Validate input files
            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            const int padding = 10;
            List<Size> sizes = new List<Size>();

            // First pass: collect image sizes
            foreach (string inputPath in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(inputPath))
                {
                    sizes.Add(img.Size);
                }
            }

            int maxWidth = sizes.Max(s => s.Width);
            int totalHeight = sizes.Sum(s => s.Height) + padding * (sizes.Count - 1);

            // Create JPEG canvas with bound output
            JpegOptions jpegOptions = new JpegOptions()
            {
                Source = new FileCreateSource(outputPath, false),
                Quality = 100
            };

            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, maxWidth, totalHeight))
            {
                int offsetY = 0;
                foreach (string inputPath in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(inputPath))
                    {
                        Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetY += img.Height + padding;
                    }
                }

                // Save the bound image
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
 * 1. When you need to combine several product photos into a single vertical strip for an online catalog and want a clear 10‑pixel gap between each JPEG image.
 * 2. When creating a printable receipt that merges scanned JPEG receipts into one page while preserving visual separation for easy reading.
 * 3. When generating a vertical sprite sheet of UI icons stored as JPEG files and require consistent padding to prevent icon overlap.
 * 4. When assembling a timeline of event screenshots into one JPEG image for a report, adding spacing to distinguish each screenshot.
 * 5. When building a PDF cover page by merging multiple JPEG banners and need uniform gaps to maintain a clean layout.
 */
