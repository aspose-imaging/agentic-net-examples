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
        try
        {
            // Hardcoded input JPEG files and output PNG file
            string[] inputPaths = new string[] { "input/image1.jpg", "input/image2.jpg", "input/image3.jpg" };
            string outputPath = "output/merged.png";

            // Validate each input file exists
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

            // Collect sizes of all input images
            List<Size> sizes = new List<Size>();
            foreach (var path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions for horizontal merge
            int newWidth = sizes.Sum(s => s.Width);
            int newHeight = sizes.Max(s => s.Height);

            // Create PNG options with interlacing (Progressive)
            Source src = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions() { Source = src, Progressive = true };

            // Create the output canvas bound to the file
            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, newWidth, newHeight))
            {
                int offsetX = 0;
                foreach (var path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
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
 * 1. When creating a web‑ready image gallery that combines multiple JPEG photos into a single progressive PNG for faster incremental loading in browsers.
 * 2. When generating a printable product catalog where product photos (JPEG) are stitched side‑by‑side and saved as an interlaced PNG to preserve quality while reducing file size.
 * 3. When building a desktop application that merges scanned JPEG documents into a single PNG banner with progressive rendering for smoother preview on low‑bandwidth connections.
 * 4. When developing an automated marketing pipeline that concatenates campaign images into a single interlaced PNG to be embedded in email newsletters that support progressive display.
 * 5. When implementing a server‑side image service that assembles user‑uploaded JPEG avatars into a horizontal PNG sprite sheet with interlacing to improve loading performance on mobile devices.
 */