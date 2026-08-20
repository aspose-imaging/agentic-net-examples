// HOW-TO: Merge JPEG Images From Network Stream And Return Combined JPEG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded default paths (required by the safety rules)
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            // Verify input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up a TCP listener to receive JPEG images
            const int port = 5000;
            TcpListener listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            Console.WriteLine($"Listening on port {port}...");

            using (TcpClient client = listener.AcceptTcpClient())
            using (NetworkStream netStream = client.GetStream())
            {
                // Read the number of images (Int32, little‑endian)
                byte[] intBuf = new byte[4];
                netStream.Read(intBuf, 0, 4);
                int imageCount = BitConverter.ToInt32(intBuf, 0);

                var loadedImages = new List<Image>();

                // Load each JPEG image from the stream
                for (int i = 0; i < imageCount; i++)
                {
                    // Read length of the current image
                    netStream.Read(intBuf, 0, 4);
                    int length = BitConverter.ToInt32(intBuf, 0);

                    // Read the image bytes
                    byte[] imgData = new byte[length];
                    int read = 0;
                    while (read < length)
                    {
                        int bytesRead = netStream.Read(imgData, read, length - read);
                        if (bytesRead == 0) break;
                        read += bytesRead;
                    }

                    // Load JPEG from memory stream using the JpegImage(Stream) constructor
                    using (MemoryStream ms = new MemoryStream(imgData))
                    {
                        var jpeg = new JpegImage(ms);
                        loadedImages.Add(jpeg);
                    }
                }

                // Determine dimensions for the vertically merged image
                int maxWidth = loadedImages.Max(img => img.Width);
                int totalHeight = loadedImages.Sum(img => img.Height);

                // Create a blank JPEG canvas with the calculated size
                var createOptions = new JpegOptions();
                using (RasterImage merged = (RasterImage)Image.Create(createOptions, maxWidth, totalHeight))
                {
                    var graphics = new Graphics(merged);
                    int yOffset = 0;

                    // Draw each loaded image onto the canvas
                    foreach (var img in loadedImages)
                    {
                        graphics.DrawImage(img, new Rectangle(0, yOffset, img.Width, img.Height));
                        yOffset += img.Height;
                        img.Dispose();
                    }

                    // Save the merged image back to the network stream as JPEG
                    var saveOptions = new JpegOptions();
                    merged.Save(netStream, saveOptions);
                }
            }

            listener.Stop();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web service needs to receive multiple JPEG photos uploaded over a TCP connection, combine them vertically, and send back a single JPEG for display in a gallery.
 * 2. When building a remote printing solution that streams scanned page images as JPEGs to a server, merges them into one continuous image, and returns the merged file for printing.
 * 3. When creating a surveillance system that collects sequential camera snapshots over a network, stitches them top‑to‑bottom, and provides the combined JPEG to a monitoring dashboard.
 * 4. When developing a mobile app backend that uploads user‑taken screenshots as separate JPEGs, merges them into a single image for easier sharing, and returns the result to the client.
 * 5. When implementing an IoT device that streams sensor‑captured JPEG frames to a central server, concatenates them vertically for a composite view, and sends the final JPEG back for storage.
 */
