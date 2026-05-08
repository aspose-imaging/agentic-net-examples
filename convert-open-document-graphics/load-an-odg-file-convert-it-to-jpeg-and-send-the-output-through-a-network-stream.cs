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
            // Hardcoded input ODG file path
            string inputPath = "sample.odg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the ODG image
            using (Image odgImage = Image.Load(inputPath))
            {
                // Prepare JPEG save options
                var jpegOptions = new JpegOptions();

                // Network destination (hardcoded host and port)
                string host = "127.0.0.1";
                int port = 9000;

                // Connect and obtain a network stream
                using (TcpClient client = new TcpClient(host, port))
                using (NetworkStream networkStream = client.GetStream())
                {
                    // Send the JPEG data through the network stream
                    odgImage.Save(networkStream, jpegOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}