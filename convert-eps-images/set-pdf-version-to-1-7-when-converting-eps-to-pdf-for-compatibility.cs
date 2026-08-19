// HOW-TO: Convert EPS to PDF with PDF Version 1.7 in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Sample.eps";
            string outputPath = "Sample.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image and convert to PDF (default PDF version is 1.7)
            using (var image = (EpsImage)Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions(); // No explicit compliance set; defaults to PDF 1.7

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
 * 1. When a publishing workflow requires converting EPS illustrations to PDF files that conform to PDF 1.7 for maximum viewer compatibility.
 * 2. When automating batch processing of design assets, you can programmatically transform EPS logos into PDF documents using Aspose.Imaging in C#.
 * 3. When integrating legacy vector graphics into a .NET application that generates PDF reports, this code ensures the EPS content is rendered correctly as PDF 1.7.
 * 4. When a client mandates that all delivered PDFs meet PDF 1.7 compliance, you can use this snippet to convert EPS source files accordingly.
 * 5. When building a server‑side service that receives EPS uploads and returns PDF versions, the example shows how to perform the conversion safely with error handling in C#.
 */
