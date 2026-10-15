// HOW-TO: Split Multi‑Page TIFF into Individual Files with Frame Index Names in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputDir = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                int frameCount = tiff.Frames.Count();
                for (int i = 0; i < frameCount; i++)
                {
                    TiffFrame frame = tiff.Frames[i];
                    TiffFrame newFrame = TiffFrame.CopyFrame(frame);
                    using (TiffImage single = new TiffImage(newFrame))
                    {
                        string outputPath = Path.Combine(outputDir, $"frame_{i}.tif");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                        single.Save(outputPath, new TiffOptions(TiffExpectedFormat.Default));
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
 * 1. When you need to extract each page of a multi‑page TIFF for separate processing or archival, this code creates individual TIFF files named by their original frame index.
 * 2. When a document‑management system requires uploading each TIFF frame as a distinct image, the snippet splits the source file and saves the frames with sequential filenames.
 * 3. When generating thumbnails or applying per‑page transformations, you first separate the TIFF into single‑frame files using this approach.
 * 4. When integrating with a workflow that consumes one image per step, the code isolates each frame of a multi‑page TIFF into its own file for downstream tasks.
 * 5. When debugging or inspecting specific pages of a large TIFF, the routine extracts and saves each frame so you can open them individually in any viewer.
 */
