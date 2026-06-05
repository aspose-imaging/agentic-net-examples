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

            const int uniformWidth = 200; // Desired width for each image

            // Load, resize, and collect images
            List<RasterImage> images = new List<RasterImage>();
            List<int> heights = new List<int>();

            foreach (string path in inputPaths)
            {
                RasterImage img = (RasterImage)Image.Load(path);
                int newHeight = (int)((double)img.Height * uniformWidth / img.Width);
                img.Resize(uniformWidth, newHeight);
                images.Add(img);
                heights.Add(img.Height);
            }

            // Calculate canvas size
            int totalWidth = uniformWidth * images.Count;
            int maxHeight = heights.Max();

            // Create JPEG canvas
            Source source = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = source, Quality = 90 };

            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, totalWidth, maxHeight))
            {
                int offsetX = 0;
                foreach (RasterImage img in images)
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
                // Save the bound image
                canvas.Save();
            }

            // Dispose loaded images
            foreach (RasterImage img in images)
            {
                img.Dispose();
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
 * 1. When creating a product catalog thumbnail strip, a developer can use this code to resize each product JPEG to the same width and merge them side‑by‑side into a single JPEG for quick web preview.
 * 2. When generating a social media collage of event photos, the code ensures all JPEG images share a uniform width before horizontally stitching them together for a consistent look.
 * 3. When preparing a printable banner that combines multiple advertisement images, the developer can resize each JPEG to a fixed width and merge them into one high‑quality JPEG canvas.
 * 4. When building an e‑learning platform that displays a sequence of diagram screenshots, this code resizes each JPEG to the same width and merges them horizontally for a seamless slide view.
 * 5. When automating the creation of a before‑and‑after comparison image, the code resizes the two JPEGs to a uniform width and merges them side‑by‑side into a single JPEG file.
 */