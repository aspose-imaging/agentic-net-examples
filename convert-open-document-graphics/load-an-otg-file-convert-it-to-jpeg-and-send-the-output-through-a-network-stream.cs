using System;
using System.IO;
using System.Net.Sockets;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.otg";
        string outputPath = @"C:\Images\output.jpg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare JPEG save options
                var jpegOptions = new JpegOptions();

                // Connect to a TCP server and obtain the network stream
                using (var client = new TcpClient("127.0.0.1", 5000))
                using (NetworkStream networkStream = client.GetStream())
                {
                    // Save the image as JPEG directly to the network stream
                    image.Save(networkStream, jpegOptions);
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
 * 1. When a developer needs to stream a converted JPEG image from an OTG file to a remote client over a TCP connection, such as delivering thumbnails to a web service in real time.
 * 2. When a desktop application must read proprietary OTG graphics, convert them to JPEG for bandwidth‑efficient transmission, and send the result through a network socket to a server for further processing.
 * 3. When an IoT device captures images in OTG format, uses Aspose.Imaging to transform them into JPEG, and pushes the data over a TCP stream to a central monitoring system.
 * 4. When a batch job processes a folder of OTG files, converts each to JPEG on the fly, and streams the output directly to a network printer or image‑processing service without writing intermediate files.
 * 5. When a cloud‑based microservice receives OTG image uploads, converts them to JPEG using C# and Aspose.Imaging, and streams the compressed image to another service via a TCP network stream for storage or analysis.
 */