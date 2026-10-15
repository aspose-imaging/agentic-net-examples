// HOW-TO: Merge JPEG Images Horizontally Into PDF With 300 DPI C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Imaging;
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
            string inputDir = "Input";
            string outputPdfPath = "Output/merged.pdf";
            string tempJpegPath = "Output/temp.jpg";

            if (!Directory.Exists(inputDir))
            {
                Directory.CreateDirectory(inputDir);
                Console.WriteLine($"Input directory created at: {inputDir}. Add files and rerun.");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPdfPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            string[] jpegFiles = Directory.GetFiles(inputDir, "*.jpg");
            if (jpegFiles.Length == 0)
            {
                Console.WriteLine("No JPEG files found in input directory.");
                return;
            }

            var imagesInfo = new List<(string path, int width, int height)>();
            foreach (var file in jpegFiles)
            {
                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    return;
                }
                using (JpegImage img = (JpegImage)Image.Load(file))
                {
                    imagesInfo.Add((file, img.Width, img.Height));
                }
            }

            int canvasWidth = imagesInfo.Sum(i => i.width);
            int canvasHeight = imagesInfo.Max(i => i.height);

            Source tempSource = new FileCreateSource(tempJpegPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = tempSource, Quality = 100 };
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetX = 0;
                foreach (var info in imagesInfo)
                {
                    using (JpegImage img = (JpegImage)Image.Load(info.path))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                PdfOptions pdfOptions = new PdfOptions();
                pdfOptions.ResolutionSettings = new Aspose.Imaging.ResolutionSetting(300, 300);
                canvas.Save(outputPdfPath, pdfOptions);
            }

            if (File.Exists(tempJpegPath))
            {
                File.Delete(tempJpegPath);
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
 * 1. When you need to combine multiple scanned JPEG pages into a single high‑resolution PDF for printing or archiving.
 * 2. When generating a printable catalog by stitching product photos side‑by‑side and exporting them as a 300‑DPI PDF.
 * 3. When creating a PDF report that includes horizontally aligned screenshots saved as JPEGs with consistent DPI.
 * 4. When automating the preparation of legal documents that require JPEG evidence images merged into a single PDF at print‑quality resolution.
 * 5. When developing a batch process that converts a folder of JPEG receipts into a single PDF with 300 DPI for accounting audits.
 */
