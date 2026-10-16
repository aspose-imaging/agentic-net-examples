// HOW-TO: Convert ODG File to JPEG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
                    JpegOptions jpegOptions = new JpegOptions();
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
 * 1. When you need to display an OpenDocument graphics (ODG) diagram on a website that only supports JPEG images.
 * 2. When integrating a .NET application that must generate thumbnail previews of ODG files for email attachments.
 * 3. When automating a workflow that converts user‑uploaded ODG drawings to JPEG for printing or archival.
 * 4. When migrating legacy design assets stored as ODG into a JPEG‑based digital asset management system using C#.
 * 5. When creating a simple utility to verify that an ODG file can be opened and saved as a JPEG with default compression settings.
 */
