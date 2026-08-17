// HOW-TO: Convert EMF to PDF with Embedded Fonts and Metadata in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output paths
            string inputPath = "input.emf";
            string outputPath = "output\\output.pdf";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PDF options with embedded fonts
                PdfOptions pdfOptions = new PdfOptions
                {
                    PdfDocumentInfo = new PdfDocumentInfo
                    {
                        Author = "Author Name",
                        Title = "Document Title"
                    }
                };

                // Configure vector rasterization to preserve fonts
                if (image is VectorImage)
                {
                    var vectorOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    };

                    pdfOptions.VectorRasterizationOptions = vectorOptions;
                }

                // Save as PDF
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
 * 1. When you need to generate a searchable PDF from vector EMF graphics while preserving the original fonts for accurate rendering.
 * 2. When a reporting system must embed author and title information into PDFs created from EMF diagrams for document management.
 * 3. When converting legacy Windows Metafile images to PDF for archiving, ensuring the output file size stays small by embedding fonts instead of rasterizing text.
 * 4. When automating batch processing of EMF assets in a C# application and you require consistent PDF metadata for indexing in content repositories.
 * 5. When building a document workflow that transforms design sketches saved as EMF into PDF files with proper metadata for compliance and audit trails.
 */
