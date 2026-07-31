using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input JPEG file paths
            string[] inputPaths = new string[]
            {
                "input1.jpg",
                "input2.jpg",
                "input3.jpg"
            };

            // Verify each input file exists
            foreach (string path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Desired uniform width for all images
            int targetWidth = 200;

            // Lists to hold resized dimensions
            List<int> widths = new List<int>();
            List<int> heights = new List<int>();

            // First pass: load, resize, and collect sizes
            foreach (string path in inputPaths)
            {
                using (JpegImage img = (JpegImage)Aspose.Imaging.Image.Load(path))
                {
                    int newHeight = img.Height * targetWidth / img.Width;
                    img.Resize(targetWidth, newHeight);
                    widths.Add(img.Width);
                    heights.Add(img.Height);
                }
            }

            // Calculate canvas size for horizontal merge
            int canvasWidth = 0;
            int canvasHeight = 0;
            foreach (int w in widths) canvasWidth += w;
            foreach (int h in heights) if (h > canvasHeight) canvasHeight = h;

            // Output path for merged JPEG
            string outputPath = "merged.jpg";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Prepare JPEG options with bound source
            FileCreateSource src = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions()
            {
                Source = src,
                Quality = 90
            };

            // Create canvas image bound to the output file
            using (JpegImage canvas = (JpegImage)Aspose.Imaging.Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetX = 0;
                // Second pass: load, resize, and copy onto canvas
                foreach (string path in inputPaths)
                {
                    using (JpegImage img = (JpegImage)Aspose.Imaging.Image.Load(path))
                    {
                        int newHeight = img.Height * targetWidth / img.Width;
                        img.Resize(targetWidth, newHeight);

                        Aspose.Imaging.Rectangle destRect = new Aspose.Imaging.Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(destRect, img.LoadArgb32Pixels(img.Bounds));

                        offsetX += img.Width;
                    }
                }

                // Save the bound canvas (output file)
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
 * 1. When creating a product catalog thumbnail strip where multiple JPEG photos must share the same width and be combined side‑by‑side for a web page.
 * 2. When generating a before‑and‑after comparison image for a photo‑editing app, resizing each JPEG to a fixed width and stitching them horizontally.
 * 3. When preparing a printable banner that consists of several JPEG logos that need uniform width and a single merged image for consistent layout.
 * 4. When building an automated email newsletter that includes a row of resized JPEG images merged into one file to reduce attachment size.
 * 5. When developing a digital signage system that displays a horizontal carousel of JPEG images, each resized to the same width for seamless scrolling.
 */