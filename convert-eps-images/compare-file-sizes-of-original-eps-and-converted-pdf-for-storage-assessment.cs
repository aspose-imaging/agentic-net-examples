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
        try
        {
            // Hardcoded input EPS file path
            string inputPath = @"C:\Images\sample.eps";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Hardcoded output PDF file path
            string outputPath = @"C:\Images\sample_converted.pdf";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image
            using (var image = (EpsImage)Image.Load(inputPath))
            {
                // Set PDF options (optional compliance setting)
                var pdfOptions = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        PdfCompliance = PdfComplianceVersion.PdfA1b
                    }
                };

                // Save as PDF
                image.Save(outputPath, pdfOptions);
            }

            // Get file sizes
            long epsSize = new FileInfo(inputPath).Length;
            long pdfSize = new FileInfo(outputPath).Length;

            // Output comparison
            Console.WriteLine($"EPS file size: {epsSize} bytes");
            Console.WriteLine($"Converted PDF file size: {pdfSize} bytes");
            Console.WriteLine($"Size difference: {pdfSize - epsSize} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}