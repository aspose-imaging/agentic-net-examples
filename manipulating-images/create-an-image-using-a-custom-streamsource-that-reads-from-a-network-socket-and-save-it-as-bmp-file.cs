using System;
using System.IO;
using System.Net.Sockets;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded output path
        string outputPath = "Output/image.bmp";

        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Connect to a network socket (example: localhost:12345)
            using (TcpClient client = new TcpClient("localhost", 12345))
            using (NetworkStream netStream = client.GetStream())
            {
                // Create image options with a StreamSource based on the network stream
                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.Source = new StreamSource(netStream, false);

                // Create a blank image of desired size
                using (Image image = Image.Create(bmpOptions, 500, 500))
                {
                    // Optional drawing: fill background with a color
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Color.LightBlue);

                    // Save the image as BMP
                    image.Save(outputPath, new BmpOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}