using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "Sample.eps";
        string outputPath = "output/Sample.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load EPS image and convert to PDF
        using (var image = (EpsImage)Image.Load(inputPath))
        {
            var pdfOptions = new PdfOptions
            {
                PdfCoreOptions = new PdfCoreOptions
                {
                    PdfCompliance = PdfComplianceVersion.PdfA1b
                }
            };

            image.Save(outputPath, pdfOptions);
        }

        // Compare file sizes
        long epsSize = new FileInfo(inputPath).Length;
        long pdfSize = new FileInfo(outputPath).Length;

        Console.WriteLine($"EPS size: {epsSize} bytes");
        Console.WriteLine($"PDF size: {pdfSize} bytes");
        Console.WriteLine($"Size difference (PDF - EPS): {pdfSize - epsSize} bytes");
    }
}