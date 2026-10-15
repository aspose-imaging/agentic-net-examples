// HOW-TO: Handle Error When Saving BMP With Aspose.Imaging To Read‑Only Stream In C# (Aspose.Imaging for .NET)
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

namespace AsposeImagingExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input and output paths
                string inputPath = "input.jpg";
                string outputPath = "output/output.bmp";

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the source image
                using (Image image = Image.Load(inputPath))
                {
                    // Open a read‑only file stream for the output path
                    using (FileStream readOnlyStream = new FileStream(outputPath, FileMode.OpenOrCreate, FileAccess.Read))
                    {
                        // Attempt to save as BMP to the read‑only stream
                        BmpOptions bmpOptions = new BmpOptions();
                        image.Save(readOnlyStream, bmpOptions);
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
 * 1. When a developer needs to convert a JPEG image to BMP using Aspose.Imaging but must write the result to a file that may be opened with read‑only permissions.
 * 2. When an application processes user‑uploaded photos and saves them as BMP files on a network share where the file system enforces read‑only access.
 * 3. When a background service generates thumbnail BMPs and must gracefully handle cases where the destination stream cannot be written.
 * 4. When integrating Aspose.Imaging into a legacy system that opens output files with FileAccess.Read for compatibility, requiring proper exception handling.
 * 5. When debugging image conversion pipelines and you want to capture and log errors caused by insufficient write permissions on the output stream.
 */
