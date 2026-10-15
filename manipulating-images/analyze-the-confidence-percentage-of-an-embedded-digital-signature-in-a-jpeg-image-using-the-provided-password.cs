// HOW-TO: Analyze Digital Signature Confidence in JPEG Image Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
            // Hardcoded paths
            string inputPath = "input.jpg";
            string outputPath = "output.txt";
            string password = "myPassword";

            // Input file existence check
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load image and analyze digital signature
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                int confidence = image.AnalyzePercentageDigitalSignature(password);
                File.WriteAllText(outputPath, $"Confidence: {confidence}%");
                Console.WriteLine($"Confidence: {confidence}%");
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
 * 1. When you need to verify the authenticity of a JPEG photo by checking the confidence level of its embedded digital signature in a C# application.
 * 2. When a compliance system must extract and log the signature confidence percentage from secured images before archiving them.
 * 3. When a forensic tool requires programmatic access to a JPEG’s digital signature to assess tampering risk using a known password.
 * 4. When an automated workflow processes user‑uploaded images and needs to reject files whose signature confidence falls below a threshold.
 * 5. When you want to generate a simple text report of a JPEG’s signature confidence for audit trails in a .NET environment.
 */
