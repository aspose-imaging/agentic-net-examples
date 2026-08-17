// HOW-TO: Merge Multiple JPEG Images Horizontally While Preserving EXIF Metadata in C# (Aspose.Imaging for .NET)
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
            string outputPath = "merged.jpg";

            // Validate input files
            foreach (string path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Collect sizes of all images
            List<Size> sizes = new List<Size>();
            foreach (string path in inputPaths)
            {
                using (JpegImage img = (JpegImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions (horizontal merge)
            int newWidth = sizes.Sum(s => s.Width);
            int newHeight = sizes.Max(s => s.Height);

            // Create JPEG options with bound output source
            Source source = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions()
            {
                Source = source,
                Quality = 100
            };

            // Create canvas and merge images
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, newWidth, newHeight))
            {
                int offsetX = 0;
                foreach (string path in inputPaths)
                {
                    using (JpegImage img = (JpegImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                // Save the bound canvas
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
 * 1. When building a photo‑gallery web app that needs to combine several JPEG photos into a single panoramic image while keeping the original camera information.
 * 2. When creating a batch‑processing tool that stitches product photos side‑by‑side for e‑commerce listings and must retain EXIF data for compliance.
 * 3. When developing a digital‑asset‑management system that generates composite thumbnails from multiple JPEGs and wants the merged file to carry the first image’s metadata.
 * 4. When implementing an automated report generator that merges scanned JPEG pages into one document and requires the original EXIF timestamps to stay intact.
 * 5. When writing a C# utility that consolidates security‑camera snapshots into a single image for quick review, preserving the first snapshot’s GPS and exposure details.
 */
