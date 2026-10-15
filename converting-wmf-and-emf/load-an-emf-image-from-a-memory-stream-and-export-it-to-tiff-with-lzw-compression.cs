// HOW-TO: Convert EMF Stream to LZW Compressed TIFF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff.Enums;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.emf";
            string outputPath = "Output/output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            byte[] emfBytes = File.ReadAllBytes(inputPath);
            using (MemoryStream ms = new MemoryStream(emfBytes))
            {
                using (Image image = Image.Load(ms))
                {
                    using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.TiffLzwRgb))
                    {
                        image.Save(outputPath, tiffOptions);
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
 * 1. When a developer needs to read an EMF vector graphic from a byte array or network stream and store it as a loss‑less, LZW‑compressed TIFF for archival or further processing.
 * 2. When a Windows application must convert user‑generated EMF drawings into a TIFF format that can be opened by non‑Windows platforms without losing quality.
 * 3. When a batch job processes scanned documents that include embedded EMF logos and must output a single TIFF file with LZW compression to reduce file size.
 * 4. When a reporting tool generates charts as EMF in memory and the final report requires the images in TIFF for compatibility with PDF or print workflows.
 * 5. When a cloud service receives EMF files via API, loads them from a memory stream, and needs to deliver LZW‑compressed TIFFs to clients for efficient download.
 */
