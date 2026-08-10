// HOW-TO: Convert CorelDRAW CDR Byte Array to PNG Memory Stream in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths (required by path‑safety rules)
            string inputPath = "input.cdr";
            string outputPath = "output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Example byte array containing a CDR file – replace with actual data
            byte[] cdrBytes = File.ReadAllBytes(inputPath);

            // Load CDR image from byte array
            using (MemoryStream inputStream = new MemoryStream(cdrBytes))
            using (CdrImage cdrImage = new CdrImage(inputStream, new LoadOptions()))
            {
                // Prepare PNG save options
                PngOptions pngOptions = new PngOptions();

                // Save to a memory stream
                using (MemoryStream outputStream = new MemoryStream())
                {
                    // Ensure output directory exists before any save (already done above)
                    cdrImage.Save(outputStream, pngOptions);

                    // Example usage of the resulting PNG bytes
                    byte[] pngBytes = outputStream.ToArray();
                    Console.WriteLine($"PNG byte array length: {pngBytes.Length}");

                    // Optionally write to the hardcoded output file path
                    File.WriteAllBytes(outputPath, pngBytes);
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
 * 1. When you receive a CorelDRAW drawing as a byte array from a web API and need to display it as a PNG in a .NET application.
 * 2. When you want to generate thumbnail previews of CDR files stored in a database without writing intermediate files to disk.
 * 3. When you need to convert user‑uploaded CDR images to PNG for further processing such as OCR or image analysis in a server‑side service.
 * 4. When you are building a document conversion pipeline that transforms legacy CDR assets into web‑friendly PNG format for browsers.
 * 5. When you must embed a CDR‑derived PNG into an email attachment or PDF by first obtaining the PNG bytes in memory.
 */
