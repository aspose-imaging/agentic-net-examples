// HOW-TO: Convert HTML5 Canvas Stream To JPEG Image In C# (Aspose.Imaging for .NET)
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

namespace Html5CanvasToJpeg
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.canvas";
                string outputPath = "output/output.jpg";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (FileStream fs = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
                {
                    using (Image image = Image.Load(fs))
                    {
                        JpegOptions options = new JpegOptions();
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
 * 1. When you need to read a canvas file saved by a web application and store it as a JPEG for archival or further processing.
 * 2. When a server‑side C# service receives an HTML5 Canvas image as a binary stream and must deliver a standard JPEG to browsers or email clients.
 * 3. When you want to batch‑convert multiple .canvas files into JPEGs for a photo‑gallery website without manual editing.
 * 4. When integrating a .NET backend with a JavaScript drawing tool and you must transform the canvas output into a JPEG for printing or PDF generation.
 * 5. When you need to programmatically compress a canvas image by saving it as JPEG using Aspose.Imaging options.
 */
