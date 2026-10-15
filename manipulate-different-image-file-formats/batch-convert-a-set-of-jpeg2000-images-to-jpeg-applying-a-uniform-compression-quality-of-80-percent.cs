// HOW-TO: Batch Convert JPEG2000 Images to JPEG with 80 Percent Quality in C# (Aspose.Imaging for .NET)
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

namespace BatchConvertJpeg2000ToJpeg
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputDir = @"C:\InputJpeg2000";
                string outputDir = @"C:\OutputJpeg";

                string[] files = Directory.GetFiles(inputDir, "*.jp2", SearchOption.TopDirectoryOnly);
                foreach (string inputPath in files)
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        continue;
                    }

                    string fileName = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDir, fileName + ".jpg");

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (Image image = Image.Load(inputPath))
                    {
                        JpegOptions options = new JpegOptions
                        {
                            Quality = 80
                        };
                        image.Save(outputPath, options);
                    }

                    Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
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
 * 1. When you need to migrate a legacy archive of JPEG2000 files to standard JPEG format for compatibility with web browsers.
 * 2. When you want to reduce file size of high‑resolution JPEG2000 photos by saving them as JPEG with a specific 80 % compression quality.
 * 3. When you have to process a folder of medical or satellite images in JP2 format and generate JPEG copies for quick preview in a desktop application.
 * 4. When an automated build pipeline must convert incoming JP2 assets to JPEG before they are uploaded to a content‑delivery network.
 * 5. When a Windows service needs to batch‑convert user‑uploaded JP2 images to JPEG while preserving the original filenames.
 */
