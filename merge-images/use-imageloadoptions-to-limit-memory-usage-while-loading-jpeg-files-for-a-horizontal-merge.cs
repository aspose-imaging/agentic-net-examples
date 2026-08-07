using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
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
            string outputPath = "output.jpg";

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

            // Load each image to collect sizes (memory‑limited loading)
            var sizes = new List<Size>();
            var loadOptions = new LoadOptions { BufferSizeHint = 50 };
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path, loadOptions))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions for horizontal merge
            int newWidth = sizes.Sum(s => s.Width);
            int newHeight = sizes.Max(s => s.Height);

            // Prepare output canvas with JPEG options
            Source src = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions
            {
                Source = src,
                Quality = 90,
                BufferSizeHint = 50
            };

            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, newWidth, newHeight))
            {
                int offsetX = 0;
                foreach (string path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path, loadOptions))
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
 * 1. When a web service must stitch several high‑resolution JPEG product images into a single horizontal banner while running on a low‑memory VM, this code uses ImageLoadOptions with BufferSizeHint to limit RAM consumption during loading.
 * 2. When an automated reporting tool needs to merge daily scanned JPEG receipts side‑by‑side into one file without exhausting server memory, the example demonstrates how to load each image with a memory‑friendly buffer and create a combined JpegImage.
 * 3. When a mobile‑backend API creates a panoramic view from user‑uploaded JPEG photos on a device‑restricted server, the BufferSizeHint option ensures each RasterImage is loaded efficiently before the horizontal merge.
 * 4. When a batch‑processing job consolidates multiple JPEG thumbnails into a single wide catalog image on a shared hosting environment, the code shows how to calculate canvas size and merge images while keeping memory usage low.
 * 5. When an e‑commerce platform generates a combined promotional JPEG banner from several promotional images on a container with limited RAM, the example illustrates using JpegOptions and LoadOptions to safely load and merge the files horizontally.
 */