using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input file path
            string inputPath = @"C:\temp\sample.bmp";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the image from the file
            using (Image image = Image.Load(inputPath))
            {
                // Example operation: rotate the image 180 degrees
                image.RotateFlip(RotateFlipType.Rotate180FlipNone);

                // Set up PNG save options
                PngOptions pngOptions = new PngOptions();

                // Save the image to a MemoryStream
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    image.Save(memoryStream, pngOptions);

                    // The MemoryStream now contains the PNG data.
                    // For demonstration, write the size of the PNG data.
                    Console.WriteLine($"PNG image size (bytes): {memoryStream.Length}");

                    // The MemoryStream can be sent over a network as needed.
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
 * 1. When a web API needs to return a rotated PNG image directly in the HTTP response without writing a temporary file to disk.
 * 2. When a real‑time chat application must embed a user‑uploaded bitmap, rotate it, and stream the PNG bytes to the client over a WebSocket connection.
 * 3. When a cloud‑based image‑processing microservice processes BMP files, applies transformations, and stores the resulting PNG in a database BLOB via a MemoryStream.
 * 4. When an IoT device captures a BMP sensor image, rotates it for correct orientation, and sends the PNG payload to a remote monitoring server using a TCP socket.
 * 5. When a desktop application generates a thumbnail preview of a rotated image and passes the PNG data in a MemoryStream to another component for further manipulation or printing.
 */