// HOW-TO: Create BMP Image From TCP Socket Stream Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output BMP file path
            string outputPath = Path.Combine("Output", "image.bmp");
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Network source (replace with actual host and port)
            string host = "example.com";
            int port = 12345;

            // Connect to the remote socket and obtain the stream
            using (var client = new System.Net.Sockets.TcpClient(host, port))
            using (var networkStream = client.GetStream())
            {
                // Wrap the network stream in a StreamSource for Aspose.Imaging
                var source = new StreamSource(networkStream, true);

                // Configure BMP options with the custom source
                var bmpOptions = new BmpOptions
                {
                    Source = source
                };

                // Create an image from the stream (size can be adjusted as needed)
                using (Image image = Image.Create(bmpOptions, 500, 500))
                {
                    // Save the created image to the BMP file
                    image.Save(outputPath);
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
 * 1. When you need to generate a BMP file from image data received over a live network connection, such as a remote camera feed.
 * 2. When integrating a server application that receives raw pixel data via TCP and must store it as a BMP for later processing.
 * 3. When building a cross‑platform service that captures screenshots from a client device and saves them locally as BMP using Aspose.Imaging.
 * 4. When converting streamed image data from a custom protocol into a standard BMP format without first writing the stream to disk.
 * 5. When developing a diagnostic tool that reads image bytes from a socket, creates an image object, and writes it to a BMP file for debugging.
 */
