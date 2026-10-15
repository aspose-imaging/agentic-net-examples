// HOW-TO: Extract Each Frame from Multi‑Page TIFF and Save as BMP in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.tif";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Image image = Image.Load(inputPath))
            {
                TiffImage tiff = (TiffImage)image;
                for (int i = 0; i < tiff.Frames.Length; i++)
                {
                    TiffFrame frame = tiff.Frames[i];
                    string outputPath = Path.Combine("output", $"frame_{i}.bmp");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    BmpOptions bmpOptions = new BmpOptions
                    {
                        BitsPerPixel = 24
                    };
                    frame.Save(outputPath, bmpOptions);
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
 * 1. When you need to extract individual pages from a multi‑page TIFF document to feed a legacy system that only accepts BMP files.
 * 2. When converting scanned medical images stored as TIFF frames into 24‑bit BMPs for compatibility with older diagnostic software.
 * 3. When preparing each page of a multi‑page TIFF for high‑resolution printing that requires BMP format.
 * 4. When archiving each frame of a TIFF as separate BMP files to simplify file‑level version control or backup.
 * 5. When processing TIFF animations frame‑by‑frame in C# and saving them as BMPs for further pixel‑level analysis.
 */
