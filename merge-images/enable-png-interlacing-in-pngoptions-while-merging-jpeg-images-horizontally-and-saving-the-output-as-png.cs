using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input JPEG files and output PNG path
            string[] inputPaths = new[] { "image1.jpg", "image2.jpg", "image3.jpg" };
            string outputPath = "merged.png";

            // Validate each input file exists
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

            // Create source and PNG options with interlacing (Progressive)
            Source source = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions()
            {
                Source = source,
                Progressive = true
            };

            // Create bound PNG canvas
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

                // Save the bound image (output path already bound in options)
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
 * 1. When a web developer needs to combine several JPEG product photos into one progressive PNG sprite for faster incremental loading on e‑commerce sites.
 * 2. When a desktop application must generate a horizontally merged PNG banner from user‑uploaded JPEG images while preserving interlaced (progressive) display for smoother preview in browsers.
 * 3. When a reporting tool creates a single PNG chart that stitches together multiple JPEG graphs side‑by‑side and requires interlacing to reduce perceived rendering time on low‑bandwidth connections.
 * 4. When a digital asset management system exports a composite PNG thumbnail from a series of JPEG assets, using Aspose.Imaging’s PngOptions to enable progressive rendering for quick visual inspection.
 * 5. When a mobile app prepares a horizontally merged PNG collage from camera‑captured JPEGs and enables PNG interlacing to allow the image to appear progressively as it downloads over cellular networks.
 */