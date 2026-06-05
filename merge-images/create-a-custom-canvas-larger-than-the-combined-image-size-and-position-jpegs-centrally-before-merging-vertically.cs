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
            // Hardcoded input JPEG file paths
            string[] inputPaths = { "input1.jpg", "input2.jpg", "input3.jpg" };
            // Hardcoded output JPEG file path
            string outputPath = "merged_output.jpg";

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
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Collect sizes of all input images
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
            int canvasWidth = maxWidth + 2 * padding;
            int canvasHeight = totalHeight + 2 * padding;

            // Prepare JPEG options with bound output file
            JpegOptions jpegOptions = new JpegOptions
            {
                Quality = 100,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create canvas bound to the output file
            using (JpegImage canvas = new JpegImage(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetY = padding;

                // Merge each image vertically, centered horizontally
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
 * 1. When a developer needs to create a printable photo collage that adds a uniform border around a set of JPEG pictures stacked vertically.
 * 2. When an e‑commerce application must combine multiple product JPEG images into a single high‑resolution file with consistent padding for display on a product detail page.
 * 3. When a mobile app generates a vertical social‑media story image by centering several JPEG frames on a larger canvas and leaving extra space for captions.
 * 4. When a document‑scanning workflow requires merging several scanned JPEG pages into one file while keeping each page centered and adding a margin for binding.
 * 5. When a digital signage system assembles multiple advertisement banners into one tall JPEG image, ensuring each banner is centered and separated by a fixed padding.
 */