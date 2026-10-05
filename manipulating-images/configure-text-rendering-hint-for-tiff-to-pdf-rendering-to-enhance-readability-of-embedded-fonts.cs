// HOW-TO: How to Set Text Rendering Hint When Converting TIFF to PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.tif";
            string outputPath = "Output\\result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    var vectorOpts = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = tiff.Width,
                        PageHeight = tiff.Height,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    };
                    pdfOptions.VectorRasterizationOptions = vectorOpts;

                    tiff.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to generate searchable PDF documents from scanned TIFF files while ensuring the embedded text remains crisp and readable.
 * 2. When converting multi‑page TIFF archives to PDF and wants to control font rendering to avoid blurry characters on low‑resolution displays.
 * 3. When producing PDF reports from high‑resolution TIFF maps and must preserve vector text quality by disabling smoothing.
 * 4. When automating a document workflow that requires consistent text appearance across PDFs generated from various TIFF sources.
 * 5. When integrating Aspose.Imaging into a C# application to create PDFs with single‑bit per pixel text rendering for better OCR accuracy.
 */
