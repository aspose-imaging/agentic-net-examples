// HOW-TO: Merge Multiple JPEG Images Horizontally into a Memory Stream in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
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

            // Collect sizes
            List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions for horizontal merge
            int totalWidth = 0;
            int maxHeight = 0;
            foreach (var sz in sizes)
            {
                totalWidth += sz.Width;
                if (sz.Height > maxHeight) maxHeight = sz.Height;
            }

            // Create memory stream for output
            using (MemoryStream outputStream = new MemoryStream())
            {
                // Set up JPEG options with stream source
                StreamSource streamSource = new StreamSource(outputStream);
                JpegOptions jpegOptions = new JpegOptions()
                {
                    Source = streamSource,
                    Quality = 100
                };

                // Create canvas image bound to the stream
                using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, totalWidth, maxHeight))
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

                    // Save canvas to the bound stream
                    canvas.Save();
                }

                // At this point, outputStream contains the merged JPEG image.
                // Optionally, reset position for further processing.
                outputStream.Position = 0;
                // Example: write to a file (not required by task)
                // File.WriteAllBytes("merged.jpg", outputStream.ToArray());
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
 * 1. When you need to create a single panoramic JPEG from several product photos on a web server without writing temporary files.
 * 2. When generating a combined thumbnail strip of user‑uploaded JPEGs for a mobile app and you want the result directly in a MemoryStream for further API transmission.
 * 3. When building an email attachment that contains multiple scanned JPEG pages stitched side‑by‑side, and you must keep the image in memory to embed it without disk I/O.
 * 4. When processing images in a cloud function that merges JPEG banners horizontally and streams the output to another service such as Azure Blob Storage.
 * 5. When creating a printable collage of JPEG screenshots in a desktop application and need the final image in a stream for immediate saving or printing.
 */
