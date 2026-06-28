using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.eps";
        string outputPath = "Output/sample.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (EpsImage image = (EpsImage)Aspose.Imaging.Image.Load(inputPath))
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
 * 1. When a developer needs to convert legacy EPS artwork into PDF files that must be compatible with Adobe Acrobat 9 or later, they can use this code to generate PDF 1.7 output.
 * 2. When an automated document pipeline processes print‑ready EPS files and must produce PDFs that meet ISO 32000‑1 (PDF 1.7) standards for archival, the snippet provides the required conversion.
 * 3. When a web service receives EPS logos from clients and must return PDF versions that can be opened in modern browsers and PDF viewers supporting PDF 1.7, this code handles the transformation.
 * 4. When a batch job migrates a large collection of EPS design assets to PDF while ensuring the resulting files include features like transparency and embedded fonts supported in PDF 1.7, the example is applicable.
 * 5. When integrating Aspose.Imaging into a C# desktop application that lets users export EPS drawings to PDF with the latest PDF version for seamless printing on PDF‑compatible printers, this code is used.
 */