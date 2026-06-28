using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input\\multipage.eps";
            string outputPath = "Output\\multipage.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PDF export options
                PdfOptions pdfOptions = new PdfOptions();

                // Save all pages of the EPS to a multipage PDF
                image.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to convert multi‑page EPS files created by a design or CAD tool into a multi‑page PDF for client delivery or archiving, this C# Aspose.Imaging code provides a straightforward solution.
 * 2. When an automated workflow must generate PDF portfolios from EPS artwork while preserving every page for print‑ready publishing, the code can be integrated into the pipeline.
 * 3. When a batch process has to transform dozens of EPS reports into searchable PDFs to meet compliance or record‑keeping requirements, the example demonstrates the necessary file‑format conversion.
 * 4. When a web service receives EPS uploads and must return PDF previews that retain all original pages, developers can use this code to perform the conversion on the server side.
 * 5. When a digital asset management system needs to ingest EPS assets and store them as multi‑page PDFs without losing any page content, the provided C# snippet handles the conversion efficiently.
 */