// HOW-TO: Log Progress While Vertically Merging JPEG Images in C# (Aspose.Imaging for .NET)
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
            string inputDirectory = "Input";
            string outputPath = "Output/merged.jpg";

            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Input directory not found: {inputDirectory}");
                return;
            }

            var imagePaths = Directory.GetFiles(inputDirectory, "*.jpg")
                .Concat(Directory.GetFiles(inputDirectory, "*.jpeg"))
                .ToList();

            if (imagePaths.Count == 0)
            {
                Console.Error.WriteLine("No JPEG images found in the input directory.");
                return;
            }

            List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
            foreach (string path in imagePaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            int canvasWidth = sizes.Max(s => s.Width);
            int canvasHeight = sizes.Sum(s => s.Height);

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            Source src = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = src, Quality = 100 };

            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                int processed = 0;
                int total = imagePaths.Count;

                foreach (string path in imagePaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetY += img.Height;
                    }

                    processed++;
                    int percent = (int)((processed * 100.0) / total);
                    Console.WriteLine($"Progress: {percent}% ({processed}/{total})");
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
 * 1. When a developer needs to combine multiple scanned JPEG pages into a single long image and show a percentage indicator to users during processing.
 * 2. When building a photo‑gallery export tool that stacks user‑selected JPEG photos vertically and wants to log progress for debugging or UI feedback.
 * 3. When creating a printable PDF‑like strip from a set of JPEG receipts and needs to track how many images have been merged.
 * 4. When automating a server‑side batch job that merges product‑shot JPEGs into a catalog banner while reporting completion status to logs.
 * 5. When developing a mobile‑app backend that assembles JPEG screenshots into a single image and requires progress percentages for monitoring.
 */
