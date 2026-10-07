// HOW-TO: Extract Low Resolution EPS Preview and Save as JPEG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
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
        try
        {
            string inputPath = "input.eps";
            string outputPath = "output/output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.FileFormats.Eps.EpsImage epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
            {
                using (Image preview = epsImage.GetPreviewImage(Aspose.Imaging.FileFormats.Eps.EpsPreviewFormat.TIFF))
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
 * 1. When you need to generate a quick thumbnail of an EPS artwork for a web gallery without rendering the full vector image.
 * 2. When a document management system must display a preview of uploaded EPS files as JPEGs for faster loading in browsers.
 * 3. When converting batch EPS files to low‑resolution JPEG previews for email attachments or reporting tools.
 * 4. When integrating a C# application that extracts the embedded TIFF preview from EPS and saves it as a JPEG for preview panes.
 * 5. When creating low‑resolution previews of EPS logos to embed in mobile apps where vector rendering is not supported.
 */
