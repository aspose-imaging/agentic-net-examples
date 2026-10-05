// HOW-TO: Convert ODG to JPEG and Stream Over TCP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Net.Sockets;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace OdgToJpegNetwork
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded paths and network settings
                string inputPath = "input.odg";
                string outputPath = "output\\output.jpg";
                string host = "localhost";
                int port = 5000;

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load ODG image
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare JPEG options
                    JpegOptions jpegOptions = new JpegOptions
                    {
                        Quality = 90
                    };

                    // Save to file
                    image.Save(outputPath, jpegOptions);

                    // Also save to memory stream for network transmission
                    using (MemoryStream ms = new MemoryStream())
                    {
                        image.Save(ms, jpegOptions);
                        byte[] jpegBytes = ms.ToArray();

                        // Send over network
                        using (TcpClient client = new TcpClient())
                        {
                            client.Connect(host, port);
                            using (NetworkStream networkStream = client.GetStream())
                            {
                                networkStream.Write(jpegBytes, 0, jpegBytes.Length);
                                networkStream.Flush();
                            }
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
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate a JPEG preview of an ODG drawing and store it on disk for later use.
 * 2. When a server application must send a converted JPEG image of an ODG file to a remote client over a TCP connection.
 * 3. When an automated pipeline processes OpenDocument graphics files and delivers the resulting JPEGs to another service without manual intervention.
 * 4. When you want to ensure the output directory exists before saving the JPEG to avoid runtime errors.
 * 5. When you require a specific JPEG quality setting while converting ODG files for bandwidth‑controlled network transmission.
 */
