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
            // Hardcoded input ODG file path
            string inputPath = @"C:\temp\sample.odg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Set up PNG save options
                var pngOptions = new PngOptions();

                // Save the image to a memory stream in PNG format
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    image.Save(memoryStream, pngOptions);

                    // Example usage of the resulting PNG data
                    byte[] pngData = memoryStream.ToArray();
                    Console.WriteLine($"PNG data size: {pngData.Length} bytes");
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
 * 1. When a web API receives user‑uploaded ODG drawings and must generate PNG thumbnails on the fly without creating intermediate files, this code loads the ODG, converts it to PNG, and returns the image as a MemoryStream.
 * 2. When assembling PDF reports that need to embed vector diagrams from ODG files, developers can use this code to convert the ODG to a PNG byte array suitable for PDF image insertion.
 * 3. When an email automation system has to attach ODG graphics as inline PNG images, the code converts the ODG to PNG in memory, allowing the PNG data to be embedded directly into the email body.
 * 4. When a cloud function processes design assets stored in ODG format and stores the resulting PNG bytes in a database or blob storage, this snippet performs the in‑memory conversion efficiently.
 * 5. When a desktop application provides a quick preview of ODG vector files in a picture box control, the code converts the ODG to a PNG MemoryStream that can be rendered instantly without writing to disk.
 */