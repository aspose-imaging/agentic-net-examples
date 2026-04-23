using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.webp";
        string outputPath = "output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WebP image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PDF conversion options with JPEG compression at 80% quality
            var pdfOptions = new PdfOptions
            {
                PdfCoreOptions = new PdfCoreOptions
                {
                    Compression = PdfImageCompressionOptions.Jpeg,
                    JpegQuality = 80
                }
            };

            // Save the image as PDF using the configured options
            image.Save(outputPath, pdfOptions);
        }
    }
}