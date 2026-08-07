using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input JPEG paths
            string[] inputPaths = { "image1.jpg", "image2.jpg" };
            // Validate each input file
            foreach (string path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Hardcoded output PNG path
            string outputPath = "merged.png";
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Collect sizes of all input images
            List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions for horizontal merge
            int newWidth = 0;
            int newHeight = 0;
            foreach (var sz in sizes)
            {
                newWidth += sz.Width;
                if (sz.Height > newHeight) newHeight = sz.Height;
            }

            // Create output source and PNG options with interlacing (Progressive)
            Source src = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions()
            {
                Source = src,
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
                        Aspose.Imaging.Rectangle bounds = new Aspose.Imaging.Rectangle(offsetX, 0, img.Width, img.Height);
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
 * 1. When a web developer needs to combine multiple JPEG product photos side‑by‑side into a single progressive PNG sprite for faster incremental loading on e‑commerce sites.
 * 2. When a desktop application must generate a horizontally merged PNG banner from user‑uploaded JPEG images with interlacing enabled to improve perceived loading speed in low‑bandwidth environments.
 * 3. When an email marketing tool creates a single PNG collage of JPEG event photos, using Aspose.Imaging’s PngOptions.Progressive to ensure the image displays progressively as the email loads.
 * 4. When a reporting system assembles JPEG charts into a wide PNG dashboard panel and requires interlaced PNG output so viewers can see portions of the chart while the file is still downloading.
 * 5. When a mobile app builds a horizontal PNG thumbnail strip from JPEG thumbnails, enabling PNG interlacing to reduce initial render time on devices with limited network speed.
 */