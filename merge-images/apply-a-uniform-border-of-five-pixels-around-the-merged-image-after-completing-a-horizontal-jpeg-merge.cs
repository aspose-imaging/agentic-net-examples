// HOW-TO: Add 5‑Pixel Border to Horizontally Merged JPEG Images in C# (Aspose.Imaging for .NET)
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
            string[] inputPaths = new string[]
            {
                "input1.jpg",
                "input2.jpg",
                "input3.jpg"
            };
            string outputPath = "output/merged.jpg";

            // Validate input files
            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Collect sizes of input images
            List<Size> sizes = new List<Size>();
            foreach (string inputPath in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(inputPath))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas size with border (5 pixels each side)
            int totalWidth = sizes.Sum(s => s.Width) + 10; // 5 left + 5 right
            int maxHeight = sizes.Max(s => s.Height) + 10; // 5 top + 5 bottom

            // Create output source and options
            Source source = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions()
            {
                Source = source,
                Quality = 100
            };

            // Create canvas bound to output file
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, totalWidth, maxHeight))
            {
                // Fill background with white
                int[] whitePixels = Enumerable.Repeat(Color.White.ToArgb(), totalWidth * maxHeight).ToArray();
                canvas.SaveArgb32Pixels(new Rectangle(0, 0, totalWidth, maxHeight), whitePixels);

                // Merge images horizontally with 5-pixel border offset
                int offsetX = 5;
                int offsetY = 5;
                foreach (string inputPath in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(inputPath))
                    {
                        int[] pixels = img.LoadArgb32Pixels(img.Bounds);
                        canvas.SaveArgb32Pixels(new Rectangle(offsetX, offsetY, img.Width, img.Height), pixels);
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
 * 1. When you need to combine several product photos side‑by‑side and add a uniform margin for a clean presentation in a web gallery.
 * 2. When generating a single JPEG banner from multiple ads and you want a consistent 5‑pixel frame around the combined image.
 * 3. When creating printable marketing material that stitches together screenshots and requires a thin border to separate them visually.
 * 4. When automating the preparation of image assets for a mobile app that expects a fixed‑size canvas with a small padding around merged pictures.
 * 5. When processing scanned documents that are merged horizontally and you need a subtle border to prevent content from touching the edge of the final JPEG file.
 */
