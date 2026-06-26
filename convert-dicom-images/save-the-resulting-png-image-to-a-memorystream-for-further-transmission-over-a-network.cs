using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input path
        string inputPath = @"C:\temp\sample.bmp";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the image from the file
            using (Image image = Image.Load(inputPath))
            {
                // Set up PNG save options (default settings)
                PngOptions pngOptions = new PngOptions();

                // Save the image to a memory stream for network transmission
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    image.Save(memoryStream, pngOptions);

                    // Reset the stream position if it will be read later
                    memoryStream.Position = 0;

                    // Example output: report the size of the PNG data
                    Console.WriteLine($"PNG image saved to memory stream, size: {memoryStream.Length} bytes");
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
 * 1. When a web API must convert a BMP file to PNG and return the image to a client without creating a temporary file, this code loads the bitmap, saves it to a MemoryStream, and streams the PNG bytes over HTTP.
 * 2. When an email service needs to attach a PNG thumbnail generated from a user‑uploaded bitmap, the developer can use this code to produce the PNG in memory and add the stream’s byte array as an attachment.
 * 3. When a real‑time chat application wants to share screen captures as PNG data through a WebSocket, the code converts the BMP to a MemoryStream so the PNG payload can be sent instantly.
 * 4. When a cloud function processes uploaded BMP images and returns a compressed PNG response to a REST endpoint, the MemoryStream eliminates disk I/O and provides the PNG size for logging.
 * 5. When a mobile backend must resize and re‑encode BMP assets to PNG before streaming them to a Xamarin app, this code saves the PNG to a MemoryStream so the binary data can be streamed directly to the device.
 */