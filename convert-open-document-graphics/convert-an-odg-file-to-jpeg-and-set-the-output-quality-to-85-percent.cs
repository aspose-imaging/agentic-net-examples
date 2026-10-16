// HOW-TO: Convert ODG to JPEG with 85% Quality Using C# (Aspose.Imaging for .NET)
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

namespace OdgToJpegConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.odg";
                string outputPath = "output.jpg";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                using (Image image = Image.Load(inputPath))
                {
                    var jpegOptions = new JpegOptions
                    {
                        Quality = 85
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
}

/*
 * Real-World Use Cases:
 * 1. When you need to display an OpenDocument graphics (ODG) diagram on a web page that only supports JPEG images.
 * 2. When you want to reduce the file size of an ODG illustration by saving it as a JPEG with a specific quality setting.
 * 3. When you are building an automated batch process that converts multiple ODG files to JPEG for archival or reporting purposes.
 * 4. When you need to integrate ODG to JPEG conversion into a C# desktop application that lets users export their drawings as high‑quality photos.
 * 5. When you must ensure consistent image quality across converted files by explicitly setting the JPEG compression level to 85 percent.
 */
