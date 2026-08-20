// HOW-TO: Render High Quality PSD From SVG With AntiAliasing And Convert To PDF In C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output paths
            string inputPath = "Input\\sample.svg";
            string psdPath = "Output\\result.psd";
            string pdfPath = "Output\\result.pdf";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(psdPath));
            Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));

            // Load the source image (vector format assumed for high‑quality rendering)
            using (Image image = Image.Load(inputPath))
            {
                // Configure PSD options with vector rasterization settings
                PsdOptions psdOptions = new PsdOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        SmoothingMode = SmoothingMode.AntiAlias,
                        TextRenderingHint = TextRenderingHint.AntiAlias
                    }
                };

                // Save as PSD
                image.Save(psdPath, psdOptions);
            }

            // Load the generated PSD and export to PDF with the same high‑quality settings
            using (Image psdImage = Image.Load(psdPath))
            {
                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = psdImage.Width,
                        PageHeight = psdImage.Height,
                        SmoothingMode = SmoothingMode.AntiAlias,
                        TextRenderingHint = TextRenderingHint.AntiAlias
                    }
                };

                // Save as PDF
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
 * 1. When you need to convert a vector SVG logo into a print‑ready PSD file with smooth edges and crisp text before generating a PDF for client review.
 * 2. When an automated workflow must preserve anti‑aliased rendering while turning design assets into PDFs for digital distribution.
 * 3. When a desktop application creates high‑resolution PSD mockups from SVG illustrations and then exports them as PDFs for archiving.
 * 4. When a batch process has to ensure consistent smoothing and text rendering across multiple SVG files converted to PSD and PDF formats.
 * 5. When a publishing system requires vector‑to‑raster conversion with anti‑aliasing to maintain visual quality in both PSD and PDF outputs.
 */
