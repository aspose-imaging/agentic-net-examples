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
            string[] inputPaths = new string[]
            {
                "input1.jpg",
                "input2.jpg",
                "input3.jpg"
            };

            // Hardcoded output path
            string outputPath = "output/merged.jpg";

            // Validate input files
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

            // Determine canvas dimensions for vertical merge
            int canvasWidth = sizes.Max(s => s.Width);
            int canvasHeight = sizes.Sum(s => s.Height);

            // Create JPEG canvas with options
            Source src = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions()
            {
                Source = src,
                Quality = 90
            };

            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                int processed = 0;
                int total = inputPaths.Length;

                foreach (var path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetY += img.Height;
                    }

                    processed++;
                    int percent = (int)((processed * 100.0) / total);
                    Console.WriteLine($"Progress: {percent}%");
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
 * 1. When a developer creates a PDF‑to‑JPEG conversion tool that stacks scanned pages vertically and needs to log the progress percentage after each JPEG image is added to the canvas for user feedback.
 * 2. When building an automated photo‑album generator that merges individual JPEG photos into a single tall image and wants to report the merge status in the console or UI.
 * 3. When implementing a batch image‑processing pipeline that combines product catalog images into one JPEG banner and requires progress logging to monitor long‑running jobs.
 * 4. When developing a server‑side service that assembles user‑uploaded JPEG screenshots into a vertical collage and needs to track and log each step to detect performance bottlenecks.
 * 5. When designing a desktop application that merges multiple JPEG receipts into a single printable file and wants to display a percentage complete after each receipt is placed on the canvas.
 */