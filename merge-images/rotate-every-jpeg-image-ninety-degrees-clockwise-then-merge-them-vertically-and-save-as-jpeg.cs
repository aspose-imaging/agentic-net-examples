// HOW-TO: Rotate JPEG Images 90 Degrees Clockwise and Merge Vertically in C# (Aspose.Imaging for .NET)
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
            string inputDirectory = "input";
            string outputPath = "output/merged.jpg";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            string[] jpegFiles = Directory.GetFiles(inputDirectory, "*.jpg")
                .Concat(Directory.GetFiles(inputDirectory, "*.jpeg"))
                .ToArray();

            if (jpegFiles.Length == 0)
            {
                Console.WriteLine("No JPEG files found in the input directory.");
                return;
            }

            var imagesData = new List<(int[] Pixels, int Width, int Height)>();

            foreach (string filePath in jpegFiles)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                using (RasterImage img = (RasterImage)Image.Load(filePath))
                {
                    img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    int width = img.Width;
                    int height = img.Height;
                    int[] pixels = img.LoadArgb32Pixels(img.Bounds);
                    imagesData.Add((pixels, width, height));
                }
            }

            int maxWidth = imagesData.Max(i => i.Width);
            int totalHeight = imagesData.Sum(i => i.Height);

            JpegOptions jpegOptions = new JpegOptions()
            {
                Source = new FileCreateSource(outputPath, false),
                Quality = 100
            };

            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, maxWidth, totalHeight))
            {
                int offsetY = 0;
                foreach (var data in imagesData)
                {
                    Rectangle bounds = new Rectangle(0, offsetY, data.Width, data.Height);
                    canvas.SaveArgb32Pixels(bounds, data.Pixels);
                    offsetY += data.Height;
                }
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
 * 1. When you need to correct the orientation of a batch of scanned JPEG photos and combine them into a single portrait‑style image for printing.
 * 2. When creating a vertical photo strip from multiple camera snapshots to use in social media stories or product catalogs.
 * 3. When preprocessing images for a PDF generator that requires all pages to be portrait and merged into one JPEG file.
 * 4. When automating the preparation of receipt or invoice scans that were captured sideways, rotating them and stacking them for archival storage.
 * 5. When building a slideshow thumbnail that displays several JPEG frames stacked vertically after aligning their orientation.
 */
