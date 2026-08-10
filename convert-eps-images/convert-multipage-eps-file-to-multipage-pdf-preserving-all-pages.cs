// HOW-TO: Convert Multipage EPS to PDF with All Pages Preserved in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.eps";
            string outputPath = "output/output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions();

                var vectorOptions = new VectorRasterizationOptions
                {
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };

                pdfOptions.VectorRasterizationOptions = vectorOptions;

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
 * 1. When you need to generate a searchable PDF from a multi‑page EPS artwork for printing or archiving.
 * 2. When an automated workflow must batch‑convert EPS design files into PDF documents while keeping each page intact.
 * 3. When a web service receives EPS files from users and must return a PDF version without losing vector quality.
 * 4. When integrating Aspose.Imaging into a C# application to transform multi‑page EPS reports into PDF for easy distribution.
 * 5. When migrating legacy EPS assets to PDF format for compliance or document management systems using .NET.
 */
