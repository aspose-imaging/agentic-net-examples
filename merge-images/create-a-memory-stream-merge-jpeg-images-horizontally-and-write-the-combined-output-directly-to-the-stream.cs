// HOW-TO: Merge Multiple JPEG Images Horizontally Into a MemoryStream in C# (Aspose.Imaging for .NET)
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
                "image1.jpg",
                "image2.jpg",
                "image3.jpg"
            };

            // Validate each input file
            foreach (string path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Load images to collect sizes
            List<Size> sizes = new List<Size>();
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions for horizontal merge
            int canvasWidth = sizes.Sum(s => s.Width);
            int canvasHeight = sizes.Max(s => s.Height);

            // Prepare output memory stream
            using (MemoryStream outputStream = new MemoryStream())
            {
                // Configure JPEG options with the stream as source
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 90,
                    Source = new StreamSource(outputStream, true)
                };

                // Create bound JPEG canvas
                using (JpegImage canvas = new JpegImage(jpegOptions, canvasWidth, canvasHeight))
                {
                    int offsetX = 0;
                    foreach (string path in inputPaths)
                    {
                        using (RasterImage img = (RasterImage)Image.Load(path))
                        {
                            Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                            canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                            offsetX += img.Width;
                        }
                    }

                    // Save the bound canvas (writes to the stream)
                    canvas.Save();
                }

                // At this point, outputStream contains the merged JPEG image
                // Example: display the size of the resulting stream
                Console.WriteLine($"Merged image size in bytes: {outputStream.Length}");
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
 * 1. When you need to combine several JPEG photos side‑by‑side for a web gallery without creating temporary files on disk.
 * 2. When you want to generate a single composite JPEG on the fly and send it directly over a network stream or API response.
 * 3. When you are building a PDF or email attachment that requires a horizontally stitched image but must keep everything in memory for performance.
 * 4. When you need to batch process product images, merging them into one banner image for a marketing email while avoiding I/O overhead.
 * 5. When you are creating a thumbnail strip of screenshots for a UI preview and need the result stored in a MemoryStream for further manipulation.
 */
