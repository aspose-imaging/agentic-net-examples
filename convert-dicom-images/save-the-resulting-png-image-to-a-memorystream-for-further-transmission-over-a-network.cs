// HOW-TO: Convert TIFF to PNG and Save to MemoryStream in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace ImageConversion
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.tif";
                string outputPath = "output/output.png";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    // Save to disk as PNG
                    image.Save(outputPath, new PngOptions());

                    // Save to MemoryStream for transmission
                    using (MemoryStream ms = new MemoryStream())
                    {
                        image.Save(ms, new PngOptions());
                        Console.WriteLine($"PNG saved to MemoryStream, length = {ms.Length} bytes");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to convert high‑resolution TIFF scans to lightweight PNGs for sending over a web API without writing temporary files.
 * 2. When an application must generate PNG thumbnails from TIFF documents and stream them directly to a client browser.
 * 3. When a microservice processes uploaded TIFF images and returns the PNG data in a response payload using a MemoryStream.
 * 4. When you want to store converted PNG bytes in a database or message queue after converting from TIFF.
 * 5. When a background job converts TIFF files to PNG and passes the image data to another service via TCP/IP without touching the file system.
 */
