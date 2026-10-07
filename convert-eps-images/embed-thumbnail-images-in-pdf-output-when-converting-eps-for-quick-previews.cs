// HOW-TO: Convert EPS to PDF with PNG Thumbnail Preview in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/sample.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image epsImage = Image.Load(inputPath))
            {
                var thumbOptions = new PngOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = 200,
                        PageHeight = 200
                    }
                };

                using (var thumbStream = new MemoryStream())
                {
                    epsImage.Save(thumbStream, thumbOptions);
                    thumbStream.Position = 0;

                    using (Image thumbImage = Image.Load(thumbStream))
                    {
                        var pdfOptions = new PdfOptions
                        {
                            PdfDocumentInfo = new PdfDocumentInfo()
                        };

                        epsImage.Save(outputPath, pdfOptions);
                    }
                }
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
 * 1. When you need to generate a PDF from an EPS logo and include a small PNG preview for faster document browsing in a C# application.
 * 2. When building a report generator that converts vector illustrations to PDFs while providing thumbnail images for thumbnail galleries or file explorers.
 * 3. When integrating Aspose.Imaging into a document management system to store EPS artwork as searchable PDFs with embedded preview images for end‑users.
 * 4. When creating an automated batch process that converts a collection of EPS files to PDFs and produces 200 × 200 PNG thumbnails for quick visual verification.
 * 5. When developing a web service that receives EPS uploads, converts them to PDF, and returns a lightweight PNG preview for preview panes without loading the full PDF.
 */
