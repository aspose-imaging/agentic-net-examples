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
            // Define input and output locations
            string inputDirectory = "Input";
            string outputDirectory = "Output";
            string outputPath = Path.Combine(outputDirectory, "merged.jpg");

            // Ensure input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Gather JPEG files
            var jpegFiles = Directory.GetFiles(inputDirectory, "*.jpg")
                .Concat(Directory.GetFiles(inputDirectory, "*.jpeg"))
                .ToArray();

            if (jpegFiles.Length == 0)
            {
                Console.WriteLine("No JPEG files found to process.");
                return;
            }

            // Lists to hold dimensions and loaded images
            List<int> widths = new List<int>();
            List<int> heights = new List<int>();
            List<RasterImage> rotatedImages = new List<RasterImage>();

            // Load, rotate, and collect size information
            foreach (string filePath in jpegFiles)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                using (Image img = Image.Load(filePath))
                {
                    img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    var raster = (RasterImage)img;
                    widths.Add(raster.Width);
                    heights.Add(raster.Height);
                    // Clone raster to keep after disposing the using block
                    // Since Image is disposed at end of using, we need a separate instance
                    // Create a temporary in-memory copy
                    using (RasterImage copy = (RasterImage)Image.Create(new JpegOptions(), raster.Width, raster.Height))
                    {
                        copy.SaveArgb32Pixels(copy.Bounds, raster.LoadArgb32Pixels(raster.Bounds));
                        rotatedImages.Add(copy);
                    }
                }
            }

            // Calculate canvas size for vertical merge
            int canvasWidth = widths.Max();
            int canvasHeight = heights.Sum();

            // Prepare output source and options
            Source source = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = source, Quality = 90 };

            // Create canvas and merge images vertically
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                foreach (RasterImage img in rotatedImages)
                {
                    Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetY += img.Height;
                    img.Dispose();
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
 * 1. When a developer needs to automatically correct the orientation of scanned photos taken in portrait mode and combine them into a single vertical JPEG for easy sharing.
 * 2. When a web application must generate a printable photo strip by rotating user‑uploaded JPEG images 90° clockwise and stitching them vertically before saving the result.
 * 3. When an e‑commerce platform wants to create a single product‑gallery image from multiple JPEG snapshots taken sideways, rotating each and merging them vertically for a compact display.
 * 4. When a digital archiving tool processes batches of JPEG scans, reorienting each page and merging them into one vertical JPEG file for streamlined storage.
 * 5. When a mobile‑to‑desktop sync utility needs to fix the rotation of JPEG screenshots and combine them into a single vertical image for quick review by non‑technical users.
 */