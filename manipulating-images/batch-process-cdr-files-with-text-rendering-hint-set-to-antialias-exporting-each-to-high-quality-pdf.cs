// HOW-TO: Batch Convert CDR Files to High Quality PDF with AntiAlias Text in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add CDR files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.cdr");
            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions();
                    rasterOptions.TextRenderingHint = TextRenderingHint.AntiAlias;
                    pdfOptions.VectorRasterizationOptions = rasterOptions;

                    image.Save(outputPath, pdfOptions);
                }

                Console.WriteLine($"Converted '{inputPath}' to PDF successfully.");
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
 * 1. When you need to automatically convert a folder of CorelDRAW (CDR) drawings into PDF documents for archiving or sharing, preserving crisp text with anti‑alias rendering.
 * 2. When a publishing workflow requires batch exporting of design files to PDF while ensuring text appears smooth on high‑resolution prints.
 * 3. When you want to generate PDF reports from multiple CDR assets in a .NET application without manually opening each file.
 * 4. When integrating a document conversion service that must maintain text quality by applying the AntiAlias rendering hint during rasterization.
 * 5. When automating the preparation of CDR‑based marketing materials for client review, converting them to PDF in one step.
 */
