using System;
using System.IO;
using System.Net.Http;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input URL and output file path
        string inputUrl = "https://example.com/sample.cmx";
        string outputPath = @"C:\Temp\output.pdf";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Download the CMX image into a memory stream
            using (HttpClient httpClient = new HttpClient())
            using (Stream networkStream = httpClient.GetStreamAsync(inputUrl).Result)
            using (MemoryStream cmxStream = new MemoryStream())
            {
                networkStream.CopyTo(cmxStream);
                cmxStream.Position = 0; // Reset stream position for loading

                // Load the CMX image from the stream
                using (Image image = Image.Load(cmxStream))
                {
                    // Prepare PDF save options
                    PdfOptions pdfOptions = new PdfOptions();

                    // Save the image as PDF to the output file stream
                    using (FileStream outputFileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                    {
                        image.Save(outputFileStream, pdfOptions);
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
 * 1. When a web application must fetch a CorelDRAW CMX file from a remote URL using HttpClient, convert it to a PDF with Aspose.Imaging, and stream the PDF directly to the browser for preview.
 * 2. When an automated reporting service downloads CMX diagrams over HTTP, transforms them into PDF files via Image.Load and PdfOptions, and saves the PDFs to a local archive for compliance auditing.
 * 3. When a document management system needs to ingest CMX graphics received from a network stream, convert them to PDF, and write the PDF to a response stream for immediate client download.
 * 4. When a microservice processes incoming CMX image streams, converts them to PDF format for downstream OCR processing, and forwards the PDF through a FileStream to another service.
 * 5. When a desktop utility downloads CMX assets from an external server, converts them to PDF using Aspose.Imaging, and writes the PDF to a specified folder for offline viewing.
 */