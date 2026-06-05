using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input SVG file
            string inputPath = "Input/sample.svg";
            // Output PSD file
            string psdPath = "Output/result.psd";
            // Output PDF file
            string pdfPath = "Output/result.pdf";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(psdPath));
            Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));

            // Load the vector image (e.g., SVG)
            using (Image image = Image.Load(inputPath))
            {
                // Configure PSD options with high‑quality rasterization settings
                using (PsdOptions psdOptions = new PsdOptions())
                {
                    psdOptions.Source = new FileCreateSource(psdPath, false);
                    psdOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        SmoothingMode = SmoothingMode.AntiAlias,
                        TextRenderingHint = TextRenderingHint.AntiAlias
                    };

                    // Save as PSD
                    image.Save(psdPath, psdOptions);
                }
            }

            // Load the generated PSD and export to PDF
            using (Image psdImage = Image.Load(psdPath))
            {
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    // Save as PDF
                    psdImage.Save(pdfPath, pdfOptions);
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
 * 1. When a developer needs to convert an SVG logo into a print‑ready PDF with anti‑aliased rasterization, they can use this code to first render a high‑quality PSD and then export it as PDF.
 * 2. When building an automated pipeline that archives vector illustrations as lossless PSD files while preserving smooth text and graphics for future editing, this snippet ensures the PSD is created with SmoothingMode.AntiAlias and TextRenderingHint.AntiAlias before PDF export.
 * 3. When generating product catalogs where SVG icons must appear crisp on both screen and printed pages, the code provides a reliable way to rasterize the vectors with high‑quality settings and produce a PDF for distribution.
 * 4. When a web service needs to offer on‑the‑fly conversion of user‑uploaded SVG diagrams into searchable PDFs, the example demonstrates how to apply high‑quality rendering options during PSD creation to maintain visual fidelity.
 * 5. When creating marketing brochures that require exact color reproduction and smooth typography from vector assets, developers can employ this workflow to render the SVG into a PSD with anti‑aliasing and then output a PDF ready for professional printing.
 */