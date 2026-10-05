// HOW-TO: Compare EPS and PDF File Sizes After Conversion in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\sample.eps";
            string outputPath = "Output\\converted.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    epsImage.Save(outputPath, pdfOptions);
                }
            }

            long epsSize = new FileInfo(inputPath).Length;
            long pdfSize = new FileInfo(outputPath).Length;

            Console.WriteLine($"EPS size: {epsSize} bytes");
            Console.WriteLine($"PDF size: {pdfSize} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to evaluate storage savings by converting legacy EPS graphics to PDF in a .NET application.
 * 2. When you want to verify that a batch conversion process does not increase file size beyond acceptable limits.
 * 3. When you are migrating design assets to a PDF‑based workflow and must compare original EPS dimensions for compliance.
 * 4. When you need to log or display the size difference between EPS and PDF for reporting or auditing purposes.
 * 5. When you are building an automated tool that chooses the smaller format for archiving documents in C#.
 */
