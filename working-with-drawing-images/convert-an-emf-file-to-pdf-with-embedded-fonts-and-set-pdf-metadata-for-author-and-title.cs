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
            string inputPath = "input.emf";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var vectorOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None
                };

                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = vectorOptions,
                    PdfDocumentInfo = new PdfDocumentInfo
                    {
                        Author = "Author Name",
                        Title = "Document Title"
                    }
                };

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
 * 1. When a developer needs to generate printable PDF reports from vector EMF diagrams created by a Windows application, preserving font fidelity and embedding author and title metadata.
 * 2. When an enterprise workflow requires automatic conversion of EMF assets such as logos or schematics to PDF for archiving, ensuring embedded fonts prevent missing characters.
 * 3. When a web service must deliver downloadable PDFs that contain EMF‑based charts, adding PDF metadata for search indexing and compliance reporting.
 * 4. When a batch script converts a library of EMF files into PDF brochures, using C# and Aspose.Imaging to retain vector quality and embed fonts for consistent rendering on any device.
 * 5. When a desktop application exports user‑created EMF drawings to PDF for electronic signatures, inserting author and title information to meet legal document standards.
 */