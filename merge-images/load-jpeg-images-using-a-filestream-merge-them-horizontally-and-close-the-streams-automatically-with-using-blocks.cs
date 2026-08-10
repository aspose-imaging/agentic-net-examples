// HOW-TO: Merge Multiple JPEG Images Horizontally Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            string[] inputPaths = new string[]
            {
                "input1.jpg",
                "input2.jpg",
                "input3.jpg"
            };
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
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Collect sizes of all images
            List<Size> sizes = new List<Size>();
            foreach (string path in inputPaths)
            {
                using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    using (JpegImage img = new JpegImage(stream))
                    {
                        sizes.Add(img.Size);
                    }
                }
            }

            // Calculate canvas dimensions for horizontal merge
            int canvasWidth = sizes.Sum(s => s.Width);
            int canvasHeight = sizes.Max(s => s.Height);

            // Prepare JPEG options with bound output source
            Source outputSource = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions
            {
                Source = outputSource,
                Quality = 100
            };

            // Create canvas image
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetX = 0;
                foreach (string path in inputPaths)
                {
                    using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        using (JpegImage img = new JpegImage(stream))
                        {
                            Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                            canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                            offsetX += img.Width;
                        }
                    }
                }

                // Save the merged image (output is already bound)
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
 * 1. When you need to combine product photos side‑by‑side into a single JPEG for an online catalog without manually opening each file.
 * 2. When an automated reporting tool must stitch together scanned document pages into a wide‑format image for easier viewing.
 * 3. When a web service creates a panoramic thumbnail by merging user‑uploaded JPEGs before sending it to a client.
 * 4. When a batch job consolidates multiple camera snapshots into a single image for archival storage while ensuring streams are closed properly.
 * 5. When a desktop application generates a side‑by‑side comparison image of before‑and‑after JPEGs for visual QA testing.
 */
