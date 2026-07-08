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
            string[] inputPaths = { "input1.jpg", "input2.jpg", "input3.jpg" };
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

            // Collect sizes of all images
            List<Size> sizes = new List<Size>();
            foreach (string path in inputPaths)
            {
                using (JpegImage img = (JpegImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Determine canvas dimensions (larger than combined size)
            int padding = 20;
            int maxWidth = sizes.Max(s => s.Width);
            int totalHeight = sizes.Sum(s => s.Height);
            int canvasWidth = maxWidth + padding * 2;
            int canvasHeight = totalHeight + padding * 2;

            // Create JPEG canvas with bound output file
            JpegOptions jpegOptions = new JpegOptions
            {
                Source = new FileCreateSource(outputPath, false),
                Quality = 100
            };
            using (JpegImage canvas = new JpegImage(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetY = padding;
                foreach (string path in inputPaths)
                {
                    using (JpegImage img = (JpegImage)Image.Load(path))
                    {
                        int offsetX = padding + (maxWidth - img.Width) / 2;
                        Rectangle bounds = new Rectangle(offsetX, offsetY, img.Width, img.Height);
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
 * 1. When a web application needs to generate a printable photo collage by stacking user‑uploaded JPEGs vertically on a single page with uniform margins.
 * 2. When an e‑commerce platform wants to create a product comparison image that places several product photos one below another on a larger JPEG canvas for email newsletters.
 * 3. When a digital signage system must combine multiple advertisement banners into one high‑resolution JPEG with consistent padding to ensure they appear centered on the screen.
 * 4. When a document‑generation service prepares a PDF cover page by first merging several portrait‑oriented JPEG scans into a single vertically aligned image with extra white space around the edges.
 * 5. When a mobile app creates a before‑and‑after visual by stacking two JPEG snapshots on a larger canvas so the images stay centered and the final merged file retains maximum JPEG quality.
 */