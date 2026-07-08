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

            // Validate input files
            foreach (string path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Prepare output memory stream
            using (MemoryStream outputStream = new MemoryStream())
            {
                // JPEG creation options bound to the memory stream
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 90,
                    Source = new StreamSource(outputStream, false)
                };

                // Collect sizes of all input images
                List<Size> sizes = new List<Size>();
                foreach (string path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        sizes.Add(img.Size);
                    }
                }

                // Calculate canvas dimensions for horizontal merge
                int newWidth = sizes.Sum(s => s.Width);
                int newHeight = sizes.Max(s => s.Height);

                // Create JPEG canvas bound to the memory stream
                using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, newWidth, newHeight))
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

                    // Save the merged image into the bound stream
                    canvas.Save();
                }

                // At this point, outputStream contains the merged JPEG data
                outputStream.Position = 0;
                Console.WriteLine($"Merged image size in bytes: {outputStream.Length}");
                // The stream can be used further as needed
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
 * 1. When a web application needs to generate a single panoramic JPEG from multiple product photos on the fly and send it directly to the client without creating temporary files.
 * 2. When an email service composes a promotional newsletter that combines several banner images into one horizontal JPEG and streams it as an attachment.
 * 3. When a mobile backend assembles user‑uploaded screenshots into a side‑by‑side comparison image and stores the result in a database as a byte array.
 * 4. When a reporting tool creates a composite chart by stitching together separate JPEG graphs and writes the merged image to a memory stream for PDF embedding.
 * 5. When an automated testing framework captures screenshots of different UI states, merges them horizontally, and feeds the combined JPEG into a visual‑diff algorithm without touching the file system.
 */