using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "Sample.eps";
        string outputPath = "Sample.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load EPS image
        using (var image = (EpsImage)Image.Load(inputPath))
        {
            // Configure PDF conversion options with balanced compression
            var pdfOptions = new PdfOptions
            {
                PdfCoreOptions = new PdfCoreOptions
                {
                    // Use Flate compression for good size reduction without quality loss
                    Compression = PdfImageCompressionOptions.Flate,
                    // Set JPEG quality for rasterized content (if any)
                    JpegQuality = 85
                }
            };

            // Save as PDF using the configured options
            image.Save(outputPath, pdfOptions);
        }
    }
}