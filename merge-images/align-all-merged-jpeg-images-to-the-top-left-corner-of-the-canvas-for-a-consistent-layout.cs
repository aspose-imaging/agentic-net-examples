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
            // Define input and output paths
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

            // Collect sizes of all input images
            List<Size> sizes = new List<Size>();
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions (horizontal merge, top‑left alignment)
            int newWidth = 0;
            int newHeight = 0;
            foreach (Size sz in sizes)
            {
                newWidth += sz.Width;
                if (sz.Height > newHeight) newHeight = sz.Height;
            }

            // Create JPEG options with bound source
            Source src = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions()
            {
                Source = src,
                Quality = 100
            };

            // Create canvas bound to the output file
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, newWidth, newHeight))
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
 * 1. When building a product catalog website that needs to combine multiple product photos into a single horizontal strip JPEG for faster loading and consistent top‑left alignment.
 * 2. When generating printable contact sheets in a desktop publishing workflow where several JPEG thumbnails must be merged side‑by‑side with the images anchored to the top‑left corner of the canvas.
 * 3. When creating a composite banner for an email marketing campaign that stitches together promotional JPEG images horizontally while keeping all elements aligned to the top‑left to avoid unwanted gaps.
 * 4. When developing a digital signage system that concatenates multiple advertisement JPEGs into one wide image, ensuring each ad starts at the top‑left to maintain a uniform layout across screens.
 * 5. When implementing an automated batch process that merges scanned JPEG pages into a single panoramic view, aligning each page to the top‑left corner to preserve the original page order and margins.
 */