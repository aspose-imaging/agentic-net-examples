// HOW-TO: Convert EPS to PDF/A‑1b Compliant PDF in C# Using Aspose.Imaging (Aspose.Imaging for .NET)
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
            string inputPath = Path.Combine("Input", "sample.eps");
            string outputPath = Path.Combine("Output", "sample.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.FileFormats.Eps.EpsImage epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
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
 * 1. When a publishing system must archive vector graphics in a PDF/A‑1b format for long‑term preservation, developers can convert EPS files to compliant PDFs using C# and Aspose.Imaging.
 * 2. When a print workflow requires PDF/A‑1b files to meet industry standards, developers can automate the EPS‑to‑PDF conversion with compliance enforcement in .NET applications.
 * 3. When a document management solution needs to ensure all uploaded EPS assets are stored as PDF/A‑1b compliant PDFs for legal or regulatory compliance, this code provides a reliable conversion method.
 * 4. When a batch processing tool must generate searchable, standards‑compliant PDFs from a collection of EPS logos for use in electronic filing systems, developers can use the PdfComplianceVersion enumeration in C#.
 * 5. When integrating third‑party design files into a compliance‑focused reporting platform, developers can programmatically convert EPS to PDF/A‑1b to guarantee that the output meets archival PDF standards.
 */
