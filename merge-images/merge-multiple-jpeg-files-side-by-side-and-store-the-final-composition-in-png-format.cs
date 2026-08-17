// HOW-TO: Merge Multiple JPEG Images Horizontally Into a PNG With C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string[] inputPaths = new[] { "image1.jpg", "image2.jpg", "image3.jpg" };
        string outputPath = "merged.png";

        try
        {
            // Validate each input file
            foreach (string path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Collect sizes of all input images
            List<Size> sizes = new List<Size>();
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions for horizontal merge
            int newWidth = sizes.Sum(s => s.Width);
            int newHeight = sizes.Max(s => s.Height);

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Prepare PNG options with bound source
            Source src = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions() { Source = src };

            // Create canvas and merge images side by side
            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, newWidth, newHeight))
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

                // Save the bound canvas (output path already bound via FileCreateSource)
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
 * 1. When you need to create a single panoramic preview by stitching several product photos (JPEG) side by side and outputting a PNG for web display.
 * 2. When generating a composite thumbnail that combines multiple camera snapshots into one image for reporting dashboards using C# and Aspose.Imaging.
 * 3. When building an automated workflow that concatenates scanned document pages saved as JPEG into a single PNG file for archival or printing.
 * 4. When developing a photo‑gallery application that shows a series of user‑uploaded JPEGs in a horizontal strip without losing quality, saved as PNG.
 * 5. When preparing side‑by‑side before‑after comparisons of images by merging two JPEGs into one PNG for marketing materials.
 */
