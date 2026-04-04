using System;
using System.IO;
using System.Net.Sockets;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Connect to a network socket (example: localhost:9000)
        // The socket is used only to obtain a Stream for the StreamSource.
        using (TcpClient client = new TcpClient())
        {
            try
            {
                client.Connect("127.0.0.1", 9000);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unable to connect to socket: {ex.Message}");
                return;
            }

            using (NetworkStream networkStream = client.GetStream())
            {
                // Create BMP options and assign the custom StreamSource
                BmpOptions bmpOptions = new BmpOptions
                {
                    Source = new StreamSource(networkStream)
                };

                // Create a new blank image (e.g., 500x500 pixels)
                using (Image image = Image.Create(bmpOptions, 500, 500))
                {
                    // Save the image to the specified BMP file
                    image.Save(outputPath);
                }
            }
        }
    }
}