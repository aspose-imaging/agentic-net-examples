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

            string[] files = Directory.GetFiles(inputDirectory);
            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
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
                            PageWidth = image.Width,
                            PageHeight = image.Height,
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
 * 1. When a developer needs to batch‑convert a directory of SVG, EPS, or AI vector graphics into PDF/A‑1b compliant PDFs with embedded fonts and a PDF version of 1.6 for long‑term archival.
 * 2. When an automated build or CI pipeline must process multiple vector image files and generate PDFs that preserve the original page size, white background, and exact dimensions for regulatory reporting.
 * 3. When a web service receives user‑uploaded vector drawings and must render each as a PDF with consistent rasterization options, such as SingleBitPerPixel text rendering and no smoothing, for high‑quality printing.
 * 4. When a desktop application needs to export a collection of design assets to PDF while ensuring the PDF version is set to 1.6 and the fonts are embedded to avoid missing‑glyph issues on client machines.
 * 5. When a document management system requires converting various vector image formats to PDFs with uniform PDF core options and vector rasterization settings to guarantee consistent viewing across different PDF viewers.
 */