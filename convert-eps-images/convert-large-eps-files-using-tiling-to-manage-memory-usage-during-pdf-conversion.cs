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
        string inputPath = @"C:\Temp\LargeInput.eps";
        string outputPath = @"C:\Temp\Converted\LargeOutput.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load EPS with a buffer size hint to limit memory usage (tiling-like behavior)
        var loadOptions = new EpsLoadOptions
        {
            BufferSizeHint = 10 * 1024 * 1024 // 10 MB buffer hint
        };

        using (var epsImage = (EpsImage)Image.Load(inputPath, loadOptions))
        {
            // Configure PDF options
            var pdfOptions = new PdfOptions
            {
                PdfCoreOptions = new PdfCoreOptions
                {
                    PdfCompliance = PdfComplianceVersion.PdfA1b
                },
                // Optional: set rasterization options if you want to control page size
                VectorRasterizationOptions = new EpsRasterizationOptions
                {
                    PageWidth = epsImage.Width,   // preserve original width
                    PageHeight = epsImage.Height, // preserve original height
                    BackgroundColor = Color.White
                }
            };

            // Save the EPS as PDF
            epsImage.Save(outputPath, pdfOptions);
        }
    }
}