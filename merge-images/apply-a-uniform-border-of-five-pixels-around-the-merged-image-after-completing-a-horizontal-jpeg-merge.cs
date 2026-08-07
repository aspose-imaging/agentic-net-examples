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
            string[] inputPaths = new[] { "input1.jpg", "input2.jpg", "input3.jpg" };
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
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Collect dimensions
            var dimensions = new List<(int Width, int Height)>();
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    dimensions.Add((img.Width, img.Height));
                }
            }

            int totalWidth = 0;
            int maxHeight = 0;
            foreach (var dim in dimensions)
            {
                totalWidth += dim.Width;
                if (dim.Height > maxHeight) maxHeight = dim.Height;
            }

            // Create output source and options
            Source outputSource = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = outputSource, Quality = 100 };

            // Create canvas
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, totalWidth, maxHeight))
            {
                int offsetX = 0;
                foreach (string path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        var bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                // Save the merged image (canvas is already bound to output source)
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
 * 1. When a developer needs to combine multiple JPEG photos side‑by‑side and add a 5‑pixel white border for a consistent look in an online product catalog using C# and Aspose.Imaging.
 * 2. When a C# application must merge scanned JPEG pages into a single horizontal strip and apply a uniform border to improve readability for document management systems.
 * 3. When generating social‑media collage images from user‑uploaded JPEGs, a developer can use Aspose.Imaging to stitch them horizontally and add a thin border that matches the platform’s design guidelines.
 * 4. When preparing high‑resolution JPEG artwork for print, a developer may merge individual image layers side‑by‑side and add a precise 5‑pixel border to ensure proper trimming and alignment.
 * 5. When building a thumbnail gallery in a Windows Forms app, a developer can horizontally merge JPEG thumbnails and apply a uniform border to create a clean, spaced‑out visual grid.
 */