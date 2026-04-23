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
        // Hard‑coded input ODG file path
        string inputPath = @"C:\temp\sample.odg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the ODG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to OdgImage to access ODG‑specific features if needed
            OdgImage odgImage = image as OdgImage;
            if (odgImage == null)
            {
                Console.Error.WriteLine("Failed to load ODG image.");
                return;
            }

            // Prepare JPEG save options (default options are sufficient for basic conversion)
            JpegOptions jpegOptions = new JpegOptions();

            // Connect to the remote endpoint (hard‑coded host and port)
            using (TcpClient client = new TcpClient("localhost", 9000))
            using (NetworkStream networkStream = client.GetStream())
            {
                // Send the JPEG data directly over the network stream
                // The Save overload writes the image data to the provided stream using the specified options
                odgImage.Save(networkStream, jpegOptions);
            }
        }
    }
}