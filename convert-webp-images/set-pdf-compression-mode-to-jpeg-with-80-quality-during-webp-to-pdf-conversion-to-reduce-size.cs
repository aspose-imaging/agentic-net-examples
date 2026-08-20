// HOW-TO: Convert WebP to PDF With JPEG Compression At 80% Quality In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = "input.webp";
        string outputPath = "output.pdf";

        // Path safety checks
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
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
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate smaller PDF files from high‑resolution WebP images for faster web downloads.
 * 2. When an application must embed WebP graphics into PDFs while controlling file size by applying JPEG compression.
 * 3. When a batch process converts user‑uploaded WebP pictures to PDFs and must meet a maximum file‑size limit.
 * 4. When you want to preserve visual quality of WebP images in PDFs but reduce storage costs by using 80 % JPEG quality.
 * 5. When integrating Aspose.Imaging into a C# service that creates printable PDFs from WebP assets with predictable compression settings.
 */
