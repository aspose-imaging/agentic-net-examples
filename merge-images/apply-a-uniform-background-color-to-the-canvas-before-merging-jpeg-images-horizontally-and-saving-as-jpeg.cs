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
            string[] inputPaths = new string[] { "input1.jpg", "input2.jpg", "input3.jpg" };
            string outputPath = "output.jpg";

            // Validate each input file exists
            foreach (var path in inputPaths)
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
            foreach (var path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions for horizontal merge
            int newWidth = sizes.Sum(s => s.Width);
            int newHeight = sizes.Max(s => s.Height);

            // Create JPEG canvas with options
            Source src = new FileCreateSource(outputPath, false);
            JpegOptions options = new JpegOptions { Source = src, Quality = 100 };
            using (JpegImage canvas = new JpegImage(options, newWidth, newHeight))
            {
                // Fill canvas with uniform background color
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.White);

                // Merge images side by side
                int offsetX = 0;
                foreach (var path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                // Save the bound canvas (source already bound to outputPath)
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
 * 1. When creating a product catalog PDF, a developer can use this code to stitch multiple product photos into a single high‑quality JPEG with a white background for consistent layout.
 * 2. When generating a social media collage, the code merges several JPEG snapshots horizontally and fills any empty space with a uniform color, ensuring the final image meets platform size requirements.
 * 3. When preparing a printable banner, a developer can combine different resolution JPEG images side by side on a canvas, applying a solid background to hide mismatched heights.
 * 4. When building an e‑commerce thumbnail strip, the snippet concatenates thumbnail JPEGs into one image and sets a consistent background color to avoid transparent gaps.
 * 5. When automating a report that includes side‑by‑side before‑and‑after photos, the code creates a single JPEG with a uniform background, simplifying file handling and display.
 */