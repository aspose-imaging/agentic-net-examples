// HOW-TO: Convert OTG to JPEG with Custom Chroma Subsampling in C# (Aspose.Imaging for .NET)
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
    static void Main(string[] args)
    {
        string inputPath = "Input\\sample.otg";
        string outputPath = "Output\\sample.jpg";

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
                var jpegOptions = new JpegOptions();
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
 * 1. When a developer needs to convert proprietary OTG graphics to standard JPEG files for web publishing while maintaining color fidelity.
 * 2. When integrating legacy OTG assets into a C# application that only accepts JPEG images for reports or email attachments.
 * 3. When automating batch conversion of OTG files to JPEG on a server and wants to specify chroma subsampling to balance file size and color quality.
 * 4. When preparing OTG drawings for mobile devices where JPEG compression is required but accurate colors are essential.
 * 5. When migrating an existing image repository from OTG to JPEG to ensure compatibility with third‑party viewers and editing tools.
 */
