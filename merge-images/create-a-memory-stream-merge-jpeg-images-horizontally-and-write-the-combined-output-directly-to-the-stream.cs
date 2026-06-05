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

            // Verify each input file exists
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
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions for horizontal merge
            int totalWidth = 0;
            int maxHeight = 0;
            foreach (Aspose.Imaging.Size sz in sizes)
            {
                totalWidth += sz.Width;
                if (sz.Height > maxHeight)
                    maxHeight = sz.Height;
            }

            // Create a memory stream to hold the merged JPEG
            using (MemoryStream outputStream = new MemoryStream())
            {
                // Set JPEG options with the stream as the source
                JpegOptions jpegOptions = new JpegOptions()
                {
                    Quality = 100,
                    Source = new StreamSource(outputStream, true)
                };

                // Create a JPEG canvas bound to the stream
                using (JpegImage canvas = new JpegImage(jpegOptions, totalWidth, maxHeight))
                {
                    int offsetX = 0;
                    foreach (string path in inputPaths)
                    {
                        using (RasterImage img = (RasterImage)Image.Load(path))
                        {
                            Aspose.Imaging.Rectangle bounds = new Aspose.Imaging.Rectangle(offsetX, 0, img.Width, img.Height);
                            int[] pixels = img.LoadArgb32Pixels(img.Bounds);
                            canvas.SaveArgb32Pixels(bounds, pixels);
                            offsetX += img.Width;
                        }
                    }

                    // Save the canvas to the bound memory stream
                    canvas.Save();
                }

                // At this point, outputStream contains the merged JPEG data.
                // Example: write the stream length to console
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
 * 1. When a web service needs to generate a side‑by‑side photo collage from user‑uploaded JPEGs and return the result directly in the HTTP response without creating temporary files.
 * 2. When an email‑marketing application must combine product thumbnail JPEGs into a single banner image on the fly and embed the stream into the email body.
 * 3. When a desktop reporting tool creates a printable PDF page that includes a horizontally merged JPEG strip of chart screenshots, using a memory stream to avoid disk I/O.
 * 4. When a mobile backend assembles multiple camera‑taken JPEG frames into a panoramic preview and streams the combined image to the client app.
 * 5. When a cloud function processes uploaded JPEG assets, stitches them horizontally for a social‑media preview, and stores the resulting stream directly into a blob storage service.
 */