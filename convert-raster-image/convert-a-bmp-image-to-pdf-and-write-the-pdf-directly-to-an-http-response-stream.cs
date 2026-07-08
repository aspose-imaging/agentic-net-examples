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
            // Hardcoded input BMP file path (relative to the executable directory)
            string inputPath = "Input/sample.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PDF save options
                PdfOptions pdfOptions = new PdfOptions();

                // The HTTP response stream would be provided by the web framework.
                // Here we simulate it with a MemoryStream for demonstration.
                using (MemoryStream responseStream = new MemoryStream())
                {
                    // Save the image as PDF directly to the response stream
                    image.Save(responseStream, pdfOptions);

                    // Example: write the size of the generated PDF to console
                    Console.WriteLine($"PDF generated, size: {responseStream.Length} bytes");
                    
                    // In a real HTTP scenario, the responseStream would be the HttpResponse.Body stream.
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
 * 1. When a web application needs to let users download a scanned BMP document as a PDF without storing a temporary file on the server.
 * 2. When an ASP.NET Core API must return dynamically generated PDF reports from legacy BMP images directly in the HTTP response to reduce I/O overhead.
 * 3. When an e‑commerce platform converts product photos saved as BMP into PDF brochures on the fly for email attachments sent via an HTTP response.
 * 4. When a document management system streams BMP‑based engineering drawings as PDF to a browser for immediate preview, using Aspose.Imaging to handle the conversion in memory.
 * 5. When a cloud service provides a REST endpoint that receives a BMP file path, converts it to PDF, and streams the result back to the client to avoid disk usage and improve performance.
 */