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
            string[] inputFiles = new[]
            {
                @"C:\Input\Design1.cdr",
                @"C:\Input\Design2.cdr",
                @"C:\Input\Design3.cdr"
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

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the CDR image
                using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
                {
                    // Prepare PDF export options
                    PdfOptions pdfOptions = new PdfOptions
                    {
                        VectorRasterizationOptions = new CdrRasterizationOptions
                        {
                            TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                            SmoothingMode = Aspose.Imaging.SmoothingMode.None
                        }
                    };

                    // Export all pages (PDF supports multipage)
                    if (cdrImage is IMultipageImage multipage && multipage.PageCount > 0)
                    {
                        pdfOptions.MultiPageOptions = null; // export all pages
                    }

                    // Save as PDF
                    cdrImage.Save(outputPath, pdfOptions);
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
 * 1. When a graphic design studio needs to convert a collection of CorelDRAW (CDR) files into searchable PDF portfolios while preserving vector text and shapes, they can use this code to batch export each file to an individual PDF.
 * 2. When an automated build pipeline must generate PDF documentation from multiple CDR source assets without rasterizing the artwork, this snippet provides a C# solution that retains vector fidelity.
 * 3. When a marketing department wants to archive campaign graphics by converting several CDR files into PDF format for easy viewing on any device, the code enables batch processing with Aspose.Imaging’s vector rasterization options.
 * 4. When a content management system imports CDR designs and needs to create PDF previews that keep text as editable vectors, developers can employ this example to loop through files and save each as a PDF.
 * 5. When a QA team validates that all pages of multi‑page CDR drawings are correctly rendered in PDF, this program iterates through the files, checks page counts, and exports each document while preserving vector shapes.
 */