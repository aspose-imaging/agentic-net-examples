// HOW-TO: Convert ODG to PNG and Store in MemoryStream Using C# (Aspose.Imaging for .NET)
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
            string inputPath = "sample.odg";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (MemoryStream outputStream = new MemoryStream())
            {
                using (Image image = Image.Load(inputPath))
                {
                    PngOptions options = new PngOptions();
                    image.Save(outputStream, options);
                }

                outputStream.Position = 0;
                Console.WriteLine($"Converted PNG size: {outputStream.Length} bytes");
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
 * 1. When you need to generate a PNG thumbnail of an ODG drawing for a web preview without writing a temporary file.
 * 2. When you want to embed a converted PNG directly into an email attachment or API response by using a MemoryStream.
 * 3. When you are building a server‑side service that receives ODG uploads and must return PNG data to a client in real time.
 * 4. When you need to validate the size of a PNG produced from an ODG before storing it in a database or cloud storage.
 * 5. When you are creating a batch process that converts multiple ODG files to PNGs in memory to reduce I/O overhead.
 */
