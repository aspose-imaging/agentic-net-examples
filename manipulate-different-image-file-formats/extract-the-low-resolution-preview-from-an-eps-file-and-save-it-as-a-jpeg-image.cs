// HOW-TO: Extract Low Resolution EPS Preview and Save as JPEG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.eps";
            string outputPath = "output/preview.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                using (Image preview = epsImage.GetPreviewImage((EpsPreviewFormat)0))
                {
                    JpegOptions jpegOptions = new JpegOptions();
                    preview.Save(outputPath, jpegOptions);
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
 * 1. When you need to generate a quick thumbnail of an EPS artwork for a web gallery, you can extract its low‑resolution preview and convert it to a JPEG using Aspose.Imaging in C#.
 * 2. When a document management system must display a preview of uploaded EPS files without rendering the full vector content, this code creates a lightweight JPEG preview for faster loading.
 * 3. When an email client wants to attach a small image representation of an EPS diagram to improve readability in the message body, the preview extraction and JPEG conversion provides the needed snapshot.
 * 4. When a batch processing job has to create preview images for thousands of EPS files for indexing in a search engine, the routine extracts the preview and saves it as JPEG efficiently.
 * 5. When a desktop application needs to show a quick visual cue of an EPS file before opening it in a full‑featured editor, generating a low‑resolution JPEG preview helps users identify the content instantly.
 */
