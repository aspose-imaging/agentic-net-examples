// HOW-TO: Convert CMX Image to PDF with A4 Page Size in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.cmx";
            string outputPath = "Output/sample.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CmxImage image = (CmxImage)Aspose.Imaging.Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new CmxRasterizationOptions
                    {
                        PageSize = new Aspose.Imaging.SizeF(595, 842) // A4 size in points
                    }
                };

                image.Save(outputPath, pdfOptions);
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
 * 1. When you need to embed legacy CorelDRAW CMX drawings into a PDF report that must fit standard A4 paper dimensions.
 * 2. When an automated document pipeline converts batch CMX files to searchable PDFs for archiving while preserving vector quality.
 * 3. When a web service receives CMX uploads and returns PDF previews sized for printing on A4 sheets.
 * 4. When integrating Aspose.Imaging into a C# application to transform vector‑based CMX artwork into PDF for cross‑platform distribution.
 * 5. When generating printable PDFs from CMX assets in a Windows desktop tool, ensuring the output matches A4 layout requirements.
 */
