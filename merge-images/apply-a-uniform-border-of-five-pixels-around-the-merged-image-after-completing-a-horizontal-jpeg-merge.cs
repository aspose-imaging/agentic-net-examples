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
                "input1.jpg",
                "input2.jpg",
                "input3.jpg"
            };
            string outputPath = "merged_with_border.jpg";

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

            // Collect sizes of all input images
            List<Size> sizes = new List<Size>();
            foreach (string inputPath in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(inputPath))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas size with a 5‑pixel border on all sides
            int border = 5;
            int totalWidth = sizes.Sum(s => s.Width);
            int maxHeight = sizes.Max(s => s.Height);
            int canvasWidth = totalWidth + 2 * border;
            int canvasHeight = maxHeight + 2 * border;

            // Create JPEG canvas bound to the output file
            Source source = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = source, Quality = 100 };

            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetX = border;
                foreach (string inputPath in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(inputPath))
                    {
                        Rectangle bounds = new Rectangle(offsetX, border, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                // Save the bound image (output file)
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
 * 1. When creating a product catalog page where multiple product photos need to be displayed side‑by‑side in a single JPEG with a uniform 5‑pixel border for visual separation.
 * 2. When generating a printable photo strip for a photo‑booth application that stitches several JPEG snapshots horizontally and adds a thin border to frame the combined image.
 * 3. When preparing a web‑ready banner that combines several promotional JPEG images into one horizontal strip and requires a consistent border to match the site’s design guidelines.
 * 4. When automating the assembly of scanned document pages saved as JPEGs into a single wide image for archival, with a border added to prevent content from touching the canvas edges.
 * 5. When building a C# desktop tool that merges user‑selected JPEG screenshots into a single image for bug‑report submissions, adding a 5‑pixel border to improve readability in the final attachment.
 */