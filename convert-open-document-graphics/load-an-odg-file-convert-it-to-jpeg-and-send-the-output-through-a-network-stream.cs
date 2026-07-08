using System;
using System.IO;
using System.Net.Sockets;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hardcoded input file and network destination
        string inputPath = "sample.odg";
        string host = "127.0.0.1";
        int port = 9000;

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to OdgImage for ODG-specific handling
                OdgImage odgImage = image as OdgImage;
                if (odgImage == null)
                {
                    Console.Error.WriteLine("Failed to load ODG image.");
                    return;
                }

                // Prepare JPEG save options
                JpegOptions jpegOptions = new JpegOptions();

                // Save JPEG to a memory stream
                using (MemoryStream jpegStream = new MemoryStream())
                {
                    odgImage.Save(jpegStream, jpegOptions);
                    jpegStream.Position = 0; // Reset stream position for reading

                    // Send the JPEG data over a TCP network stream
                    using (TcpClient client = new TcpClient(host, port))
                    using (NetworkStream networkStream = client.GetStream())
                    {
                        jpegStream.CopyTo(networkStream);
                    }
                }
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
 * 1. When a developer needs to generate a JPEG preview of an OpenDocument Graphics (ODG) file and stream it in real‑time to a client application over TCP.
 * 2. When an enterprise document‑management system must convert uploaded ODG diagrams to JPEG and send the compressed image to a remote image‑processing service.
 * 3. When a web‑based collaboration tool wants to display ODG drawings on browsers that only support JPEG by loading the ODG, converting it, and pushing the result through a network socket.
 * 4. When a C# backend service processes batch ODG files, creates JPEG thumbnails, and streams each thumbnail to a load‑balancer for further distribution.
 * 5. When a remote monitoring application receives live ODG chart updates, converts them to JPEG on the server, and transmits the image via a TCP stream to a dashboard client.
 */