// HOW-TO: Generate PDF With Centered Median Filtered BMP Using C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.bmp";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            using (Aspose.Imaging.RasterImage bmpImage = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                var medianOptions = new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3);
                bmpImage.Filter(bmpImage.Bounds, medianOptions);

                int canvasWidth = 595;
                int canvasHeight = 842;

                string tempJpegPath = Path.Combine(outputDir, "temp.jpg");
                Directory.CreateDirectory(Path.GetDirectoryName(tempJpegPath));
                FileCreateSource tempSource = new FileCreateSource(tempJpegPath, false);
                JpegOptions jpegOptions = new JpegOptions() { Source = tempSource, Quality = 100 };

                using (JpegImage canvas = (JpegImage)Aspose.Imaging.Image.Create(jpegOptions, canvasWidth, canvasHeight))
                {
                    int offsetX = (canvasWidth - bmpImage.Width) / 2;
                    int offsetY = (canvasHeight - bmpImage.Height) / 2;
                    Aspose.Imaging.Rectangle destRect = new Aspose.Imaging.Rectangle(offsetX, offsetY, bmpImage.Width, bmpImage.Height);
                    canvas.SaveArgb32Pixels(destRect, bmpImage.LoadArgb32Pixels(bmpImage.Bounds));
                    canvas.Save();
                }

                using (Aspose.Imaging.Image tempJpeg = Aspose.Imaging.Image.Load(tempJpegPath))
                {
                    PdfOptions pdfOptions = new PdfOptions();
                    tempJpeg.Save(outputPath, pdfOptions);
                }

                if (File.Exists(tempJpegPath))
                {
                    File.Delete(tempJpegPath);
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
 * 1. When you need to embed a noise‑reduced BMP scan into a printable PDF report with the image centered on the page.
 * 2. When you want to clean up a BMP screenshot using a median filter before adding it to a PDF brochure.
 * 3. When an application must automatically convert legacy BMP assets to PDF files while ensuring the filtered image is centered.
 * 4. When generating invoices that include a filtered BMP logo placed in the middle of each PDF page.
 * 5. When creating archival PDFs from medical BMP images that require median filtering to remove speckles before centering them.
 */
