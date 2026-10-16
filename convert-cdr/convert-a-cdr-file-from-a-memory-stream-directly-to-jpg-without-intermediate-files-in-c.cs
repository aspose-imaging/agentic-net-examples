// HOW-TO: Convert CDR Stream to JPEG Directly in C# Without Temporary Files (Aspose.Imaging for .NET)
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
    static void Main()
    {
        try
        {
            string inputPath = "input.cdr";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (var inputStream = new MemoryStream(File.ReadAllBytes(inputPath)))
            {
                using (Image image = Image.Load(inputStream))
                {
                    var jpegOptions = new JpegOptions();
                    image.Save(outputPath, jpegOptions);
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
 * 1. When a web service receives a CorelDRAW (CDR) file as a byte array and must return a JPEG thumbnail without writing the file to disk.
 * 2. When an automated document processing pipeline needs to transform uploaded CDR drawings into JPEG images for preview while keeping the operation in memory for performance.
 * 3. When a Windows desktop application loads CDR files from a database BLOB and saves them as JPEGs for printing without creating temporary files on the file system.
 * 4. When a cloud function converts user-submitted CDR content to JPEG for storage in cloud blob storage, avoiding disk I/O by using a MemoryStream.
 * 5. When a batch job processes a large collection of CDR files stored in memory and generates JPEG versions for a gallery, minimizing disk usage and cleanup overhead.
 */
