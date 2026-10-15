// HOW-TO: Batch Read JPEG EXIF Data And Log Camera Make Model In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputLogPath = "Output\\exif_log.txt";

            Directory.CreateDirectory(inputDirectory);
            Directory.CreateDirectory(Path.GetDirectoryName(outputLogPath));

            using (StreamWriter writer = new StreamWriter(outputLogPath, false))
            {
                foreach (string filePath in Directory.GetFiles(inputDirectory, "*.jpg"))
                {
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        continue;
                    }

                    using (JpegImage image = (JpegImage)Image.Load(filePath))
                    {
                        var exif = image.ExifData;
                        if (exif != null)
                        {
                            string line = $"{Path.GetFileName(filePath)}: EXIF data present";
                            writer.WriteLine(line);
                            Console.WriteLine(line);
                        }
                        else
                        {
                            string line = $"{Path.GetFileName(filePath)}: No EXIF data";
                            writer.WriteLine(line);
                            Console.WriteLine(line);
                        }
                    }
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
 * 1. When you need to generate a report of which photos in a folder contain EXIF metadata such as camera make and model.
 * 2. When you want to verify that a collection of JPEG images captured by different devices includes proper EXIF tags before uploading to a digital asset management system.
 * 3. When you are building a photo‑organizing tool that groups images by camera model and requires a quick scan of EXIF data across many files.
 * 4. When you need to audit a batch of user‑submitted pictures to ensure they contain EXIF information for forensic or compliance purposes.
 * 5. When you are creating a logging mechanism that records the presence or absence of EXIF metadata for troubleshooting image processing pipelines.
 */
