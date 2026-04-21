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
        // Hardcoded input and output paths
        string inputPath = @"C:\input\sample.otg";
        string outputPath = @"C:\output\sample.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the OTG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure JPEG save options with OTG rasterization
            JpegOptions jpegOptions = new JpegOptions();
            OtgRasterizationOptions otgRaster = new OtgRasterizationOptions
            {
                PageSize = image.Size
            };
            jpegOptions.VectorRasterizationOptions = otgRaster;

            // Save the converted JPEG to a memory stream
            using (MemoryStream memory = new MemoryStream())
            {
                image.Save(memory, jpegOptions);
                memory.Position = 0; // Reset stream position for reading

                // Send the JPEG data over a network stream
                string host = "127.0.0.1";
                int port = 9000;
                using (TcpClient client = new TcpClient())
                {
                    client.Connect(host, port);
                    using (NetworkStream netStream = client.GetStream())
                    {
                        memory.CopyTo(netStream);
                        netStream.Flush();
                    }
                }
            }
        }
    }
}