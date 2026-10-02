// HOW-TO: Convert JPEG Image To Byte Array Using MemoryStream In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Image image = Image.Load(inputPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    JpegOptions options = new JpegOptions();
                    image.Save(ms, options);
                    byte[] imageBytes = ms.ToArray();
                    Console.WriteLine($"Byte array length: {imageBytes.Length}");
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
 * 1. When you need to store a processed JPEG directly in a database as a BLOB without creating a temporary file.
 * 2. When you want to send a JPEG image over a web API as a byte[] payload after applying Aspose.Imaging operations.
 * 3. When you generate an in‑memory thumbnail and pass the resulting byte array to another service for further manipulation.
 * 4. When you build a cloud function that processes uploaded images and returns raw bytes for storage in Azure Blob or similar.
 * 5. When you compare two images by loading them into memory and converting each to a byte array for hash or pixel‑by‑pixel analysis.
 */
