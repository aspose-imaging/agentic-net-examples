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
        string inputPath = @"C:\Input\LargeFile.eps";
        string outputPath = @"C:\Output\LargeFile.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EPS image with a buffer size hint to limit memory usage (acts like tiling)
        var loadOptions = new EpsLoadOptions
        {
            BufferSizeHint = 10 * 1024 * 1024 // 10 MB buffer hint
        };

        using (var epsImage = (EpsImage)Image.Load(inputPath, loadOptions))
        {
            // Configure rasterization options; setting a modest page size helps keep memory low
            var rasterOptions = new EpsRasterizationOptions
            {
                PageWidth = 1024,   // tile width in pixels
                PageHeight = 1024,  // tile height in pixels
                BackgroundColor = Color.White
            };

            // Set up PDF options with the rasterization settings
            var pdfOptions = new PdfOptions
            {
                VectorRasterizationOptions = rasterOptions,
                PdfCoreOptions = new PdfCoreOptions
                {
                    PdfCompliance = PdfComplianceVersion.PdfA1b
                }
            };

            // Save the EPS as PDF using the configured options
            epsImage.Save(outputPath, pdfOptions);
        }
    }
}