using System;
using System.IO;
using System.Net.Sockets;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.OpenDocument;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
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
        using (Image baseImage = Image.Load(inputPath))
        {
            // Cast to OdgImage to access ODG-specific features
            OdgImage odgImage = baseImage as OdgImage;
            if (odgImage == null)
            {
                Console.Error.WriteLine("Failed to load ODG image.");
                return;
            }

            // Prepare JPEG save options
            JpegOptions jpegOptions = new JpegOptions
            {
                // Example: set quality to maximum
                Quality = 100
            };

            // Save the JPEG to a memory stream
            using (MemoryStream jpegStream = new MemoryStream())
            {
                odgImage.Save(jpegStream, jpegOptions);
                jpegStream.Position = 0; // Reset for reading

                // Optionally also save to file (fulfills output path rule)
                using (FileStream fileOut = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    jpegStream.CopyTo(fileOut);
                }

                // Send the JPEG data over a network stream
                try
                {
                    // Example: connect to localhost on port 5000
                    using (TcpClient client = new TcpClient("127.0.0.1", 5000))
                    using (NetworkStream netStream = client.GetStream())
                    {
                        jpegStream.CopyTo(netStream);
                        netStream.Flush();
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Network error: {ex.Message}");
                }
            }
        }
    }
}