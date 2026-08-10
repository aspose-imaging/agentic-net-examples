// HOW-TO: Merge Multiple JPEGs Horizontally With Centered Alignment In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
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
            // Hard‑coded input JPEG files
            string[] inputPaths = new[]
            {
                "input1.jpg",
                "input2.jpg",
                "input3.jpg"
            };

            // Hard‑coded output file
            string outputPath = "output.jpg";

            // Validate each input file
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

            // First pass – collect sizes to determine canvas dimensions
            List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            int canvasWidth = sizes.Sum(s => s.Width);
            int canvasHeight = sizes.Max(s => s.Height);

            // Prepare JPEG options with bound source
            Source source = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions
            {
                Source = source,
                Quality = 100
            };

            // Create the canvas image (bound to the output file)
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetX = 0;

                // Second pass – load each image, center it vertically, and copy pixels onto the canvas
                foreach (string path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        int offsetY = (canvasHeight - img.Height) / 2;
                        Rectangle bounds = new Rectangle(offsetX, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                // Save the bound canvas (no path needed because source is already bound)
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
 * 1. When you need to combine product photos side‑by‑side into a single banner while keeping each JPEG vertically centered on the canvas.
 * 2. When creating a composite image for a web gallery that displays several JPEGs in a horizontal strip with uniform height.
 * 3. When generating printable marketing material that merges multiple high‑resolution JPEGs into one balanced layout.
 * 4. When building a slideshow thumbnail that stitches several JPEG frames together without cropping any image.
 * 5. When automating the preparation of side‑by‑side before‑and‑after comparison JPEGs for a medical or engineering report.
 */
