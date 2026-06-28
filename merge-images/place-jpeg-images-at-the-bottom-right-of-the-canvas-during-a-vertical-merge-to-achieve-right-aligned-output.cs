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
            // Hard‑coded input JPEG files (modify as needed)
            string[] inputPaths = new[]
            {
                "input1.jpg",
                "input2.jpg",
                "input3.jpg"
            };

            // Hard‑coded output path
            string outputPath = "output/merged.jpg";

            // Validate each input file
            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

            // Collect sizes of all input images
            List<Size> sizes = new List<Size>();
            foreach (string inputPath in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(inputPath))
                {
                    sizes.Add(img.Size);
                }
            }

            // Determine canvas dimensions (vertical stack, right‑aligned)
            int canvasWidth = sizes.Max(s => s.Width);
            int canvasHeight = sizes.Sum(s => s.Height);

            // Prepare JPEG options with bound source
            Source source = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions
            {
                Source = source,
                Quality = 100
            };

            // Create the output JPEG canvas
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;

                // Place each image on the canvas, aligning to the right edge
                foreach (string inputPath in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(inputPath))
                    {
                        int offsetX = canvasWidth - img.Width; // right alignment
                        Rectangle bounds = new Rectangle(offsetX, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetY += img.Height;
                    }
                }

                // Save the bound image (no path needed because source is already bound)
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
 * 1. When a developer needs to generate a single JPEG report that stacks product photos vertically while keeping each image flush with the right edge of the page.
 * 2. When an e‑commerce site wants to combine multiple customer‑uploaded JPEG thumbnails into a right‑aligned vertical collage for a product detail view using C# and Aspose.Imaging.
 * 3. When a marketing automation script must create a printable JPEG banner by vertically merging campaign images and aligning them to the bottom‑right corner of the canvas.
 * 4. When a desktop application has to assemble scanned JPEG receipts into one continuous right‑aligned vertical image for easy archival.
 * 5. When a photo‑management tool needs to batch‑process a set of JPEG screenshots, stacking them vertically with right alignment to preserve original widths while creating a single output file.
 */