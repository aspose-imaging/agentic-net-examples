// HOW-TO: Convert BMP Images From Network Share To PDF And Stream In C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output directories
            string inputDirectory = @"\\share\images";
            string outputDirectory = @"C:\temp\pdfs";

            // Get all BMP files in the input directory
            string[] bmpFiles = Directory.GetFiles(inputDirectory, "*.bmp");

            foreach (string inputPath in bmpFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Determine output PDF path
                string outputPath = Path.Combine(outputDirectory,
                    Path.GetFileNameWithoutExtension(inputPath) + ".pdf");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load BMP image
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare PDF options
                    var pdfOptions = new PdfOptions();

                    // Save image as PDF to file
                    image.Save(outputPath, pdfOptions);

                    // Additionally, stream PDF to a memory stream (e.g., for sending to a client)
                    using (var memoryStream = new MemoryStream())
                    {
                        image.Save(memoryStream, pdfOptions);
                        // At this point, memoryStream contains the PDF bytes.
                        // Example: write the size of the streamed PDF.
                        Console.WriteLine($"Converted '{Path.GetFileName(inputPath)}' to PDF ({memoryStream.Length} bytes).");
                        // The memoryStream can be sent over a network stream to a client.
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
 * 1. When a web service needs to batch‑convert BMP files stored on a file server into PDFs for download by users.
 * 2. When an enterprise application must generate PDF reports from scanned BMP images located on a shared network folder.
 * 3. When a background job has to archive legacy BMP graphics as PDF documents while also sending the PDFs directly to a client over HTTP.
 * 4. When a document management system requires on‑the‑fly conversion of BMP assets to PDF for preview without writing temporary files.
 * 5. When a Windows service processes incoming BMP uploads from a shared drive, saves them as PDFs, and streams the PDF bytes to another system for further processing.
 */
