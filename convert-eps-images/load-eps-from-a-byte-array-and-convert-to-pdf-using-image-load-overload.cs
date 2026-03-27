using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.eps";
        string outputPath = "Output/result.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load EPS file into a byte array
        byte[] epsBytes = File.ReadAllBytes(inputPath);

        // Load EPS image from the byte array using Image.Load overload
        using (var image = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(new MemoryStream(epsBytes)))
        {
            // Configure PDF save options with PDF/A-1b compliance
            var pdfOptions = new PdfOptions
            {
                PdfCoreOptions = new PdfCoreOptions
                {
                    PdfCompliance = PdfComplianceVersion.PdfA1b
                }
            };

            // Save the EPS image as PDF
            image.Save(outputPath, pdfOptions);
        }
    }
}