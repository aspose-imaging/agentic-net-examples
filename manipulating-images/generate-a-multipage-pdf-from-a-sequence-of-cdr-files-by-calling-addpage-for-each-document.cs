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
            // Hardcoded input CDR files
            string[] inputPaths = new string[]
            {
                @"C:\temp\file1.cdr",
                @"C:\temp\file2.cdr",
                @"C:\temp\file3.cdr"
            };

            // Hardcoded output PDF file
            string outputPath = @"C:\temp\output.pdf";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Loop through each CDR file and add its first page to the PDF
            foreach (string inputPath in inputPaths)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the CDR image
                using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
                {
                    // Ensure at least one page exists
                    if (cdrImage.Pages == null || cdrImage.Pages.Length == 0)
                    {
                        Console.Error.WriteLine($"No pages found in: {inputPath}");
                        continue;
                    }

                    // Use the first page of the CDR file
                    CdrImagePage page = (CdrImagePage)cdrImage.Pages[0];

                    // Configure PDF export options
                    PdfOptions pdfOptions = new PdfOptions
                    {
                        VectorRasterizationOptions = new CdrRasterizationOptions
                        {
                            TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                            SmoothingMode = SmoothingMode.None,
                            PageWidth = page.Width,
                            PageHeight = page.Height
                        }
                    };

                    // Save (or append) the page to the output PDF
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
 * 1. When a developer needs to combine several CorelDRAW (CDR) drawings into a single PDF brochure for client review.
 * 2. When an automated batch process must generate a multipage PDF report from a collection of CDR files for archival purposes.
 * 3. When a web service converts uploaded CDR files into one consolidated PDF document so users can preview the designs in a browser.
 * 4. When a desktop application creates a printable PDF portfolio by adding the first page of each CDR file to a single output file.
 * 5. When a document management system merges separate CDR assets into a searchable PDF for indexing and easy retrieval.
 */