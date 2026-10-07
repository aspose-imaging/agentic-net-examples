// HOW-TO: Convert CorelDRAW CDR to PDF with Embedded Fonts in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.cdr";
            string outputPath = "Output\\sample.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    image.Save(outputPath, pdfOptions);
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
 * 1. When a design team needs to create print‑ready PDFs from CorelDRAW files while preserving the original fonts for accurate on‑screen and printed output.
 * 2. When an automated workflow must batch‑convert CDR assets to PDFs for archiving or distribution without losing any font information.
 * 3. When a web application allows users to upload CDR drawings and receive a downloadable PDF that includes all embedded fonts.
 * 4. When a reporting system integrates CorelDRAW graphics into PDF reports and requires embedded fonts to avoid missing‑font errors on client machines.
 * 5. When a cloud service processes graphic files and must ensure the resulting PDFs are self‑contained, with fonts embedded, to meet publishing compliance standards.
 */
