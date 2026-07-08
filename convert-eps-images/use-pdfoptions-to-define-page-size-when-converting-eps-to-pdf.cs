using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.eps";
        string outputPath = "Output/sample.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                var options = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        PdfCompliance = PdfComplianceVersion.PdfA1b
                    }
                };

                image.Save(outputPath, options);
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
 * 1. When a developer must transform an EPS logo into a PDF file with a custom page size for inclusion in a printable brochure, using Aspose.Imaging's PdfOptions in C#.
 * 2. When an automated report generator needs to embed EPS diagrams into PDF/A‑1b compliant documents with predefined page dimensions to meet regulatory archiving requirements.
 * 3. When a web service processes user‑uploaded EPS files and returns PDF versions sized to standard A4 or Letter pages for consistent viewing across browsers.
 * 4. When a batch conversion tool converts a folder of EPS illustrations to PDFs, applying specific page sizes to match the layout of a catalog without manual resizing.
 * 5. When a desktop application creates PDF portfolios from EPS artwork, using PdfOptions to set the page size so the final PDF matches the intended print layout.
 */