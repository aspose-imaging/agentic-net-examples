using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/result.pdf";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image from byte array
            byte[] epsData = File.ReadAllBytes(inputPath);
            using (var memoryStream = new MemoryStream(epsData))
            {
                using (var image = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(memoryStream))
                {
                    // Create PDF save options
                    var pdfOptions = new PdfOptions();

                    // Save as PDF
                    image.Save(outputPath, pdfOptions);
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
 * 1. When a web service receives an EPS logo as a byte array upload and must generate a PDF brochure on the fly.
 * 2. When a desktop application reads EPS files stored in a database BLOB field and needs to export them as printable PDF documents.
 * 3. When an automated batch job processes a folder of EPS artwork files loaded from memory to create PDF versions for archival compliance.
 * 4. When a cloud function converts user‑submitted EPS drawings received via API (as byte streams) into PDF for downstream workflow integration.
 * 5. When a document management system extracts EPS images from email attachments, loads them from a memory stream, and saves them as PDF for unified viewing.
 */