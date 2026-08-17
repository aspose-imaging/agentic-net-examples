// HOW-TO: Batch Convert Vector Images to PDF with Embedded Fonts in C# (Aspose.Imaging for .NET)
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
            string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Input");
            string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");

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

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    pdfOptions.PdfCoreOptions = new PdfCoreOptions
                    {
                        PdfCompliance = PdfComplianceVersion.PdfA1b
                    };

                    if (image is VectorImage)
                    {
                        pdfOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                            SmoothingMode = SmoothingMode.None
                        };
                    }

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
 * 1. When you need to automatically convert a folder of SVG or EPS files into PDF/A‑1b documents with fonts embedded for archival compliance using C#.
 * 2. When a reporting system must generate printable PDFs from vector charts created on the fly, ensuring consistent rendering across platforms.
 * 3. When a document management workflow requires batch processing of vector artwork to create PDF files that meet PDF 1.6 standards for downstream processing.
 * 4. When you want to integrate Aspose.Imaging into a .NET service that transforms designer‑provided vector assets into searchable PDFs with a white background and single‑bit text rendering.
 * 5. When a SaaS application needs to prepare client‑uploaded vector logos for inclusion in contracts, converting them to PDF with embedded fonts to prevent font substitution issues.
 */
