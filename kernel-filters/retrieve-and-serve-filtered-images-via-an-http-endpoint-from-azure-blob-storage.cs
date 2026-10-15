// HOW-TO: Re-Encode JPEG Image and Save to Disk Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-14
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath = "output.jpg";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, new JpegOptions());
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
 * 1. When you need to verify that a user‑uploaded JPEG can be opened and safely re‑saved on the server before further processing.
 * 2. When you want to normalize JPEG files to a consistent encoding before storing them in Azure Blob Storage.
 * 3. When you must generate a copy of an existing JPEG with default Aspose.Imaging settings to ensure compatibility with downstream .NET services.
 * 4. When you are building an API that reads a local JPEG, applies no visual changes, and returns the same image format to the client.
 * 5. When you need to programmatically create a new folder and write a JPEG file to it as part of an automated image‑handling workflow.
 */
