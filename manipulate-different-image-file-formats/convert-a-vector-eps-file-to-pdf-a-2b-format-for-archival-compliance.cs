// HOW-TO: Convert EPS to PDF/A-2b for Archival Compliance in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/sample.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var image = (EpsImage)Image.Load(inputPath))
            {
                var options = new PdfOptions();
                image.Save(outputPath, options);
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
 * 1. When a publishing system needs to archive legacy EPS artwork as PDF/A‑2b compliant files using C#.
 * 2. When a document management workflow must convert vector EPS logos to PDF/A‑2b for long‑term storage.
 * 3. When an automated build process generates PDF/A‑2b versions of EPS diagrams for regulatory record keeping.
 * 4. When a digital asset pipeline requires batch conversion of EPS illustrations to PDF/A‑2b to ensure PDF standards compliance.
 * 5. When a C# application must render EPS drawings as PDF/A‑2b PDFs for reliable printing and future retrieval.
 */
