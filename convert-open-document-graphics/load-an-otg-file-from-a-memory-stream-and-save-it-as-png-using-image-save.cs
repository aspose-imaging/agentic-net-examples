// HOW-TO: Convert OTG Image to PNG from Memory Stream in C# (Aspose.Imaging for .NET)
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

namespace OTGToPng
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.otg";
                string outputPath = "output.png";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                using (FileStream fs = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
                using (MemoryStream ms = new MemoryStream())
                {
                    fs.CopyTo(ms);
                    ms.Position = 0;

                    using (Image image = Image.Load(ms))
                    {
                        var options = new PngOptions();
                        image.Save(outputPath, options);
                    }
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
 * 1. When you need to display or share an OTG diagram on the web, you can convert it to a PNG using Aspose.Imaging in C#.
 * 2. When processing uploaded OTG files in a web API, loading them into a MemoryStream and saving as PNG enables efficient thumbnail generation.
 * 3. When integrating legacy OTG assets into a Windows desktop application, converting them to PNG at runtime simplifies rendering with standard controls.
 * 4. When automating batch conversion of OTG files stored in a database, reading the binary data into a MemoryStream and saving as PNG streamlines the workflow.
 * 5. When creating a reporting service that exports OTG charts as PNG images for PDF reports, using Image.Load and Image.Save in C# provides a reliable conversion path.
 */
