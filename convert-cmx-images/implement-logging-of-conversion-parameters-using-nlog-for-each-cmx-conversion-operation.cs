// HOW-TO: Log CMX Conversion Parameters Using NLog in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.cmx";
            string outputPathPng = "Output\\sample.png";
            string outputPathJpg = "Output\\sample.jpg";
            string outputPathPdf = "Output\\sample.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPathPng));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathJpg));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathPdf));

            Console.WriteLine($"Starting conversion for: {inputPath}");

            using (Image image = Image.Load(inputPath))
            {
                // Convert to PNG
                var pngOptions = new PngOptions();
                image.Save(outputPathPng, pngOptions);
                Console.WriteLine($"Converted to PNG: {outputPathPng}");

                // Convert to JPEG
                var jpegOptions = new JpegOptions();
                image.Save(outputPathJpg, jpegOptions);
                Console.WriteLine($"Converted to JPEG: {outputPathJpg}");

                // Convert to PDF
                var pdfOptions = new PdfOptions();
                pdfOptions.PdfDocumentInfo = new PdfDocumentInfo();
                image.Save(outputPathPdf, pdfOptions);
                Console.WriteLine($"Converted to PDF: {outputPathPdf}");
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to batch‑convert legacy CMX drawings to PNG, JPEG, and PDF while keeping a record of each conversion’s settings.
 * 2. When you want to integrate Aspose.Imaging CMX conversion into a .NET service and track conversion details in NLog for troubleshooting.
 * 3. When you must ensure output folders exist and log the source file path and chosen image options before saving.
 * 4. When you are building an automated workflow that validates CMX files, converts them to multiple formats, and records any errors in a central log.
 * 5. When you need to generate audit‑ready logs of image format conversions for compliance or quality‑control reports.
 */
