// HOW-TO: Convert OTG to JPEG and Stream Over TCP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Net.Sockets;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace OtgToJpegNetwork
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.otg";
                string outputPath = "output.jpg";
                string server = "localhost";
                int port = 5000;

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var jpegOptions = new JpegOptions();
                    image.Save(outputPath, jpegOptions);
                }

                byte[] jpegData = File.ReadAllBytes(outputPath);

                using (TcpClient client = new TcpClient(server, port))
                using (NetworkStream networkStream = client.GetStream())
                {
                    networkStream.Write(jpegData, 0, jpegData.Length);
                    networkStream.Flush();
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
 * 1. When you need to display a vector OTG diagram on a web client that only supports JPEG images, you can convert the file and send it over a TCP connection.
 * 2. When a remote imaging service expects JPEG payloads via a socket, you can load the OTG source, compress it to JPEG, and stream the bytes to the server.
 * 3. When building a real‑time monitoring dashboard that receives image updates from a device generating OTG files, you can convert each file to JPEG and push it through a network stream to the dashboard.
 * 4. When integrating legacy CAD data (OTG) into a mobile app that cannot read the original format, you can convert the file to JPEG on the server and transmit it via TCP for efficient delivery.
 * 5. When automating batch processing that reads OTG files from a folder, converts them to JPEG, and forwards the results to another system for further analysis, this code handles the conversion and network transmission in one step.
 */
