using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded list of CDR files to convert
            string[] inputFiles = new string[]
            {
                @"C:\Input\sample1.cdr",
                @"C:\Input\sample2.cdr",
                @"C:\Input\sample3.cdr"
            };

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output PDF path (same folder, same name with .pdf extension)
                string outputPath = Path.ChangeExtension(inputPath, ".pdf");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the CDR image
                using (CdrImage image = (CdrImage)Image.Load(inputPath))
                {
                    // Use the first page of the CDR document
                    CdrImagePage page = (CdrImagePage)image.Pages[0];

                    // Set up PDF options with default rasterization settings
                    PdfOptions pdfOptions = new PdfOptions();
                    CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions();
                    pdfOptions.VectorRasterizationOptions = rasterOptions;

                    // Match PDF page size to the source page size
                    pdfOptions.VectorRasterizationOptions.PageWidth = page.Width;
                    pdfOptions.VectorRasterizationOptions.PageHeight = page.Height;

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
 * 1. When a design studio needs to batch‑convert multiple CorelDRAW (.cdr) artwork files to PDF for client review, they can use this C# loop with Aspose.Imaging to generate PDFs with the original page dimensions.
 * 2. When an automated build pipeline must create printable PDFs from a set of CDR assets before publishing them to a documentation portal, the code loads each CDR, rasterizes the first page, and saves a PDF using default settings.
 * 3. When a Windows service processes incoming CDR files from a shared folder and needs to archive them as PDF for long‑term storage, the example shows how to verify file existence, create output directories, and perform the conversion in .NET.
 * 4. When a migration script moves legacy CorelDRAW graphics to a PDF‑based workflow, developers can loop through an array of CDR paths, apply Aspose.Imaging rasterization options, and output PDFs that preserve the original page size.
 * 5. When a QA automation test validates that exported PDFs match the dimensions of source CDR pages, the snippet demonstrates loading each CDR, extracting the first page, and saving it as a PDF with matching width and height using C# and Aspose.Imaging.
 */