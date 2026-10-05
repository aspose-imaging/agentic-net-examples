// HOW-TO: Convert CDR Stream To JPG Directly In C# Without Temp Files (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace CdrToJpgConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.cdr";
                string outputPath = "output.jpg";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                using (var inputStream = new MemoryStream(File.ReadAllBytes(inputPath)))
                {
                    using (Image image = Image.Load(inputStream))
                    {
                        var jpegOptions = new JpegOptions();
                        image.Save(outputPath, jpegOptions);
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
 * 1. When a web service receives a CorelDRAW (.cdr) file as a byte array and must return a JPEG preview without writing temporary files to disk.
 * 2. When processing batch uploads of CDR designs in a cloud function where storage I/O is limited, converting each stream to JPG on the fly.
 * 3. When generating thumbnails for a document management system that stores CDR files in a database BLOB and needs JPEG thumbnails for UI display.
 * 4. When integrating a C# desktop application with a third‑party API that supplies CDR data via a stream and expects a JPEG image as the response.
 * 5. When implementing an automated pipeline that reads CDR files from a network share, converts them in memory to JPEG, and streams the result to another service without creating intermediate files.
 */
