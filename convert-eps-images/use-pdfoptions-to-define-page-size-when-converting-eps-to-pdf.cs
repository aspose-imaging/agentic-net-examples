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
        // Hardcoded input and output file paths
        string inputPath = "input.eps";
        string outputPath = "output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EPS image
        using (var image = (EpsImage)Image.Load(inputPath))
        {
            // Configure PDF options with page size and compliance
            using (var options = new PdfOptions
            {
                // Set page size (e.g., A4 in points)
                PageSize = new SizeF(595, 842),
                PdfCoreOptions = new PdfCoreOptions
                {
                    PdfCompliance = PdfComplianceVersion.PdfA1b
                }
            })
            {
                // Save EPS as PDF using the defined options
                image.Save(outputPath, options);
            }
        }
    }
}