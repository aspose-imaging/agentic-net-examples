// HOW-TO: Load JPEG Images with Memory Limit and Merge Horizontally in C# (Aspose.Imaging for .NET)
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
                "input2.jpg"
                // Add more input files as needed
            };
            string outputPath = "output.jpg";

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

            // Load options with memory limit (e.g., 50 MB)
            LoadOptions loadOptions = new LoadOptions { BufferSizeHint = 50 };

            // Collect sizes of all input images
            List<Size> sizes = new List<Size>();
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path, loadOptions))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas size for horizontal merge
            int newWidth = sizes.Sum(s => s.Width);
            int newHeight = sizes.Max(s => s.Height);

            // Create JPEG options with bound output source
            Source src = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions
            {
                Source = src,
                Quality = 90 // Adjust quality as needed
            };

            // Create canvas bound to the output file
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, newWidth, newHeight))
            {
                int offsetX = 0;
                foreach (string path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path, loadOptions))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
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
 * 1. When processing a large batch of high‑resolution JPEG photos on a server with limited RAM, you can load each image with a buffer size hint to prevent out‑of‑memory errors and stitch them side‑by‑side into a single output file.
 * 2. When creating a panoramic view from several JPEG tiles in a desktop application, the code lets you safely load each tile using Aspose.Imaging’s LoadOptions while keeping memory consumption under a defined threshold.
 * 3. When generating a composite advertisement banner from multiple product JPEG images on a low‑memory IoT device, the approach ensures each image is loaded efficiently before being merged horizontally.
 * 4. When building an automated image‑processing pipeline that concatenates scanned JPEG pages into a single wide image, you can control the memory footprint by specifying BufferSizeHint during loading.
 * 5. When developing a web service that receives user‑uploaded JPEGs and returns a combined side‑by‑side preview, the snippet shows how to limit memory usage while assembling the final JPEG with Aspose.Imaging.
 */
