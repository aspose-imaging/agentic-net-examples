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
            // Hardcoded input path
            string inputPath = @"C:\temp\sample.bmp";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Process the image and obtain the result as a byte array
            byte[] imageBytes = ProcessImageToByteArray(inputPath);

            // Example usage of the resulting byte array
            Console.WriteLine($"Resulting byte array length: {imageBytes.Length}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Loads an image, applies a simple filter, and saves it to a MemoryStream.
    // The method returns the image data as a byte array.
    static byte[] ProcessImageToByteArray(string inputPath)
    {
        // Load the image from the specified file
        using (Image image = Image.Load(inputPath))
        {
            // Apply a filter – here we rotate the image 180 degrees
            image.RotateFlip(RotateFlipType.Rotate180FlipNone);

            // Define save options (PNG format in this example)
            PngOptions saveOptions = new PngOptions();

            // Save the processed image to a memory stream
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, saveOptions);
                // Return the stream contents as a byte array
                return stream.ToArray();
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web API must return a rotated PNG image directly in the HTTP response, this code lets a developer process the bitmap, save it to a MemoryStream, and send the resulting byte array without creating a temporary file.
 * 2. When an application needs to store a filtered image in a database BLOB column, the byte array produced by this method can be inserted into a varbinary field, eliminating the need for intermediate file storage.
 * 3. When generating an email attachment on the fly, a developer can apply the rotation filter, convert the image to a byte array, and attach it to a MailMessage without writing the image to disk.
 * 4. When a background service creates thumbnails for a document management system, it can use this code to process the source bitmap, obtain a PNG byte array, and pass it to another service that consumes image data in memory.
 * 5. When a mobile backend streams a transformed image to a client app over a WebSocket, the byte array returned from this method can be transmitted directly, reducing I/O overhead and speeding up delivery.
 */