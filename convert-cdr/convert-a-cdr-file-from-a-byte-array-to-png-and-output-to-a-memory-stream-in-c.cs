// HOW-TO: Convert CDR Byte Array to PNG Memory Stream in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input byte array containing CDR data
            byte[] cdrData = new byte[0]; // Replace with actual CDR byte array

            using (MemoryStream inputStream = new MemoryStream(cdrData))
            {
                using (CdrImage cdrImage = (CdrImage)Image.Load(inputStream))
                {
                    using (MemoryStream outputStream = new MemoryStream())
                    {
                        PngOptions pngOptions = new PngOptions();
                        pngOptions.Source = new StreamSource(outputStream);
                        cdrImage.Save(outputStream, pngOptions);

                        byte[] pngData = outputStream.ToArray();
                        Console.WriteLine($"PNG data length: {pngData.Length}");
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
 * 1. When you receive a CorelDRAW (CDR) file as a byte array from a web API and need to display it as a PNG image in a .NET web application without writing temporary files.
 * 2. When you want to generate thumbnail previews of uploaded CDR documents in an ASP.NET service by converting them directly to PNG streams for fast client delivery.
 * 3. When you are building a document conversion microservice that transforms CDR files stored in a database BLOB into PNG format for downstream image processing pipelines.
 * 4. When you need to embed CDR graphics into a PDF or email by first converting the CDR byte data to a PNG memory stream using Aspose.Imaging in C#.
 * 5. When you are performing batch conversion of multiple CDR files loaded from network storage into PNG images in memory to reduce I/O overhead in a high‑performance server application.
 */
