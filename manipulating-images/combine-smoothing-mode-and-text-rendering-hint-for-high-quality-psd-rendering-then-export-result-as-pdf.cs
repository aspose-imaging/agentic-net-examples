using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input vector image (e.g., SVG)
            string inputPath = Path.Combine("Input", "sample.svg");
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Output PSD path
            string psdPath = Path.Combine("Output", "result.psd");
            Directory.CreateDirectory(Path.GetDirectoryName(psdPath));

            // Load the vector image and save as PSD with high‑quality rasterization settings
            using (Image image = Image.Load(inputPath))
            {
                var psdOptions = new PsdOptions
                {
                    // Configure vector rasterization for high quality
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        SmoothingMode = SmoothingMode.AntiAlias,
                        TextRenderingHint = TextRenderingHint.AntiAlias
                    },
                    // Optional PSD settings
                    ColorMode = ColorModes.Rgb,
                    CompressionMethod = CompressionMethod.Raw
                };

                image.Save(psdPath, psdOptions);
            }

            // Output PDF path
            string pdfPath = Path.Combine("Output", "result.pdf");
            Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));

            // Load the generated PSD and export to PDF
            using (Image psdImage = Image.Load(psdPath))
            {
                var pdfOptions = new PdfOptions();
                psdImage.Save(pdfPath, pdfOptions);
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
 * 1. When a web application needs to convert user‑uploaded SVG logos into print‑ready PSD files with anti‑aliased edges and crisp text before generating a PDF brochure.
 * 2. When a desktop publishing tool automates the creation of high‑resolution PSD mockups from vector illustrations and then bundles them into a PDF portfolio for client review.
 * 3. When an e‑commerce platform rasterizes product vector graphics into PSD for Photoshop editing while preserving smooth curves and text, and then exports the final design as a PDF invoice attachment.
 * 4. When a marketing automation script processes brand assets by rendering SVG icons with SmoothingMode.AntiAlias and TextRenderingHint.AntiAlias into PSD files and subsequently creates PDF catalogs for distribution.
 * 5. When a document management system ingests vector diagrams, converts them to high‑quality PSD layers for archival, and then generates searchable PDF versions for easy access.
 */