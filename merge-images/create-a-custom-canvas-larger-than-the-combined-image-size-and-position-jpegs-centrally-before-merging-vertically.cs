using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
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

            // Collect sizes of all input images
            List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
            foreach (string path in inputPaths)
            {
                using (JpegImage img = (JpegImage)Aspose.Imaging.Image.Load(path))
                {
                    sizes.Add(new Aspose.Imaging.Size(img.Width, img.Height));
                }
            }

            // Determine canvas dimensions (add 20px padding on each side)
            int maxWidth = sizes.Max(s => s.Width);
            int totalHeight = sizes.Sum(s => s.Height);
            int padding = 20;
            int canvasWidth = maxWidth + padding * 2;
            int canvasHeight = totalHeight + padding * 2;

            // Create JPEG options with bound source
            JpegOptions jpegOptions = new JpegOptions
            {
                Source = new FileCreateSource(outputPath, false),
                Quality = 100
            };

            // Create canvas image
            using (JpegImage canvas = (JpegImage)Aspose.Imaging.Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetY = padding;
                foreach (string path in inputPaths)
                {
                    using (JpegImage img = (JpegImage)Aspose.Imaging.Image.Load(path))
                    {
                        int offsetX = (canvasWidth - img.Width) / 2; // center horizontally
                        Aspose.Imaging.Rectangle bounds = new Aspose.Imaging.Rectangle(offsetX, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetY += img.Height;
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
 * 1. When a developer needs to generate a printable photo collage that stacks multiple JPEG portraits vertically with uniform white borders, they can use this code to create a larger canvas, center each image, and merge them into a single high‑quality JPEG.
 * 2. When building an e‑commerce product catalog where each product’s thumbnail must be displayed one after another on a single page with consistent spacing, the code provides a way to pad and vertically combine JPEG images into one document‑ready file.
 * 3. When creating a mobile app splash screen that showcases a series of tutorial screenshots stacked vertically with equal margins, developers can employ this routine to center each JPEG on a padded canvas before exporting the final image.
 * 4. When automating the preparation of before‑and‑after medical imaging slides where each JPEG needs to be aligned centrally on a common background for side‑by‑side comparison, this approach merges the images vertically with precise padding.
 * 5. When generating a social‑media story graphic that combines several JPEG memes into a single tall image with centered alignment and consistent border space, the code enables developers to assemble the final picture efficiently.
 */