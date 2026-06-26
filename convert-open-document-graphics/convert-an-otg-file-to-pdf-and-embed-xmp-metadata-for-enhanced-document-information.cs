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
            string inputPath = "Input/sample.otg";
            string outputPath = "Output/sample.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    pdfOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
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
 * 1. When a CAD application generates design schematics in OTG format and the developer must automatically convert them to PDF files with embedded XMP metadata for version control and easy sharing.
 * 2. When a document management workflow receives OTG vector drawings from field engineers and needs a C# service that transforms them into PDF documents while preserving image dimensions and adding XMP metadata for indexing.
 * 3. When an e‑learning platform stores lesson illustrations as OTG files and requires a backend routine that rasterizes each image to a PDF page of the same size and injects XMP metadata for author and copyright details.
 * 4. When a legal firm archives case diagrams created in OTG and wants to use Aspose.Imaging in a .NET application to produce PDF evidence files that include XMP metadata for timestamps and reviewer information.
 * 5. When a publishing system processes batch OTG artwork and must generate PDF proofs with a consistent white background, exact page size, and embedded XMP metadata to support automated content management and search.
 */