// HOW-TO: Merge Multiple JPEGs Horizontally And Add 5‑Pixel Border In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
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
            string[] inputPaths = new string[]
            {
                "input1.jpg",
                "input2.jpg",
                "input3.jpg"
            };
            string outputPath = "merged_with_border.jpg";

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

            // Calculate canvas size for horizontal merge
            int mergedWidth = sizes.Sum(s => s.Width);
            int mergedHeight = sizes.Max(s => s.Height);

            // Add uniform border of 5 pixels on each side
            int borderSize = 5;
            int finalWidth = mergedWidth + borderSize * 2;
            int finalHeight = mergedHeight + borderSize * 2;

            // Create JPEG options with bound output file
            Source source = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions
            {
                Source = source,
                Quality = 100
            };

            // Create canvas bound to the output file
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, finalWidth, finalHeight))
            {
                // Fill entire canvas with white (border color)
                int[] borderPixels = Enumerable.Repeat(Aspose.Imaging.Color.White.ToArgb(), finalWidth * finalHeight).ToArray();
                canvas.SaveArgb32Pixels(new Rectangle(0, 0, finalWidth, finalHeight), borderPixels);

                // Merge images horizontally with offset for border
                int offsetX = borderSize;
                foreach (string path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle destRect = new Rectangle(offsetX, borderSize, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(destRect, img.LoadArgb32Pixels(img.Bounds));
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
 * 1. When you need to combine several product photos side‑by‑side into a single image for an online catalog while keeping a consistent margin around the combined picture.
 * 2. When generating a composite banner from multiple JPEG advertisements and you want a uniform border to separate it from surrounding page elements.
 * 3. When creating a printable strip of scanned receipts and you require a thin frame to ensure the edges are not cut off during printing.
 * 4. When developing a photo‑gallery web app that displays a row of user‑uploaded images as one image with a clean border for aesthetic consistency.
 * 5. When automating the preparation of image assets for a slideshow where each slide consists of horizontally merged JPEGs and a surrounding border improves visual separation.
 */
