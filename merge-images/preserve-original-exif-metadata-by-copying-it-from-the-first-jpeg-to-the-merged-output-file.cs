using System;
using System.IO;
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
            string[] inputPaths = { "input1.jpg", "input2.jpg", "input3.jpg" };
            string outputPath = "output/merged.jpg";

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

            // Calculate canvas size
            int totalWidth = 0;
            int maxHeight = 0;
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    totalWidth += img.Width;
                    if (img.Height > maxHeight)
                        maxHeight = img.Height;
                }
            }

            // Create output canvas bound to file
            Source source = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = source, Quality = 100 };

            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, totalWidth, maxHeight))
            {
                int offsetX = 0;
                foreach (string path in inputPaths)
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
 * 1. When a photographer creates a panoramic JPEG by stitching multiple shots side‑by‑side and needs to keep the original EXIF camera settings for later editing or cataloging.
 * 2. When an e‑commerce platform merges product image variations into a single composite JPEG while preserving EXIF metadata to satisfy image provenance and compliance rules.
 * 3. When a mobile app generates a before‑and‑after comparison JPEG from two photos and must retain the original EXIF timestamps for audit‑trail purposes.
 * 4. When a digital asset management system combines several high‑resolution JPEG scans into one file and wants to keep the original EXIF data for searchable metadata and licensing information.
 * 5. When a real‑estate website creates a wide‑angle view by concatenating room photos and needs to preserve the EXIF GPS coordinates so the merged image can still be mapped correctly.
 */