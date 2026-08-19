// HOW-TO: Convert ODG to PNG and Store in MemoryStream Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hardcoded input path
        string inputPath = @"C:\Images\sample.odg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PNG save options
                var pngOptions = new PngOptions();

                // Save the image to a memory stream in PNG format
                using (var memoryStream = new MemoryStream())
                {
                    image.Save(memoryStream, pngOptions);

                    // At this point, memoryStream contains the PNG data.
                    // Example: display the size of the generated PNG.
                    Console.WriteLine($"PNG data length: {memoryStream.Length} bytes");
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
 * 1. When you need to display or transmit an OpenDocument graphic in a web API without writing a temporary file.
 * 2. When generating thumbnails of ODG drawings on the fly for a cloud‑based document viewer.
 * 3. When converting user‑uploaded ODG files to PNG for storage in a database BLOB column.
 * 4. When processing batch ODG images in a background service and sending the PNG bytes over a message queue.
 * 5. When creating PDF reports that embed ODG illustrations by first converting them to PNG in memory.
 */
