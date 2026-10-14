// HOW-TO: Convert OTG Image to JPEG in C# Using Aspose.Imaging (Aspose.Imaging for .NET)
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

namespace ImageConversion
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.otg";
                string outputPath = "output.jpg";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputDir = Path.GetDirectoryName(outputPath);
                if (string.IsNullOrEmpty(outputDir))
                {
                    outputDir = ".";
                }
                Directory.CreateDirectory(outputDir);

                using (Image image = Image.Load(inputPath))
                {
                    JpegOptions options = new JpegOptions();
                    image.Save(outputPath, options);
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
 * 1. When a developer needs to display a proprietary OTG graphic on a website, they can convert it to a JPEG for browser compatibility.
 * 2. When an application must generate a preview thumbnail of an OTG file for a file‑manager UI, this code creates a JPEG snapshot.
 * 3. When a legacy system stores engineering diagrams as OTG and the new system only accepts JPEG, the conversion enables seamless migration.
 * 4. When sending OTG images via email, converting them to JPEG reduces size and ensures the recipient can open the attachment.
 * 5. When integrating image conversion into a document‑management workflow, this snippet automates the transformation of each OTG file to a standard JPEG format.
 */
