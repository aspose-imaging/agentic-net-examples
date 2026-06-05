using System;
using System.IO;
using System.Net.Sockets;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputPath = @"C:\Images\sample.otg";
        string outputPath = @"C:\Images\output.jpg";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare JPEG save options
                var jpegOptions = new JpegOptions
                {
                    Quality = 90 // optional quality setting
                };

                // Connect to a TCP server (replace with actual host/port as needed)
                using (TcpClient client = new TcpClient("localhost", 9000))
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