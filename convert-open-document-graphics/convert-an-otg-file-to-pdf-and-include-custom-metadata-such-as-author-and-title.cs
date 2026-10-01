// HOW-TO: Convert OTG to PDF with Author and Title Metadata in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.otg");
            string outputPath = Path.Combine("Output", "sample.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    pdfOptions.PdfDocumentInfo = new PdfDocumentInfo
                    {
                        Author = "Author Name",
                        Title = "Document Title"
                    };
                    image.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to generate searchable PDF reports from OTG design files while embedding author and title information for document management systems.
 * 2. When an application must batch‑convert OTG graphics exported from CAD tools into PDFs and add consistent metadata for archiving and compliance.
 * 3. When a web service receives OTG images from users and must return PDF versions that include proper author and title fields for downstream indexing.
 * 4. When integrating Aspose.Imaging into a C# workflow to transform OTG artwork into PDF portfolios with custom document properties for branding purposes.
 * 5. When automating the creation of PDF documentation from OTG assets and requiring embedded metadata to appear in PDF viewers’ file properties panel.
 */
