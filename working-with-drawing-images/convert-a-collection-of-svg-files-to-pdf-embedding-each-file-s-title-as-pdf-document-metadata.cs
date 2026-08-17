// HOW-TO: Convert Multiple SVG Files to PDF with Title Metadata in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.svg");

            foreach (var inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    PdfOptions pdfOptions = new PdfOptions
                    {
                        PdfDocumentInfo = new PdfDocumentInfo(),
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageSize = image.Size
                        }
                    };
                    pdfOptions.PdfDocumentInfo.Title = fileNameWithoutExt;

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
 * 1. When a developer needs to batch‑convert a library of SVG icons into searchable PDF reports while preserving each graphic’s title as PDF metadata.
 * 2. When generating printable catalogs from SVG product illustrations and wanting the PDF file’s Title property to match the original SVG name for easier indexing.
 * 3. When automating a document workflow that extracts vector graphics from a design folder and creates PDF assets with embedded titles for downstream content‑management systems.
 * 4. When building a C# service that receives SVG uploads, converts them to PDF, and stores the PDFs with proper metadata for compliance or archival purposes.
 * 5. When creating a desktop utility that scans an input directory of SVG diagrams, converts each to a PDF page‑size match, and sets the PDF title to the diagram’s filename for quick search in file explorers.
 */
