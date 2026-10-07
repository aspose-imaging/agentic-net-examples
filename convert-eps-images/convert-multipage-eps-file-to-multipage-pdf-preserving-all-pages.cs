// HOW-TO: Convert Multipage EPS To Multipage PDF In C# With Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/multipage.eps";
            string outputPath = "Output/multipage.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions();
                epsImage.Save(outputPath, pdfOptions);
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
 * 1. When you need to batch‑convert a multi‑page EPS design file into a searchable PDF for archiving or printing using C#.
 * 2. When an application must preserve all pages of an EPS illustration while generating a PDF report for client delivery.
 * 3. When a workflow automates the transformation of vector EPS assets into PDF documents for e‑commerce product catalogs.
 * 4. When you integrate Aspose.Imaging into a .NET service that receives EPS uploads and returns PDF files without losing page order.
 * 5. When you want to programmatically create PDF portfolios from multi‑page EPS files for legal or compliance documentation.
 */
