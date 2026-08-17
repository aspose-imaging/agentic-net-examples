// HOW-TO: Resize Multiple JPEGs to Same Width and Merge Horizontally in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input JPEG files
            string[] inputPaths = { "input1.jpg", "input2.jpg", "input3.jpg" };
            // Hardcoded output merged JPEG file
            string outputPath = "merged.jpg";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Desired uniform width for each image
            int targetWidth = 800;

            // First pass: validate files and collect resized dimensions
            List<Size> resizedSizes = new List<Size>();
            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                using (RasterImage img = (RasterImage)Image.Load(inputPath))
                {
                    int newHeight = (int)(img.Height * (double)targetWidth / img.Width);
                    resizedSizes.Add(new Size(targetWidth, newHeight));
                }
            }

            // Calculate canvas size for horizontal merge
            int canvasWidth = resizedSizes.Sum(s => s.Width);
            int canvasHeight = resizedSizes.Max(s => s.Height);

            // Create JPEG canvas bound to the output file
            Source fileSource = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions
            {
                Source = fileSource,
                Quality = 90
            };

            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetX = 0;
                // Second pass: load, resize, and copy each image onto the canvas
                foreach (string inputPath in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(inputPath))
                    {
                        int newHeight = (int)(img.Height * (double)targetWidth / img.Width);
                        img.Resize(targetWidth, newHeight);
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                // Save the bound canvas to the output file
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
 * 1. When you need to create a side‑by‑side photo collage from several JPEG photos that must share a consistent width.
 * 2. When preparing product images for an e‑commerce catalog where each item image must be the same width before being combined into a single banner.
 * 3. When generating a before‑and‑after comparison image by resizing two JPEGs to equal width and stitching them horizontally.
 * 4. When automating the creation of a panoramic thumbnail from a set of individual JPEG snapshots taken at the same location.
 * 5. When consolidating scanned document pages saved as JPEGs into one wide image for easier viewing or printing.
 */
