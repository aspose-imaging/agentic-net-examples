using System;
using System.IO;
using System.Net.Sockets;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\output.bmp";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Connect to a network socket (example: localhost on port 5000)
            using (TcpClient client = new TcpClient())
            {
                client.Connect("127.0.0.1", 5000);
                using (NetworkStream netStream = client.GetStream())
                {
                    // Wrap the network stream in a StreamSource; dispose when done
                    var streamSource = new StreamSource(netStream, true);

                    // Set up BMP options with the custom source
                    var bmpOptions = new BmpOptions
                    {
                        Source = streamSource
                    };

                    // Create a new 500x500 image using the options
                    using (Image image = Image.Create(bmpOptions, 500, 500))
                    {
                        // Optional: clear the image with a background color
                        var graphics = new Graphics(image);
                        graphics.Clear(Color.LightBlue);

                        // Save the image as BMP to the specified path
                        image.Save(outputPath);
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

/*
 * Real-World Use Cases:
 * 1. When a developer needs to generate a BMP image on the fly from data received over a TCP socket, such as rendering a live chart sent by a remote sensor, and save it to disk.
 * 2. When an application must create a 500x500 bitmap with a custom background color using Aspose.Imaging while reading the image source from a network stream instead of a local file.
 * 3. When a server‑side service receives raw pixel data through a socket connection and must convert it into a standard BMP file for downstream processing or archival.
 * 4. When integrating real‑time image generation into a C# client that pulls image data from a remote device via a network stream and needs to persist the result as a BMP file on Windows.
 * 5. When troubleshooting or logging visual data transmitted over a network, a developer can use this code to capture the stream, create a BMP image with Aspose.Imaging, and store it for analysis.
 */