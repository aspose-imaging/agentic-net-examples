// HOW-TO: Batch Convert Multiple EPS Files to PDF/A-1b in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded collection of EPS files to convert
            string[] inputFiles = new string[]
            {
                @"C:\Images\Sample1.eps",
                @"C:\Images\Sample2.eps",
                @"C:\Images\Sample3.eps"
            };

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output PDF path (same folder, .pdf extension)
                string outputPath = Path.ChangeExtension(inputPath, ".pdf");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load EPS image and convert to PDF with required compliance
                using (EpsImage image = (EpsImage)Image.Load(inputPath))
                {
                    var pdfOptions = new PdfOptions
                    {
                        PdfCoreOptions = new PdfCoreOptions
                        {
                            PdfCompliance = PdfComplianceVersion.PdfA1b
                        }
                    };

                    image.Save(outputPath, pdfOptions);
                }

                Console.WriteLine($"Converted '{inputPath}' to '{outputPath}'.");
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
 * 1. When you need to automatically transform a set of vector EPS artwork into PDF/A‑1b documents for archival or printing workflows using C#.
 * 2. When a publishing system must generate PDF versions of EPS logos stored in a folder before sending them to a third‑party printer.
 * 3. When a desktop application processes incoming EPS design files and saves them as PDF to ensure compatibility with PDF viewers without manual conversion.
 * 4. When you want to verify each EPS file exists, create the output directory, and convert them to PDF in a single loop to simplify batch processing scripts.
 * 5. When compliance with PDF/A‑1b standards is required for legal or regulatory documents and you need a programmatic way to enforce it during conversion.
 */
