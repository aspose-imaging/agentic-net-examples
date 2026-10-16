// HOW-TO: Add 5 Pixel White Border to BMPs and Convert to PDF in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            Directory.CreateDirectory(inputDirectory);
            Directory.CreateDirectory(outputDirectory);

            string[] files = Directory.GetFiles(inputDirectory, "*.bmp");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");

                using (RasterImage bmpImage = (RasterImage)Image.Load(inputPath))
                {
                    if (!bmpImage.IsCached)
                        bmpImage.CacheData();

                    int borderSize = 5;
                    int newWidth = bmpImage.Width + borderSize * 2;
                    int newHeight = bmpImage.Height + borderSize * 2;

                    using (JpegImage canvas = (JpegImage)Image.Create(new JpegOptions(), newWidth, newHeight))
                    {
                        Graphics graphics = new Graphics(canvas);
                        graphics.Clear(Color.White);
                        graphics.DrawImage(bmpImage, borderSize, borderSize);

                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                        using (PdfOptions pdfOptions = new PdfOptions())
                        {
                            canvas.Save(outputPath, pdfOptions);
                        }
                    }
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
 * 1. When you need to prepare a set of scanned BMP documents for printing by adding a uniform white margin and saving them as PDF files for easy distribution.
 * 2. When an application must automatically process user‑uploaded BMP images, pad them with a 5‑pixel border, and generate PDF reports without manual intervention.
 * 3. When a legacy system stores graphics as BMP and you want to batch convert them to PDF with a consistent border for inclusion in an electronic archive.
 * 4. When creating printable catalogs where each BMP product image requires a small white frame before being compiled into PDF pages using C# and Aspose.Imaging.
 * 5. When a document workflow requires adding a safety margin to BMP assets and converting them to PDF to meet compliance standards for document size and format.
 */
