// HOW-TO: Rotate PNG 180 Degrees and Save as Portrait PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\image.png";
        string outputPath = "Output\\rotated.pdf";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                image.RotateFlip(RotateFlipType.Rotate180FlipNone);
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
 * 1. When you need to generate a printable PDF from a scanned PNG that must be upside-down for correct orientation.
 * 2. When an e‑commerce platform requires product images rotated 180° before embedding them in PDF catalogs.
 * 3. When a document automation system converts user‑uploaded PNG signatures into portrait PDFs after correcting their rotation.
 * 4. When a reporting tool creates PDF reports that include PNG charts that need to be flipped vertically.
 * 5. When a mobile app syncs rotated PNG screenshots and stores them as PDF files for archival purposes.
 */
