// HOW-TO: Convert CorelDRAW CDR to PDF with Exact Page Size in C# (Aspose.Imaging for .NET)
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
            string inputPath = Path.Combine("Input", "sample.cdr");
            string outputPath = Path.Combine("Output", "sample.pdf");

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
                    pdfOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = cdr.Width,
                        PageHeight = cdr.Height
                    };
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
 * 1. When you need to programmatically convert a CorelDRAW CDR design into a PDF for printing or sharing while preserving the original dimensions.
 * 2. When an automated workflow must verify that a CDR file exists before processing and create the output folder if it doesn’t already exist.
 * 3. When you want to ensure the PDF background is white and matches the CDR canvas size to avoid scaling issues in downstream applications.
 * 4. When you need to handle conversion errors gracefully in a .NET application by logging missing files or exceptions.
 * 5. When integrating Aspose.Imaging into a batch job that converts multiple CDR files to PDFs without manual intervention.
 */
