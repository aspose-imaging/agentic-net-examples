// HOW-TO: Batch Convert Multiple CDR Files to PDF Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded list of input CDR files
            string[] inputPaths = new string[]
            {
                @"C:\Input\file1.cdr",
                @"C:\Input\file2.cdr",
                @"C:\Input\file3.cdr"
            };

            foreach (string inputPath in inputPaths)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Derive output PDF path (same folder, same name with .pdf)
                string outputPath = Path.ChangeExtension(inputPath, ".pdf");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the CDR image
                using (CdrImage image = (CdrImage)Image.Load(inputPath))
                {
                    // Use the first page for conversion
                    var page = (CdrImagePage)image.Pages[0];

                    // Prepare PDF options with rasterization settings matching the page size
                    PdfOptions pdfOptions = new PdfOptions();
                    CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                    {
                        PageWidth = page.Width,
                        PageHeight = page.Height
                    };
                    pdfOptions.VectorRasterizationOptions = rasterOptions;

                    // Save the page as PDF
                    page.Save(outputPath, pdfOptions);
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
 * 1. When you need to automatically transform a collection of CorelDRAW (.cdr) drawings into searchable PDF documents for archiving or distribution.
 * 2. When a desktop application must process user‑uploaded CDR files in bulk and generate PDF versions without manual intervention.
 * 3. When a server‑side service has to convert multiple design files to PDF to integrate with a document‑management workflow.
 * 4. When you want to ensure each CDR page retains its original dimensions during conversion by using Aspose.Imaging’s rasterization options.
 * 5. When you are building a migration tool that reads CDR assets from a folder structure and outputs matching PDF files for cross‑platform compatibility.
 */
