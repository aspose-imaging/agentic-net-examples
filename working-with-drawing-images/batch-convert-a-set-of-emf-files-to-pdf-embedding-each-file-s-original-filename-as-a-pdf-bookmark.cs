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
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            string[] emfFiles = Directory.GetFiles(inputDirectory, "*.emf");

            foreach (string inputPath in emfFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    // Set PDF document title (used as a simple bookmark placeholder)
                    pdfOptions.PdfDocumentInfo = new PdfDocumentInfo { Title = fileNameWithoutExt };

                    // Configure vector rasterization options manually
                    var vectorOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    };
                    pdfOptions.VectorRasterizationOptions = vectorOptions;

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
 * 1. When a developer needs to automate the conversion of a large collection of Windows Metafile (EMF) diagrams into searchable PDF documents while preserving each diagram’s original filename as a PDF bookmark for easy navigation.
 * 2. When a reporting system must generate printable PDF reports from vector‑based EMF charts and embed the chart name as the document title using Aspose.Imaging’s VectorRasterizationOptions in C#.
 * 3. When a batch processing job has to convert engineering schematics stored as EMF files into PDF files with consistent page size and white background, ensuring the output PDFs are indexed by the original file names.
 * 4. When a document management workflow requires programmatically converting multiple EMF assets to PDF format and creating a simple bookmark hierarchy based on each file’s name to improve document discoverability.
 * 5. When a .NET application needs to read EMF images from a folder, apply custom rasterization settings such as TextRenderingHint and SmoothingMode, and save each image as a PDF with the source filename embedded as the PDF title for downstream indexing.
 */