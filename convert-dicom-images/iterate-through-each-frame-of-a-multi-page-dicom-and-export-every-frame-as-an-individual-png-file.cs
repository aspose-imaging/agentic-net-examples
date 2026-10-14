// HOW-TO: Extract Each Frame from Multi‑Page DICOM and Save as PNG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.dcm";
            string outputDir = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (DicomImage dicom = (DicomImage)Aspose.Imaging.Image.Load(inputPath))
            {
                if (dicom is Aspose.Imaging.IMultipageImage multipage)
                {
                    int pageCount = multipage.PageCount;
                    for (int i = 0; i < pageCount; i++)
                    {
                        using (Aspose.Imaging.Image page = multipage.Pages[i])
                        {
                            string outPath = Path.Combine(outputDir, $"frame_{i}.png");
                            Directory.CreateDirectory(Path.GetDirectoryName(outPath));
                            var pngOptions = new PngOptions();
                            page.Save(outPath, pngOptions);
                        }
                    }
                }
                else
                {
                    string outPath = Path.Combine(outputDir, "frame_0.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outPath));
                    var pngOptions = new PngOptions();
                    dicom.Save(outPath, pngOptions);
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
 * 1. When you need to generate web‑friendly PNG thumbnails for every slice in a multi‑page DICOM study.
 * 2. When a radiology application must export each DICOM frame as a separate lossless PNG for downstream analysis.
 * 3. When integrating a medical imaging workflow that requires converting DICOM series into individual PNG files for machine‑learning preprocessing.
 * 4. When archiving each frame of a multi‑frame DICOM as PNG to preserve image quality while using a more universally supported format.
 * 5. When building a viewer that lets users download each DICOM slice as an independent PNG image for reporting or documentation.
 */
