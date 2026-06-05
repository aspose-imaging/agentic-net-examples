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
            // Hardcoded paths and network endpoint
            string inputPath = "input.odg";
            string outputPath = "output.jpg";
            string host = "localhost";
            int port = 9000;

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load ODG image
            using (Image odgImage = Image.Load(inputPath))
            {
                // Prepare JPEG save options
                var jpegOptions = new JpegOptions();

                // Save JPEG to a memory stream
                using (var memoryStream = new MemoryStream())
                {
                    odgImage.Save(memoryStream, jpegOptions);
                    memoryStream.Position = 0;

                    // Send JPEG data over network
                    using (var client = new TcpClient())
                    {
                        client.Connect(host, port);
                        using (NetworkStream networkStream = client.GetStream())
                        {
                            memoryStream.CopyTo(networkStream);
                        }
                    }

                    // Also write JPEG to file system
                    using (var fileStream = File.OpenWrite(outputPath))
                    {
                        memoryStream.Position = 0;
                        memoryStream.CopyTo(fileStream);
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