using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageLoadOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\sample.cdr";
        string outputPath = @"C:\Temp\output.png";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Read the CDR file into a byte array
            byte[] cdrBytes = File.ReadAllBytes(inputPath);

            // Load the CDR image from the byte array using a MemoryStream
            using (var inputStream = new MemoryStream(cdrBytes))
            using (var cdrImage = new CdrImage(inputStream, new CdrLoadOptions()))
            {
                // Optional: cache the image data for faster processing
                cdrImage.CacheData();

                // Prepare PNG save options
                var pngOptions = new PngOptions();

                // Save the image to a MemoryStream in PNG format
                using (var outputStream = new MemoryStream())
                {
                    cdrImage.Save(outputStream, pngOptions);

                    // The MemoryStream now contains the PNG data.
                    // For demonstration, write the PNG bytes to a file.
                    File.WriteAllBytes(outputPath, outputStream.ToArray());
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
 * 1. When a developer needs to convert a CorelDRAW CDR file stored as a byte array in a database into a PNG image for instant web preview without creating temporary files.
 * 2. When an ASP.NET MVC application receives uploaded CDR files and must generate PNG thumbnails by loading the file bytes into a MemoryStream and saving the result to another stream.
 * 3. When a REST API endpoint accepts CDR image data, and the service must transform the byte‑array payload into a PNG stream for downstream image processing or OCR tasks.
 * 4. When a batch migration script reads legacy CDR assets as byte arrays to avoid file‑system locks and converts each to PNG using Aspose.Imaging for archival storage.
 * 5. When a reporting tool needs to embed CorelDRAW graphics into a PDF by first converting the CDR byte array to a PNG in memory and then inserting the PNG stream into the document.
 */