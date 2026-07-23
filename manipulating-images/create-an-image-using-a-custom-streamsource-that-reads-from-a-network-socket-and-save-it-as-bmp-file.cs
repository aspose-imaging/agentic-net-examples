using System;
using System.IO;
using System.Net.Sockets;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded network endpoint
            string host = "127.0.0.1";
            int port = 9000;

            // Hardcoded output path
            string outputPath = @"C:\temp\output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Connect to the server and obtain a network stream
            using (TcpClient client = new TcpClient())
            {
                client.Connect(host, port);
                using (NetworkStream netStream = client.GetStream())
                {
                    // Read all data from the network into a memory stream
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        netStream.CopyTo(memoryStream);
                        memoryStream.Position = 0; // reset for reading

                        // Wrap the memory stream in a StreamSource
                        StreamSource streamSource = new StreamSource(memoryStream, false);

                        // Load the image from the StreamSource's stream
                        using (Image image = Image.Load(streamSource.Stream))
                        {
                            // Save the image as BMP to the specified output path
                            image.Save(outputPath);
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

/*
 * Real-World Use Cases:
 * 1. When a developer needs to receive raw image bytes from a remote device over a TCP socket and convert them to a BMP file using Aspose.Imaging in a C# application.
 * 2. When an IoT camera streams JPEG data through a network connection and the backend service must load the stream and save a BMP version for legacy processing pipelines.
 * 3. When a real‑time monitoring system captures screenshots from a remote server via a socket and the client program must read the stream, load the image with Aspose.Imaging, and store it as a BMP on disk.
 * 4. When a desktop utility downloads image data from a custom binary protocol over TCP, wraps the data in a StreamSource, and uses Aspose.Imaging to persist the image as a BMP for further analysis.
 * 5. When a C# service integrates with a third‑party imaging device that pushes image data over a network socket, requiring the code to read the stream, load the image, and save it as a BMP file for archival purposes.
 */