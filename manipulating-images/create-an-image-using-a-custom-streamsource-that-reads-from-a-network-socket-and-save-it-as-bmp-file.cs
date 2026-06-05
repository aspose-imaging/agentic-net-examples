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
            // Hardcoded network endpoint
            string host = "localhost";
            int port = 9000;

            // Hardcoded output file path
            string outputPath = @"C:\Temp\output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Connect to the server and read image data from the socket
            using (TcpClient client = new TcpClient(host, port))
            using (NetworkStream networkStream = client.GetStream())
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Read all data from the network stream into a memory stream
                networkStream.CopyTo(memoryStream);
                memoryStream.Position = 0;

                // Load the image from the received stream
                using (Image image = Image.Load(memoryStream))
                {
                    // Save the loaded image as BMP to the specified file
                    BmpOptions bmpOptions = new BmpOptions();
                    image.Save(outputPath, bmpOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}