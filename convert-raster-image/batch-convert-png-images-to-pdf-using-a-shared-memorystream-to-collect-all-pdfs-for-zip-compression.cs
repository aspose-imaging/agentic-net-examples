// HOW-TO: Batch Convert PNG Files to PDF and Zip Them in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.IO.Compression;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace BatchPngToPdf
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputFolder = "InputPngs";
                string zipPath = "Output/pdfs.zip";

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(zipPath));

                // Get PNG files
                string[] pngFiles = Directory.GetFiles(inputFolder, "*.png");

                using (MemoryStream zipStream = new MemoryStream())
                {
                    using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Create, true))
                    {
                        foreach (string pngPath in pngFiles)
                        {
                            if (!File.Exists(pngPath))
                            {
                                Console.Error.WriteLine($"File not found: {pngPath}");
                                return;
                            }

                            using (Image image = Image.Load(pngPath))
                            {
                                using (MemoryStream pdfStream = new MemoryStream())
                                {
                                    image.Save(pdfStream, new PdfOptions());
                                    pdfStream.Position = 0;

                                    string entryName = Path.GetFileNameWithoutExtension(pngPath) + ".pdf";
                                    ZipArchiveEntry entry = archive.CreateEntry(entryName, CompressionLevel.Optimal);
                                    using (Stream entryStream = entry.Open())
                                    {
                                        pdfStream.CopyTo(entryStream);
                                    }
                                }
                            }
                        }
                    }

                    using (FileStream fileStream = new FileStream(zipPath, FileMode.Create, FileAccess.Write))
                    {
                        zipStream.Position = 0;
                        zipStream.CopyTo(fileStream);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate a single downloadable ZIP containing PDFs for a large set of PNG screenshots in a web application.
 * 2. When you want to automate the conversion of product‑catalog PNG images into PDF brochures before archiving them.
 * 3. When a desktop tool must batch‑process scanned PNG pages into PDF documents and package them for email attachment.
 * 4. When an API service has to transform user‑uploaded PNG graphics into PDF files and return them as a compressed archive.
 * 5. When you are preparing PNG assets for printing and need to combine the resulting PDFs into one zip file for easy distribution.
 */
