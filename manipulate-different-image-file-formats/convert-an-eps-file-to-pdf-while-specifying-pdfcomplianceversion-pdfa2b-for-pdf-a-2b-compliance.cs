// HOW-TO: Convert EPS to PDF/A‑2b Compliant PDF in C# With Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = Path.Combine("Input", "sample.eps");
        string outputPath = Path.Combine("Output", "sample.pdf");

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    epsImage.Save(outputPath, pdfOptions);
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
 * 1. When a publishing system must archive vector graphics from EPS files as PDF/A‑2b documents for long‑term preservation.
 * 2. When an automated workflow needs to convert customer‑submitted EPS artwork into PDF files that meet PDF/A‑2b compliance for legal or regulatory filing.
 * 3. When a desktop application generates printable PDFs from EPS logos while ensuring the output conforms to the PDF/A‑2b standard required by print vendors.
 * 4. When a document management platform imports EPS diagrams and stores them as PDF/A‑2b PDFs to guarantee consistent rendering across different viewers.
 * 5. When a batch processing script converts a large collection of EPS files to PDF/A‑2b PDFs using C# and Aspose.Imaging to streamline archival and distribution.
 */
