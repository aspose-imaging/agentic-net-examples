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
            string[] inputPaths = { "input1.jpg", "input2.jpg" };
            string outputPath = "output.png";

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

            // Create PNG canvas with bound output source
            Source src = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions { Source = src };

            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, newWidth, newHeight))
            {
                int offsetX = 0;
                foreach (var path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        // Copy pixels from source image to canvas at the current offset
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        int[] pixels = img.LoadArgb32Pixels(img.Bounds);
                        canvas.SaveArgb32Pixels(bounds, pixels);
                        offsetX += img.Width;
                    }
                }

                // Save the bound canvas (output file already specified in source)
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
 * 1. When a developer needs to combine multiple JPEG product photos into a single PNG sprite sheet for a web gallery while ensuring all image resources are released promptly.
 * 2. When an e‑commerce platform must merge scanned JPEG invoices into a consolidated PNG document for batch processing and wants deterministic disposal of Image objects.
 * 3. When a reporting tool creates a side‑by‑side comparison of before‑and‑after JPEG images and outputs the result as a PNG for high‑quality printing, using using statements to avoid memory leaks.
 * 4. When a mobile app backend stitches together user‑uploaded JPEG thumbnails into a single PNG collage for social sharing, requiring proper cleanup of raster images.
 * 5. When a digital asset management system automates the conversion of a series of JPEG assets into a single PNG composite for archival, employing using blocks to guarantee that each image file handle is closed.
 */