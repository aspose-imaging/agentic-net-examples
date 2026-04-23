using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = Path.Combine("Input", "sample.odg");
        string outputPath = Path.Combine("Output", "sample.pdf");

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load ODG image and convert to PDF with compression
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options for ODG
            var rasterOptions = new OdgRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageSize = image.Size
            };

            // Configure PDF save options with desired compression
            var pdfOptions = new PdfOptions
            {
                VectorRasterizationOptions = rasterOptions,
                PdfCoreOptions = new PdfCoreOptions
                {
                    Compression = PdfImageCompressionOptions.Flate
                }
            };

            // Save as PDF
            image.Save(outputPath, pdfOptions);
        }
    }
}