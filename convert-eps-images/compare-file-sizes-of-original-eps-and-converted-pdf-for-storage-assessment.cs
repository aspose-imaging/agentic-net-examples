// HOW-TO: Compare EPS and PDF File Sizes After Conversion in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "Sample.eps";
            string outputPath = "Sample.pdf";

            // Verify that the input EPS file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (var image = (EpsImage)Image.Load(inputPath))
            {
                // Set up PDF export options (optional compliance settings)
                var pdfOptions = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        PdfCompliance = PdfComplianceVersion.PdfA1b
                    }
                };

                // Save the EPS image as PDF
                image.Save(outputPath, pdfOptions);
            }

            // Retrieve file sizes
            long epsSize = new FileInfo(inputPath).Length;
            long pdfSize = new FileInfo(outputPath).Length;

            // Output the comparison results
            Console.WriteLine($"EPS file size: {epsSize} bytes");
            Console.WriteLine($"PDF file size: {pdfSize} bytes");
            Console.WriteLine($"Size difference: {pdfSize - epsSize} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to evaluate the storage impact of converting EPS artwork to PDF for archiving.
 * 2. When you must verify that a PDF generated from an EPS meets size constraints for web delivery.
 * 3. When performing a batch migration of legacy EPS files to PDF and want to log size differences.
 * 4. When auditing compliance documents and need to ensure PDF/A‑1b output does not exceed the original EPS size.
 * 5. When building a storage‑budget calculator that compares source EPS size with resulting PDF size in a .NET application.
 */
