// HOW-TO: Rotate GIF 30 Degrees With Black Background And Save To MemoryStream In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input path
        string inputPath = @"C:\temp\sample.gif";

        // Ensure the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the GIF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to GifImage to access Rotate method
                GifImage gif = (GifImage)image;

                // Rotate 30 degrees clockwise, resize proportionally, black background
                gif.Rotate(30f, true, Color.Black);

                // Save the rotated image to a MemoryStream in GIF format
                using (MemoryStream stream = new MemoryStream())
                {
                    gif.Save(stream, new GifOptions());

                    // Example: display the size of the resulting stream
                    Console.WriteLine($"Rotated image saved to memory stream. Size: {stream.Length} bytes");
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
 * 1. When you need to rotate an animated GIF by a specific angle and embed it directly into a response without writing to disk.
 * 2. When generating thumbnails for a web service that requires the rotated image to be kept in memory for further processing.
 * 3. When applying a custom background color to fill empty corners after rotating a GIF for a marketing email attachment.
 * 4. When converting user‑uploaded GIFs to a standardized orientation before storing them in a database as binary data.
 * 5. When creating a server‑side image pipeline that manipulates GIF frames and streams the result to another API.
 */
