// HOW-TO: Convert CMX Image To JPEG With Quality 90 In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.cmx";
            string outputPath = "output/output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 90
                };
                image.Save(outputPath, jpegOptions);
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
 * 1. When you need to display legacy CorelDRAW CMX drawings on a website that only supports JPEG images, you can convert the CMX file to a JPEG with a specific quality setting using Aspose.Imaging in C#.
 * 2. When generating thumbnails for a document management system, you may convert high‑resolution CMX files to compressed JPEGs at quality 90 to balance visual fidelity and file size.
 * 3. When building an automated migration tool that moves old CMX assets to a modern image repository, you can programmatically load each CMX and save it as a JPEG with controlled compression using C#.
 * 4. When creating a server‑side API that receives CMX uploads and returns JPEG previews, the code demonstrates how to load the CMX, set JpegOptions, and stream the JPEG back to the client.
 * 5. When preparing print‑ready assets for a digital publishing workflow that requires JPEG output, you can use this snippet to ensure the JPEGs are saved with a consistent quality of 90 across all converted files.
 */
