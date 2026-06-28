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
            string inputPath = "Input/sample.jpg";
            string outputPath = "Output/output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            using (Image image = Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions();
                image.Save(outputPath, pdfOptions);
            }

            // Validate the generated PDF by loading it
            using (Image pdf = Image.Load(outputPath))
            {
                // If loading succeeds, the PDF is considered valid.
                Console.WriteLine("PDF validation succeeded.");
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
 * 1. When a developer needs to convert a JPEG image to a PDF for archival or sharing and must ensure the resulting PDF opens correctly in standard PDF viewers.
 * 2. When building an automated C# document generation pipeline that transforms product photos into printable PDFs and validates the output to prevent corrupted files.
 * 3. When integrating Aspose.Imaging into a web service that receives user‑uploaded images, converts them to PDF, and verifies the PDF can be rendered before returning it to the client.
 * 4. When creating a batch‑processing tool that reads images from a folder, saves each as a PDF, and checks each PDF for load errors to guarantee reliable batch conversion.
 * 5. When developing a desktop application that allows users to export scanned images as PDFs and needs to confirm the exported PDF is readable without throwing exceptions.
 */