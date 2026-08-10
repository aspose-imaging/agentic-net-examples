// HOW-TO: Vertically Merge JPEG Images with Right‑Aligned Placement in C# (Aspose.Imaging for .NET)
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
            string[] inputPaths = { "image1.jpg", "image2.jpg", "image3.jpg" };
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

            // Collect sizes of all images
            List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions for vertical merge with right alignment
            int canvasWidth = 0;
            int canvasHeight = 0;
            foreach (var sz in sizes)
            {
                if (sz.Width > canvasWidth) canvasWidth = sz.Width;
                canvasHeight += sz.Height;
            }

            // Create JPEG canvas bound to the output file
            JpegOptions jpegOptions = new JpegOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                foreach (string path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        int offsetX = canvasWidth - img.Width; // right‑align
                        Rectangle bounds = new Rectangle(offsetX, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetY += img.Height;
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
 * 1. When you need to combine multiple product photos into a single JPEG brochure page while keeping each image aligned to the right edge of the page.
 * 2. When generating a vertical sprite sheet for a mobile app and want all sprites right‑justified to maintain consistent layout.
 * 3. When creating a printable catalog where varying‑size JPEGs must be stacked vertically and aligned to the right margin for a clean appearance.
 * 4. When automating the assembly of scanned receipts into one PDF‑ready JPEG file and require right‑aligned placement to preserve column alignment.
 * 5. When building a reporting tool that merges user‑uploaded JPEG charts into a single image and needs the charts positioned at the bottom‑right of each segment.
 */
