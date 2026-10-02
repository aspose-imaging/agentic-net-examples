// HOW-TO: Load Image From Network Socket And Save As BMP In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Net.Sockets;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded paths
            string outputPath = "output/output.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Network socket parameters
            string host = "localhost";
            int port = 12345;

            // Connect to the socket and read image data
            using (TcpClient client = new TcpClient(host, port))
            using (NetworkStream networkStream = client.GetStream())
            {
                // Load image from the network stream
                using (Image image = Image.Load(networkStream))
                {
                    // Save as BMP
                    var bmpOptions = new BmpOptions();
                    image.Save(outputPath, bmpOptions);
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
 * 1. When you need to receive raw image bytes from a live camera feed over TCP and store them as BMP files for further analysis.
 * 2. When a server application streams screenshots to a client and the client must convert the incoming stream into a BMP image for archival.
 * 3. When integrating a legacy system that sends image data through a socket and you must persist the images in a format compatible with Windows applications.
 * 4. When building a monitoring tool that captures thumbnails sent over the network and saves them as BMP to ensure lossless quality.
 * 5. When developing a cross‑platform service that reads image data from a socket using Aspose.Imaging and writes it to disk as BMP for later processing.
 */
