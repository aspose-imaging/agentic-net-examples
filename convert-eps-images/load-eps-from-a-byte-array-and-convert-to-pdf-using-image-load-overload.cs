// HOW-TO: Convert EPS File to PDF Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
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
 * 1. When you need to programmatically turn vector EPS artwork into a PDF for easy sharing or printing in a .NET application.
 * 2. When a web service receives EPS uploads and must generate PDF previews for users without installing external tools.
 * 3. When automating a document workflow that archives legacy EPS graphics as PDF files for long‑term storage.
 * 4. When integrating with a reporting system that only accepts PDF input, requiring conversion of EPS logos or diagrams on the fly.
 * 5. When building a batch conversion utility that reads EPS files from disk and outputs PDFs using Aspose.Imaging in C#.
 */
