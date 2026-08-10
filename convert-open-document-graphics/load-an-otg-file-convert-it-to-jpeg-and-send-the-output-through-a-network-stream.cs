// HOW-TO: Convert OTG Image To JPEG And Stream Over TCP In C# (Aspose.Imaging for .NET)
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
            // Hardcoded input OTG file path
            string inputPath = @"C:\Images\sample.otg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the OTG image using Aspose.Imaging.Image.Load
            using (Image otgImage = Image.Load(inputPath))
            {
                // Prepare JPEG save options
                var jpegOptions = new JpegOptions();

                // Save the image to a memory stream in JPEG format
                using (var jpegStream = new MemoryStream())
                {
                    otgImage.Save(jpegStream, jpegOptions);
                    jpegStream.Position = 0; // Reset stream position for reading

                    // Connect to a TCP server (hardcoded host and port)
                    using (var client = new TcpClient("localhost", 5000))
                    using (NetworkStream networkStream = client.GetStream())
                    {
                        // Send JPEG data over the network stream
                        jpegStream.CopyTo(networkStream);
                        networkStream.Flush();
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
 * 1. When you need to send a vector OTG drawing from a desktop app to a server that only accepts JPEG streams.
 * 2. When integrating a legacy CAD system that outputs OTG files with a modern web service that processes JPEG images over a TCP socket.
 * 3. When building a real‑time imaging pipeline that converts high‑resolution OTG graphics to compressed JPEGs before transmitting them to remote clients.
 * 4. When automating batch processing that reads OTG files, compresses them to JPEG, and pushes the result to a network printer or image‑processing server.
 * 5. When creating a lightweight C# service that streams converted OTG images to a cloud endpoint without writing temporary files to disk.
 */
