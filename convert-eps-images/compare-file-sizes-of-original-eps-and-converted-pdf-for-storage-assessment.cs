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
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load EPS image
            using (EpsImage image = (EpsImage)Image.Load(inputPath))
            {
                // Prepare PDF save options (default compliance)
                var pdfOptions = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions()
                };

                // Save as PDF
                image.Save(outputPath, pdfOptions);
            }

            // Compare file sizes
            long epsSize = new FileInfo(inputPath).Length;
            long pdfSize = new FileInfo(outputPath).Length;

            Console.WriteLine($"EPS file size: {epsSize} bytes");
            Console.WriteLine($"PDF file size: {pdfSize} bytes");
            Console.WriteLine($"Size difference (PDF - EPS): {pdfSize - epsSize} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to evaluate storage savings by converting vector EPS artwork to PDF before archiving documents.
 * 2. When a C# application must verify that converting EPS logos to PDF does not exceed a cloud storage quota.
 * 3. When a system that ingests EPS files for printing wants to compare the resulting PDF size to ensure bandwidth‑friendly distribution.
 * 4. When a migration script uses Aspose.Imaging for .NET to batch‑process EPS assets and must log size differences for compliance reporting.
 * 5. When a developer is troubleshooting unexpected file‑size growth after EPS‑to‑PDF conversion and needs a quick size‑comparison utility.
 */