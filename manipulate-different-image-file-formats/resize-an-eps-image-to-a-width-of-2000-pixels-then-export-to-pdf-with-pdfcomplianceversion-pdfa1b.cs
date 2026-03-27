using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.eps";
        string outputPath = "output/output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load EPS image, resize, and save as PDF/A-1b
        using (var image = (EpsImage)Image.Load(inputPath))
        {
            // Calculate height to preserve aspect ratio for width = 2000
            int newWidth = 2000;
            int newHeight = (int)(image.Height * (double)newWidth / image.Width);

            // Resize image
            image.Resize(newWidth, newHeight);

            // Prepare PDF options with required compliance
            var pdfOptions = new PdfOptions
            {
                PdfCoreOptions = new PdfCoreOptions
                {
                    PdfCompliance = PdfComplianceVersion.PdfA1b
                }
            };

            // Save the resized image as PDF
            image.Save(outputPath, pdfOptions);
        }
    }
}