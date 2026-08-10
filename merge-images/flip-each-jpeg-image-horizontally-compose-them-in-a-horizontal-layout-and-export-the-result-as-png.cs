// HOW-TO: Flip Multiple JPEG Images Horizontally and Merge into a PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input JPEG files (hardcoded)
            string[] inputFiles = { "image1.jpg", "image2.jpg", "image3.jpg" };
            // Output PNG file (hardcoded)
            string outputPath = "output.png";

            // Validate input files
            foreach (var inputPath in inputFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load, flip, and collect images
            List<RasterImage> images = new List<RasterImage>();
            List<Size> sizes = new List<Size>();

            foreach (var inputPath in inputFiles)
            {
                RasterImage img = (RasterImage)Image.Load(inputPath);
                img.RotateFlip(RotateFlipType.RotateNoneFlipX);
                images.Add(img);
                sizes.Add(new Size(img.Width, img.Height));
            }

            // Calculate canvas size for horizontal composition
            int totalWidth = sizes.Sum(s => s.Width);
            int maxHeight = sizes.Max(s => s.Height);

            // Create PNG canvas bound to the output file
            PngOptions pngOptions = new PngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, totalWidth, maxHeight))
            {
                int offsetX = 0;
                foreach (var img in images)
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
                // Save the bound canvas
                canvas.Save();
            }

            // Dispose loaded images
            foreach (var img in images)
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
 * 1. When you need to create a panoramic view by mirroring several JPEG photos and saving the combined result as a single PNG file using C#.
 * 2. When an e‑commerce site wants to display product images with a horizontal mirror effect and stitch them together for a banner without manual editing.
 * 3. When a photo‑processing service must batch‑process uploaded JPEGs, flip them horizontally, and generate a composite PNG for quick preview thumbnails.
 * 4. When a desktop application has to combine user‑selected JPEG screenshots side‑by‑side after flipping them, producing a lossless PNG for documentation.
 * 5. When a marketing tool automates the creation of side‑by‑side before‑and‑after images by flipping JPEGs and exporting the merged canvas as PNG in .NET.
 */
