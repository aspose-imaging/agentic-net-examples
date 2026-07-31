using System;
using System.IO;
using System.Collections.Generic;
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
            string[] inputPaths = { "image1.jpg", "image2.jpg", "image3.jpg" };

            // Validate input files
            foreach (string path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Collect sizes of all images
            List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
            foreach (string path in inputPaths)
            {
                using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions for horizontal merge
            int newWidth = 0;
            int newHeight = 0;
            foreach (var sz in sizes)
            {
                newWidth += sz.Width;
                if (sz.Height > newHeight) newHeight = sz.Height;
            }

            // Prepare output memory stream
            using (MemoryStream outputStream = new MemoryStream())
            {
                // JPEG options bound to the stream
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 100,
                    Source = new StreamSource(outputStream, false)
                };

                // Create JPEG canvas
                using (JpegImage canvas = (JpegImage)Aspose.Imaging.Image.Create(jpegOptions, newWidth, newHeight))
                {
                    int offsetX = 0;
                    foreach (string path in inputPaths)
                    {
                        using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(path))
                        {
                            Aspose.Imaging.Rectangle bounds = new Aspose.Imaging.Rectangle(offsetX, 0, img.Width, img.Height);
                            canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                            offsetX += img.Width;
                        }
                    }

                    // Save the bound image to the stream
                    canvas.Save();
                }

                // At this point, outputStream contains the merged JPEG image
                // Example: reset position if needed for further processing
                outputStream.Position = 0;
                // (Optional) write stream length to console
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
 * 1. When a web application needs to generate a side‑by‑side preview of multiple product photos and send the combined JPEG directly to the browser without creating temporary files.
 * 2. When an email service must attach a single composite image that stitches together scanned receipts before encoding it into a MIME stream.
 * 3. When a reporting tool creates a printable banner by concatenating chart images horizontally and streams the result to a PDF generator.
 * 4. When a mobile backend assembles user‑uploaded profile pictures into a collage and returns the merged JPEG as a byte array for API consumption.
 * 5. When a cloud function merges satellite image tiles into a wide‑format JPEG and writes the output to a memory stream for storage in a blob container.
 */