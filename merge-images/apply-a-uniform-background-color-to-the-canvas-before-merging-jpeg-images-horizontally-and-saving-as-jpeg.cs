// HOW-TO: Merge Multiple JPEG Images Horizontally with White Background in C# (Aspose.Imaging for .NET)
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
            string[] inputPaths = new string[] { "image1.jpg", "image2.jpg", "image3.jpg" };
            string outputPath = "merged.jpg";

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
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Collect image sizes
            List<Size> sizes = new List<Size>();
            foreach (string inputPath in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(inputPath))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions for horizontal merge
            int totalWidth = sizes.Sum(s => s.Width);
            int maxHeight = sizes.Max(s => s.Height);

            // Create output canvas with JPEG options
            Source source = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = source, Quality = 100 };
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, totalWidth, maxHeight))
            {
                // Fill background with uniform color (white)
                Aspose.Imaging.Color bgColor = Aspose.Imaging.Color.FromArgb(255, 255, 255, 255);
                int bgArgb = bgColor.ToArgb();
                int[] bgPixels = new int[totalWidth * maxHeight];
                for (int i = 0; i < bgPixels.Length; i++)
                {
                    bgPixels[i] = bgArgb;
                }
                canvas.SaveArgb32Pixels(new Rectangle(0, 0, totalWidth, maxHeight), bgPixels);

                // Merge images horizontally
                int offsetX = 0;
                foreach (string inputPath in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(inputPath))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                // Save the merged image
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
 * 1. When you need to combine product photos side‑by‑side into a single JPEG for an online catalog.
 * 2. When creating a panoramic thumbnail by stitching several JPEG screenshots together with a uniform background.
 * 3. When generating a printable banner that merges multiple JPEG advertisements while ensuring a consistent white canvas.
 * 4. When preparing a composite image for email newsletters by horizontally joining JPEG logos with a solid background color.
 * 5. When automating batch processing to concatenate JPEG images for a slideshow preview without gaps between them.
 */
