// HOW-TO: Merge Multiple JPEG Images Vertically With Quality 85 In C# (Aspose.Imaging for .NET)
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
            // Hardcoded input image paths
            string[] inputPaths = { "Input\\image1.jpg", "Input\\image2.jpg", "Input\\image3.jpg" };
            // Hardcoded output path
            string outputPath = "Output\\merged.jpg";

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

            // Collect sizes of all input images
            List<Size> sizes = new List<Size>();
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions for vertical merge
            int canvasWidth = sizes.Max(s => s.Width);
            int canvasHeight = sizes.Sum(s => s.Height);

            // Prepare JPEG options with quality 85
            Source src = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions
            {
                Source = src,
                Quality = 85
            };

            // Create JPEG canvas bound to the output file
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                foreach (string path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetY += img.Height;
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
 * 1. When you need to combine several scanned JPEG receipts into a single vertical image while controlling the compression quality for efficient storage.
 * 2. When creating a vertical photo strip for a social media post and you want the final JPEG saved with a specific quality level to balance file size and visual fidelity.
 * 3. When generating a printable catalog page by stacking product photos vertically and you must set the JPEG quality to meet print vendor specifications.
 * 4. When developing a server‑side image service that merges user‑uploaded JPEGs into one image for download, enforcing a consistent quality setting across all outputs.
 * 5. When automating the preparation of before‑and‑after comparison images by placing them one above the other in a single JPEG with a defined compression quality.
 */
