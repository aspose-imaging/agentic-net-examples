using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "Sample.eps";
        string outputPath = "Sample.pdf";

        // Verify that the input EPS file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EPS image as a vector image
        using (var image = (EpsImage)Image.Load(inputPath))
        {
            // Configure PDF options to preserve vector data
            var options = new PdfOptions
            {
                PdfCoreOptions = new PdfCoreOptions
                {
                    // Set desired PDF compliance (e.g., PDF/A-1b)
                    PdfCompliance = PdfComplianceVersion.PdfA1b
                }
            };

            // Save the EPS as a PDF using the configured options
            image.Save(outputPath, options);
        }
    }
}