using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
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
            string outputPath = "output/merged.jpg";

            // Validate input files
            foreach (var path in inputPaths)
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
            List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
            foreach (var path in inputPaths)
            {
                using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(path))
                {
                    sizes.Add(new Aspose.Imaging.Size(img.Width, img.Height));
                }
            }

            // Calculate canvas dimensions (horizontal layout, top‑left alignment)
            int canvasWidth = sizes.Sum(s => s.Width);
            int canvasHeight = sizes.Max(s => s.Height);

            // Create JPEG canvas bound to the output file
            FileCreateSource src = new FileCreateSource(outputPath, false);
            JpegOptions options = new JpegOptions() { Source = src, Quality = 100 };

            using (JpegImage canvas = (JpegImage)Aspose.Imaging.Image.Create(options, canvasWidth, canvasHeight))
            {
                int offsetX = 0;
                foreach (var path in inputPaths)
                {
                    using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(path))
                    {
                        var bounds = new Aspose.Imaging.Rectangle(offsetX, 0, img.Width, img.Height);
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
 * 1. When creating a product catalog where multiple product photos need to be combined into a single high‑quality JPEG banner with all images aligned to the top‑left corner for a uniform layout.
 * 2. When generating a printable photo collage from user‑uploaded JPEG files in a web application, and the developer wants to place each picture side‑by‑side on a canvas while keeping them top‑left aligned to avoid gaps.
 * 3. When building an automated email marketing system that merges several promotional JPEG images into one email‑friendly image, ensuring consistent alignment at the top‑left to maintain visual hierarchy.
 * 4. When developing a desktop utility that consolidates scanned document pages saved as JPEGs into a single overview image, aligning each page to the top‑left of the combined canvas for easy preview.
 * 5. When implementing a digital signage solution that stitches multiple JPEG advertisements into a single slide, using C# and Aspose.Imaging to align the ads to the top‑left corner for a clean, side‑by‑side presentation.
 */