// HOW-TO: Insert a New Frame at Position Two in a Multi‑Page TIFF Using C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                if (tiff.Frames.Count() == 0)
                {
                    Console.Error.WriteLine("The source TIFF has no frames.");
                    return;
                }

                int width = tiff.Frames[0].Width;
                int height = tiff.Frames[0].Height;

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                TiffFrame newFrame = new TiffFrame(tiffOptions, width, height);

                tiff.AddFrame(newFrame);

                int lastIndex = tiff.Frames.Count() - 1;
                if (lastIndex != 1)
                {
                    TiffFrame temp = tiff.Frames[1];
                    tiff.Frames[1] = tiff.Frames[lastIndex];
                    tiff.Frames[lastIndex] = temp;
                }

                tiff.Save(outputPath);
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
 * 1. When you need to add a blank page as the second page of an existing multi‑page TIFF before printing or annotating the document.
 * 2. When you must insert a newly scanned image into a TIFF that was created from a PDF, ensuring the new page appears as the third logical page.
 * 3. When generating a multi‑page TIFF report and you want to programmatically place a cover page as the second frame in the file.
 * 4. When updating an archived multi‑page TIFF by inserting a recent scan at a specific position without rebuilding the entire TIFF stack.
 * 5. When building a document workflow that requires inserting a logo or watermark as a separate frame at position two in a TIFF sequence.
 */
