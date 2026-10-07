// HOW-TO: Convert WMF to PDF with Vector Preservation in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace WmfToPdfConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.wmf";
                string outputPath = "output.pdf";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                using (Image image = Image.Load(inputPath))
                {
                    var pdfOptions = new PdfOptions();
                    image.Save(outputPath, pdfOptions);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to embed scalable WMF graphics into a PDF report generated from a .NET application.
 * 2. When an automated batch process must convert legacy Windows Metafile diagrams to PDF for archival without losing vector quality.
 * 3. When a web service creates printable PDFs from user‑uploaded WMF logos while keeping them resolution‑independent.
 * 4. When a desktop tool exports engineering schematics stored as WMF files into PDF documents for client distribution.
 * 5. When a document management system migrates WMF assets to PDF format to ensure consistent rendering across platforms.
 */
