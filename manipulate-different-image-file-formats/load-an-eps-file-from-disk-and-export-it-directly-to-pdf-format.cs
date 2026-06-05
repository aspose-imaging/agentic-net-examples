using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "Sample.eps";
        string outputPath = "Sample.pdf";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image and convert to PDF
            using (var image = (EpsImage)Image.Load(inputPath))
            {
                var options = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        PdfCompliance = PdfComplianceVersion.PdfA1b // Set required PDF compliance
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
 * 1. When a print shop needs to convert client‑provided EPS artwork into PDF/A‑1b files for archival or pre‑press workflows.
 * 2. When a web application must generate a downloadable PDF version of a vector logo stored as an EPS file without using external tools.
 * 3. When an automated document pipeline has to batch‑process EPS diagrams from a CAD system and save them as PDFs for inclusion in reports.
 * 4. When a desktop utility needs to verify that an EPS file exists, create the target folder, and export the image to a PDF for easy viewing on any device.
 * 5. When a compliance‑driven system requires converting EPS graphics to PDF with specific PDF compliance settings (e.g., PdfA1b) using C# and Aspose.Imaging.
 */