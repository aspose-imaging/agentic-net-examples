// HOW-TO: Convert CMX Image From Stream To PDF And Write To Response In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Placeholder for network stream containing CMX data
            using (MemoryStream networkStream = new MemoryStream())
            {
                // Load CMX image from the stream
                using (Image image = Image.Load(networkStream))
                {
                    // Prepare PDF options
                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        // Write PDF to response stream (here using standard output as example)
                        Stream responseStream = Console.OpenStandardOutput();
                        image.Save(responseStream, pdfOptions);
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
 * 1. When a web service receives a CMX drawing over HTTP and must return it as a PDF document to the client.
 * 2. When an API needs to transform legacy CorelDRAW CMX files stored in a cloud storage stream into PDF for downstream processing.
 * 3. When generating on‑the‑fly PDF reports from CMX graphics streamed from a remote server without saving intermediate files.
 * 4. When integrating Aspose.Imaging into an ASP.NET controller to convert uploaded CMX data directly to PDF and send it back in the HTTP response.
 * 5. When building a microservice that consumes CMX image bytes from a message queue, converts them to PDF, and streams the result to another service.
 */
