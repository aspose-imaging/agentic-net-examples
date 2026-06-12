using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageLoadOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths (not used for saving the PNG, but required by the safety rules)
            string inputPath = "sample.cdr";
            string outputPath = "output.png";

            // Input path validation
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the CDR file into a byte array
            byte[] cdrBytes = File.ReadAllBytes(inputPath);

            // Create a memory stream from the byte array
            using (MemoryStream inputStream = new MemoryStream(cdrBytes))
            {
                // Initialize CDR load options (default settings)
                var loadOptions = new CdrLoadOptions();

                // Load the CDR image from the stream
                using (CdrImage cdrImage = new CdrImage(inputStream, loadOptions))
                {
                    // Optional: cache all data to avoid lazy loading
                    cdrImage.CacheData();

                    // Prepare a memory stream for the PNG output
                    using (MemoryStream outputStream = new MemoryStream())
                    {
                        // Set PNG save options (default configuration)
                        var pngOptions = new PngOptions();

                        // Save the CDR image as PNG into the memory stream
                        cdrImage.Save(outputStream, pngOptions);

                        // At this point, outputStream contains the PNG data
                        Console.WriteLine($"PNG data size: {outputStream.Length} bytes");
                    }
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
 * 1. When building a web API that receives CorelDRAW (.cdr) files as uploaded byte arrays and must return PNG previews without writing temporary files to disk, a developer can use this Aspose.Imaging C# code to convert the stream directly to a PNG memory stream.
 * 2. When creating a background service that processes email attachments containing CDR documents stored in a database as BLOBs and needs to generate PNG thumbnails for a gallery view, this code enables in‑memory conversion using Aspose.Imaging for .NET.
 * 3. When developing a Windows desktop application that loads CDR assets from embedded resources (byte arrays) and displays them as PNG images in a UI control, the snippet provides the necessary C# workflow to load, cache, and save to a memory stream.
 * 4. When implementing a serverless function (e.g., Azure Functions) that receives CDR data via an HTTP request body and must return the PNG image as the response payload, the example shows how to perform the conversion entirely in memory with Aspose.Imaging.
 * 5. When integrating a document management system that stores vector graphics in CorelDRAW format and needs to export them as PNG for PDF generation or reporting, this code demonstrates the C# approach to read the byte array, convert with Aspose.Imaging, and keep the result in a memory stream for further processing.
 */