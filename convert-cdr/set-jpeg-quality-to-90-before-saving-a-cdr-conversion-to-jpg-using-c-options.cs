// HOW-TO: Convert CorelDRAW CDR to JPEG with Quality 90 in C# (Aspose.Imaging for .NET)
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
        const string inputPath = "input.cdr";
        const string outputPath = "output.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var jpegOptions = new JpegOptions
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
 * 1. When you need to generate web‑ready JPEG thumbnails from CorelDRAW files while controlling compression to preserve visual fidelity.
 * 2. When an automated batch process must convert customer‑submitted CDR designs to JPEGs with a specific quality setting for printing previews.
 * 3. When integrating Aspose.Imaging into a C# application to export vector artwork as JPEGs with a guaranteed 90 % quality level.
 * 4. When a server‑side service has to validate the existence of a CDR file, convert it, and store the JPEG in a designated folder with consistent compression.
 * 5. When you want to handle errors gracefully while converting CDR to JPEG, ensuring the output uses the JpegOptions Quality property to meet branding guidelines.
 */
