// HOW-TO: Convert CorelDRAW CDR to Flattened PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.cdr");
            string outputPath = Path.Combine("Output", "result.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    cdr.Save(outputPath, pdfOptions);
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
 * 1. When you need to generate a printable PDF from a CorelDRAW design in an automated C# workflow.
 * 2. When a web service must convert uploaded CDR files to PDF for preview without preserving layers.
 * 3. When a desktop application needs to batch‑process multiple CDR drawings and output them as PDF documents.
 * 4. When integrating Aspose.Imaging into a document management system to store vector graphics as PDF for archival.
 * 5. When creating a CI/CD pipeline that validates CDR assets by converting them to PDF for visual regression testing.
 */
