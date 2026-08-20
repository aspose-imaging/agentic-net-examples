// HOW-TO: Save BMP Image to MemoryStream for In-Memory Processing in C# (Aspose.Imaging for .NET)
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
            // Hard‑coded input path
            string inputPath = @"C:\temp\sample.bmp";

            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the BMP image from disk
            using (Image image = Image.Load(inputPath))
            {
                // Prepare BMP save options (default settings)
                BmpOptions saveOptions = new BmpOptions();

                // Save the image into a memory stream for further in‑memory processing
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    image.Save(memoryStream, saveOptions);
                    // Reset the stream position if it will be read later
                    memoryStream.Position = 0;

                    Console.WriteLine($"Image saved to memory stream. Size = {memoryStream.Length} bytes.");
                    // Additional in‑memory processing can be performed here
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
 * 1. When you need to load a BMP file, convert it with Aspose.Imaging and keep the result in a MemoryStream instead of writing to disk, such as when passing the image to another API that expects a stream.
 * 2. When you want to embed a BMP image directly into a database BLOB field without creating a temporary file, you can save it to a MemoryStream and store the byte array.
 * 3. When you are building a web service that returns a BMP image as a response, saving the image to a MemoryStream lets you set the response body directly from memory.
 * 4. When you need to chain multiple image operations (e.g., resizing, watermarking) without intermediate files, you can keep each step’s output in a MemoryStream for fast in‑memory processing.
 * 5. When you are generating a BMP thumbnail to be sent over a message queue or saved to cloud storage, using a MemoryStream avoids filesystem I/O and simplifies the upload code.
 */
