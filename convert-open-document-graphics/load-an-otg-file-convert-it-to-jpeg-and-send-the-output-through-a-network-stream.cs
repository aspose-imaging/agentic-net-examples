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
        string inputPath = @"C:\Images\sample.otg";
        string outputPath = @"C:\Images\output.jpg";

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
            // Prepare JPEG save options with OTG rasterization settings
            var jpegOptions = new JpegOptions();
            var otgRaster = new OtgRasterizationOptions
            {
                PageSize = image.Size // preserve original size
            };
            jpegOptions.VectorRasterizationOptions = otgRaster;

            // Connect to a TCP server and send the JPEG data through the network stream
            using (TcpClient client = new TcpClient("localhost", 5000))
            using (NetworkStream netStream = client.GetStream())
            {
                // Save the image directly to the network stream in JPEG format
                image.Save(netStream, jpegOptions);
            }
        }
    }
}