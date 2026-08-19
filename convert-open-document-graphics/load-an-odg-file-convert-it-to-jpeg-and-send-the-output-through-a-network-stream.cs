// HOW-TO: Convert ODG to JPEG and Stream Over TCP in C# (Aspose.Imaging for .NET)
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
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.odg";
            string outputPath = @"C:\Images\output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to OdgImage
                OdgImage odgImage = image as OdgImage;
                if (odgImage == null)
                {
                    Console.Error.WriteLine("Loaded image is not an ODG image.");
                    return;
                }

                // Prepare JPEG save options
                JpegOptions jpegOptions = new JpegOptions();

                // Save as JPEG to the output path
                odgImage.Save(outputPath, jpegOptions);

                // Send the JPEG file through a network stream
                using (FileStream fileStream = new FileStream(outputPath, FileMode.Open, FileAccess.Read))
                {
                    string host = "127.0.0.1";
                    int port = 5000;
                    using (TcpClient client = new TcpClient())
                    {
                        client.Connect(host, port);
                        using (NetworkStream netStream = client.GetStream())
                        {
                            fileStream.CopyTo(netStream);
                            netStream.Flush();
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
 * 1. When you need to display an OpenDocument graphic on a web page that only supports JPEG images.
 * 2. When you must send a converted image from a desktop application to a remote server or service via a TCP socket.
 * 3. When you are building a batch process that converts ODG drawings to JPEG files before archiving them on a network share.
 * 4. When you want to preview ODG diagrams in a thin client that can only render JPEG streams.
 * 5. When you integrate a legacy CAD system that outputs ODG files and need to transmit the rasterized result to a mobile device in real time.
 */
