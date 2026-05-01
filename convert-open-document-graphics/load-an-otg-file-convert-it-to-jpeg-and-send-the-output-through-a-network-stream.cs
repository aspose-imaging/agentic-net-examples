using System;
using System.IO;
using System.Net.Sockets;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input OTG file path
            string inputPath = @"C:\Images\sample.otg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the OTG image
            using (Image otgImage = Image.Load(inputPath))
            {
                // Configure JPEG save options
                JpegOptions jpegOptions = new JpegOptions();

                // Set rasterization options so the vector OTG is rendered to raster before JPEG encoding
                OtgRasterizationOptions rasterOptions = new OtgRasterizationOptions
                {
                    PageSize = otgImage.Size
                };
                jpegOptions.VectorRasterizationOptions = rasterOptions;

                // Network destination (replace with actual server/port as needed)
                string server = "127.0.0.1";
                int port = 9000;

                // Connect to the server and obtain a network stream
                using (TcpClient client = new TcpClient())
                {
                    client.Connect(server, port);
                    using (NetworkStream netStream = client.GetStream())
                    {
                        // Save the JPEG directly into the network stream
                        otgImage.Save(netStream, jpegOptions);
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