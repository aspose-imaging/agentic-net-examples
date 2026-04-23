using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = "input.eps";
        string outputPath = "output.pdf";

        // Verify that the input EPS file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EPS image
        using (var epsImage = (EpsImage)Image.Load(inputPath))
        {
            // Configure PDF options – using PDF/A‑1b compliance to keep text searchable
            var pdfOptions = new PdfOptions
            {
                PdfCoreOptions = new PdfCoreOptions
                {
                    PdfCompliance = PdfComplianceVersion.PdfA1b
                }
            };

            // Save the EPS as a searchable PDF, preserving text objects
            epsImage.Save(outputPath, pdfOptions);
        }
    }
}