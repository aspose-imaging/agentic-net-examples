using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\InputCdr";
            string outputDir = @"C:\OutputPdf";

            // List of CDR files to process
            string[] cdrFiles = new string[]
            {
                "file1.cdr",
                "file2.cdr",
                "file3.cdr"
            };

            foreach (var fileName in cdrFiles)
            {
                string inputPath = Path.Combine(inputDir, fileName);

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Base output PDF path (one PDF per page if multi‑page)
                string baseOutputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(fileName) + ".pdf");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(baseOutputPath));

                // Load the CDR image
                using (CdrImage image = (CdrImage)Image.Load(inputPath))
                {
                    // Iterate through all pages
                    for (int i = 0; i < image.Pages.Length; i++)
                    {
                        var page = (CdrImagePage)image.Pages[i];

                        // Configure PDF options with rasterization settings matching the page size
                        PdfOptions pdfOptions = new PdfOptions();
                        CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions()
                        {
                            TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                            SmoothingMode = SmoothingMode.None,
                            PageWidth = page.Width,
                            PageHeight = page.Height
                        };
                        pdfOptions.VectorRasterizationOptions = rasterOptions;

                        // Determine output path for the current page
                        string pageOutputPath = baseOutputPath;
                        if (image.Pages.Length > 1)
                        {
                            string dir = Path.GetDirectoryName(baseOutputPath);
                            string nameWithoutExt = Path.GetFileNameWithoutExtension(baseOutputPath);
                            pageOutputPath = Path.Combine(dir, $"{nameWithoutExt}_page{i}.pdf");
                            Directory.CreateDirectory(Path.GetDirectoryName(pageOutputPath));
                        }

                        // Save the page as PDF
                        page.Save(pageOutputPath, pdfOptions);
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
 * 1. When a design studio needs to batch‑convert a collection of CorelDRAW (.cdr) artwork files into searchable PDF portfolios for client review.
 * 2. When an automated build pipeline must generate PDF documentation from multiple CDR source files to include in a software release package.
 * 3. When a legal department requires converting multi‑page CDR drawings into separate PDF pages for archiving and e‑discovery compliance.
 * 4. When a cloud‑based conversion service processes user‑uploaded CDR files in a loop and outputs PDFs to a shared output folder for downstream processing.
 * 5. When a desktop utility needs to scan a directory of CDR graphics, verify each file’s existence, and produce PDF versions with default rasterization settings for printing.
 */