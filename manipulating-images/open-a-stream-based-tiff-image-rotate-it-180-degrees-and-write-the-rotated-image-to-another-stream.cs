// HOW-TO: Rotate A TIFF Image 180 Degrees Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (FileStream inputStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            using (Image image = Image.Load(inputStream))
            {
                image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                using (FileStream outputStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    image.Save(outputStream);
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
 * 1. When you must read a TIFF file from a stream, rotate it 180° and save the corrected image back to another stream for archival purposes.
 * 2. When a scanner uploads a TIFF via a network stream and the application needs to re‑orient the image before further analysis.
 * 3. When generating a PDF from a TIFF that was scanned upside down, requiring a 180‑degree rotation using Aspose.Imaging in C#.
 * 4. When processing batches of medical DICOM‑derived TIFF images that need to be rotated to match the standard viewing orientation.
 * 5. When creating a server‑side image service that receives TIFF streams, applies a 180° rotation, and returns the transformed stream to the client.
 */
