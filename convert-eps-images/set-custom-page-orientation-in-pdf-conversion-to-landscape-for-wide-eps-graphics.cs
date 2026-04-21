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
        string inputPath = Path.Combine("Input", "sample.eps");
        string outputPath = Path.Combine("Output", "sample.pdf");

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load EPS image
        using (var image = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
        {
            // Prepare PDF options
            var pdfOptions = new PdfOptions();

            // Optional: set PDF compliance (default can be used)
            pdfOptions.PdfCoreOptions = new PdfCoreOptions
            {
                PdfCompliance = PdfComplianceVersion.PdfA1b
            };

            // Configure rasterization to landscape orientation
            var rasterOptions = new EpsRasterizationOptions
            {
                // Swap width and height for landscape
                PageWidth = image.Height,
                PageHeight = image.Width,
                BackgroundColor = Color.White
            };

            pdfOptions.VectorRasterizationOptions = rasterOptions;

            // Save as PDF
            image.Save(outputPath, pdfOptions);
        }
    }
}