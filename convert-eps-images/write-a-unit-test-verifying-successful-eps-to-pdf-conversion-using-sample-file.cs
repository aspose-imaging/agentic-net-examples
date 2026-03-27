using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.eps";
        string outputPath = "Output/sample.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load EPS image and convert to PDF
        using (EpsImage image = (EpsImage)Image.Load(inputPath))
        {
            var options = new PdfOptions
            {
                PdfCoreOptions = new PdfCoreOptions
                {
                    PdfCompliance = PdfComplianceVersion.PdfA1b
                }
            };
            image.Save(outputPath, options);
        }

        // Verify conversion succeeded
        if (File.Exists(outputPath))
        {
            Console.WriteLine("EPS to PDF conversion succeeded.");
        }
        else
        {
            Console.Error.WriteLine("EPS to PDF conversion failed.");
        }
    }
}